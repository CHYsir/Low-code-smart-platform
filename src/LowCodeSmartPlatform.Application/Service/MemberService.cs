using LowCodeSmartPlatform.Base;
using LowCodeSmartPlatform.Dto;
using LowCodeSmartPlatform.Enitiys;
using LowCodeSmartPlatform.Helepe;
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
    //添加服务实现类，实现上一步定义的业务接口
    //相当于仓储模式中的服务层，CrudAppService就类似于BaseService。仓储层不需要我们去写，都封装好了。API也不需要我们去实现

    public class MemberService:Volo.Abp.Application.Services.CrudAppService<MemberModel,MemberDto,int,Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto,CreateUpdateMemberDto>, ImemberService
    {

        //构造函数注入（不要自定义方法就不用注入）
       private readonly  IRepository<MemberModel, int> _repository;
        public MemberService(IRepository<MemberModel,int> repository) : base(repository)
        {
            //初始化
            _repository = repository;
        }
        #region  自定义增删改查(写法有很多，思路要开阔)
        //当成功时，调用IsSuccess(...)方法，当失败时，调用IsFailed(...)方法。最终我们返回的是new ServiceResult()或者new ServiceResult<T>()对象。

        //删
        [HttpGet, Route("delete")]
        public async Task<ServiceResult> DeleteMemberAsync(int id)
        {
            var result = new ServiceResult();

            await _repository.DeleteAsync(id);

            result.IsSuccess("删除成功！");
            return result;
        }

        ////查
        //[HttpGet,Route("select")]
        //public async Task<ServiceResult<MemberDto>> SelectMemberAsync(int id)
        //{
        //    var result = new ServiceResult<MemberDto>();

        //    var member = await _repository.GetAsync(id);
        //    if (member == null)
        //    {
        //        result.IsFailed("用户不存在");
        //        return result;
        //    }

        //    var dto = new MemberDto
        //    {
        //        UserName = member.UserName,
        //        Passwprd = member.Passwprd,
        //        Phone = member.Phone
        //    };

        //    result.IsSuccess(dto);
        //    return result;
        //}

        ////增
        //[HttpPost,Route("insert")]
        //public  async Task<ServiceResult<string>> InsertAsync(MemberDto dto)
        //{
        //    var result = new ServiceResult<string>();

        //    var entity = new MemberModel
        //    {
        //        UserName = dto.UserName,
        //        Passwprd = dto.Passwprd,
        //        Phone = dto.Phone
        //    };

        //    var member = await _repository.InsertAsync(entity);
        //    if (member == null)
        //    {
        //        result.IsFailed("添加失败");
        //        return result;
        //    }

        //        result.IsSuccess("添加成功");
        //        return result;
        //}

        ////修改
        //[HttpPut,Route("update")]
        //public async Task<ServiceResult<string>> UpdateAsync(int id, MemberDto dto)
        //{
        //    var result = new ServiceResult<string>();

        //    var member = await _repository.GetAsync(id);
        //    if (member == null)
        //    {
        //        result.IsFailed("用户不存在");
        //        return result;
        //    }

        //    member.UserName = dto.UserName;
        //    member.Passwprd = dto.Passwprd;
        //    member.Phone = dto.Phone;

        //    await _repository.UpdateAsync(member);

        //    result.IsSuccess("更新成功");
        //    return result;
        //}


        #endregion





        //当成功时，调用IsSuccess(...)方法，当失败时，调用IsFailed(...)方法。最终我们返回的是new ServiceResult()或者new ServiceResult<T>()对象。

        [HttpPost, Route("login")]
        public async Task<ServiceResult<MemberDto>> LoginAsync(MemberDto member)
        {
            //加密密码
            member.Passwprd = MD5.GetMd5(member.Passwprd);

            var result = new ServiceResult<MemberDto>();
            var list = await _repository.GetListAsync();
            //判断用户名和密码是否为空
            if (!string.IsNullOrEmpty(member.UserName) ||! string.IsNullOrEmpty(member.Passwprd))
            {
                var gets=list.Where(x => x.UserName == member.UserName && x.Passwprd == member.Passwprd).FirstOrDefault();

            
                var token= Jwt.Create.CreateToken(gets.UserName);
                result.IsSuccess("登录成功");
                result.Token = token;
            }
            else
            {
                result.IsFailed("用户名或密码为空");
            }

            return result;
        }
    }
}
