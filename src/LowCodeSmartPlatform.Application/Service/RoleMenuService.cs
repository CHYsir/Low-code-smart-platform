using LowCodeSmartPlatform.Dto;
using LowCodeSmartPlatform.Enitiys;
using LowCodeSmartPlatform.Iservice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace LowCodeSmartPlatform.Service
{
    public class RoleMenuService : Volo.Abp.Application.Services.ApplicationService, IroleMenuService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<RoleMenuModel, int> _repository;

        public RoleMenuService(IRepository<RoleMenuModel, int> repository, IUnitOfWorkManager unitOfWorkManager)
        {
            //初始化
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        #region 分配角色权限

        [HttpGet, Route("rolemenu")]
        public int EditRoleMenu(int RoleId, List<int> MenuIds)
        {

            //开启事务
            using (var uow = _unitOfWorkManager.Begin())
            {
                //1、先删除该角色所拥有的权限
                //1、1先找到该角色
                var list = _repository.GetListAsync().Result.Where(p => p.RoleId.Equals(RoleId)).ToList();
                //1、2判断该角色是否存在,存在的话先删除再添加
                if (list != null && list.Count() > 0)
                {
                    //删除集合
                    _repository.DeleteManyAsync(list);

                    //2、重新添加该角色的权限
                    MenuIds.ForEach(p =>
                    {
                        _repository.InsertAsync(new RoleMenuModel
                        {
                            RoleId = RoleId,
                            MenuId = p,
                        });
                    });
                    uow.CompleteAsync();
                    return 200;
                }
            }

            // 执行失败，回调
            using (var uows = _unitOfWorkManager.Begin())
            {
                uows.CompleteAsync();
                return 500;
            }
        }



        public int EditRoleMenu(int RoleId, List<MenuDto> Menus)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
