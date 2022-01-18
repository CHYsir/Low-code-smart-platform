using LowCodeSmartPlatform.Base;
using LowCodeSmartPlatform.Dto;
using LowCodeSmartPlatform.Enitiys;
using LowCodeSmartPlatform.Iservice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LowCodeSmartPlatform.Service
{
    public class MenuService : Volo.Abp.Application.Services.ApplicationService, ImenuService
    {
        private readonly IRepository<MenuModel, int> _repository;

        public MenuService(IRepository<MenuModel, int> repository)
        {
            _repository = repository;
        }

        #region 树形菜单1
        [Authorize]
        [HttpGet, Route("treeasync")]
        public  List<MenuDto> TreeAsync()
        {
            var list =  GetMenu(0);
            return list;
        }

        #region 推算过程  仅供逻辑参考
        //第一级菜单
        private List<MenuModel> GetOne(List<MenuModel> list,int id)
        {
            return list.Where(p => p.SupId == 0).ToList();
        }

        //第二级、三级、四级...菜单
        private List<MenuModel> GetTwo(List<MenuModel> list,int id)
        {
            return list.Where(p => p.SupId.Equals(id)).ToList();
        }
        #endregion

        private List<MenuDto> GetMenu(int id)
        {
            List<MenuDto> trees = new List<MenuDto>();
            var list = _repository.GetListAsync().Result.Where(p => p.SupId == id).ToList();

            //第一级循环
            list.ForEach(p =>
            {
                MenuDto t = new MenuDto();
                t.Id = p.Id;
                t.MenuName = p.MenuName;
                t.MenuUrl = p.MenuUrl;

                //获取菜单下所有
                t.Children = GetMenu(p.Id);

                trees.Add(t);
            });

            return trees;
        }

        #endregion

        #region 树形菜单2
        //[Authorize]
        //[HttpGet, Route("treeasync")]
        //public async Task<List<MenuDto>> TreeAsync()
        //{
        //    var list = await GetTree(0);
        //    return list;
        //}

        ////写法1
        //private async Task<List<MenuDto>> GetTree(int supId)
        //{
        //    var Tree = await _repository.GetListAsync();
        //    var gttree = Tree.Where(x => x.SupId.Equals(supId)).ToList();

        //    List<MenuDto> dtos = new List<MenuDto>();
        //    gttree.ForEach(async x =>
        //        dtos.Add(new MenuDto
        //        {
        //            Children = await GetTree(x.Id),
        //            Id = x.Id,
        //            MenuName = x.MenuName,
        //            MenuUrl = x.MenuUrl,
        //            SupId = x.SupId
        //        }));

        //    return dtos;
        //}

        ////写法2
        //有Bug
        //private async Task<List<MenuDto>> GetTree(int supId)
        //{
        //    var Tree = await _repository.GetListAsync();
        //    Tree = Tree.Where(x => x.SupId.Equals(supId)).ToList();
        //    List<MenuDto> dtos = new List<MenuDto>();
        //    Tree.ForEach(async x =>
        //    {
        //        MenuDto t = new MenuDto();
        //        t.MenuName = x.MenuName;
        //        t.MenuUrl = x.MenuUrl;
        //        t.Children = await GetTree(x.Id);   //(Bug)

        //        dtos.Add(t);
        //    });


        //    return dtos;
        //}
        #endregion




    }
}
