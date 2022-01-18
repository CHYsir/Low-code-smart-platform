using LowCodeSmartPlatform.Base;
using LowCodeSmartPlatform.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Iservice
{
    //添加服务接口这一步不是必须，但是解藕有效的
    //在这个接口中，继承是ICrudAbpService接口，需要固定的几个参数。（也可以直接继承IApplicationService接口，自定义方法）


    public interface ImemberService:Volo.Abp.Application.Services.ICrudAppService<MemberDto,int,Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto,CreateUpdateMemberDto>
    {
        //这里定义的是具体服务接口

        #region 自定义增删改查(写法有很多，思路要开阔)
        //接口全部为异步方式，用ServiceResult包裹作为返回模型，添加和更新T参数为string类型，删除就直接不返回结果，然后查询为：ServiceResult<MemberDto>

        //增
        //Task<bool> InsertAsync(MemberDto dto);
        //Task<ServiceResult<string>> InsertAsync(MemberDto dto);

        //删
        //Task<bool> DeleteAsync(int id);
        //Task<ServiceResult> DeleteMemberAsync(int id);

        //改
        //Task<bool> UpdateAsync(int id, MemberDto dto);
        //Task<ServiceResult<string>> UpdateAsync(int id, MemberDto dto);

        //查
        //Task<MemberDto> GetAsync(int id);
        //Task<ServiceResult<MemberDto>> SelectMemberAsync(int id);


        #endregion


        //登录
        Task<ServiceResult<MemberDto>> LoginAsync(MemberDto member);
    }
}
