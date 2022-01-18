
using LowCodeSmartPlatform.Dto;
using LowCodeSmartPlatform.Enitiys;
using LowCodeSmartPlatform.Iservice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace LowCodeSmartPlatform.Service
{
    //用户角色，实现接口
    public class MemberRoleService:Volo.Abp.Application.Services.ApplicationService, ImemberRoleService
    {
        //构造函数注入
        private readonly IUnitOfWorkManager   _unitOfWorkManager;

        private readonly IRepository<MemberRoleModel, int> _repository;
        private readonly IRepository<RoleMenuModel, int>   _rolemenu;
        private readonly IRepository<MenuModel, int> _menu;



        public  MemberRoleService(IRepository<MemberRoleModel,int> repository, IRepository<RoleMenuModel,int> rolemenu, IRepository<MenuModel, int> menu, IUnitOfWorkManager unitOfWorkManager)
        {
            //初始化
            _menu = menu;
            _rolemenu = rolemenu;
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        #region 分配角色
        [HttpGet,Route("memberrole")]
        public int EditMemberRole(int UserId, List<int> RoleIds)
        {
            //开启事务
            using (var uow = _unitOfWorkManager.Begin())
            {
                //1、先删除该用户现有的角色
                //1、1找到该用户
                var list = _repository.GetListAsync().Result.Where(x => x.UserId.Equals(UserId)).ToList();
                //1、2判断该用户是否存在
                if(list!=null && list.Count()>0)
                {
                    //删除集合
                    _repository.DeleteManyAsync(list);

                    //重新添加该用户的角色
                    RoleIds.ForEach(p =>
                    {
                        _repository.InsertAsync(new MemberRoleModel
                        {
                            UserId = UserId,
                            RoleId = p,
                        });
                    });
                    uow.CompleteAsync();
                    return 200;
                }
            }

            //执行失败，回调
            using (var uows = _unitOfWorkManager.Begin())
            {
                uows.CompleteAsync();
                return 500;
            }
        }

        public int EditMemberRole(int UserId, List<RoleDto> Roles)
        {
            throw new NotImplementedException();
        }



        #endregion


        #region 根据不同用户登录，每个用户权限不一样

        [HttpGet,Route("rbac")]
        public List<MenuDto> rbac(int uid)
        {
            var list = TreeRbac(uid,0);
            return list;
        }

        private List<MenuDto> TreeRbac(int uid,int supId)
        {
         
            List<MenuDto> trees = new List<MenuDto>();

            var aa = _repository.GetListAsync().Result;
            var bb = _rolemenu.GetListAsync().Result;
            var cc = _menu.GetListAsync().Result;

            var list = (from a in aa join b in bb on a.RoleId equals b.RoleId join c in cc on b.MenuId equals c.Id where a.UserId.Equals(uid) select c).ToList();

            var treelist = list.Where(x => x.SupId.Equals(supId)).ToList();

            treelist.ForEach(p =>
            {
                MenuDto t = new MenuDto();
                t.Id = p.Id;
                t.MenuName = p.MenuName;
                t.MenuUrl = p.MenuUrl;
                t.Children = TreeRbac(uid, p.Id);
                t.SupId = p.SupId;

                trees.Add(t);
            });

            return trees;

        }
        #endregion
    }
}
