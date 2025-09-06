﻿using AutoMapper;
using OnlineEdu.DTO.DTOs.TeacherSocialsDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class TeacherSocialMapping : Profile
    {
        public TeacherSocialMapping()
        {
            CreateMap<TeacherSocial, ResultTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, CreateTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, UpdateTeacherSocialDto>().ReverseMap();
        }
    }
}
