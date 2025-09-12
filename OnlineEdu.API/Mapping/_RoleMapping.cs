using AutoMapper;
using OnlineEdu.DTO.DTOs.RoleDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class _RoleMapping : Profile
    {
        public _RoleMapping()
        {
            CreateMap<AppRole,CreateRoleDto>().ReverseMap();
        }
    }
}
