using AutoMapper;
using LowCodeSmartPlatform.Dto;
using LowCodeSmartPlatform.Enitiys;

namespace LowCodeSmartPlatform
{
    public class LowCodeSmartPlatformApplicationAutoMapperProfile : Profile
    {
        public LowCodeSmartPlatformApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            //配置映射

            //添加DTO与实体映射
            //元组(根源)映射到dto(显示)
            CreateMap<MemberModel, MemberDto>();
            //添加验证DTO与实体映射
            //dto到数据库(添加、修改)
            CreateMap<CreateUpdateMemberDto, MemberModel>();



            CreateMap<MenuModel, MenuDto>();
            CreateMap<MenuDto, MenuModel>();
        }
    }
}
