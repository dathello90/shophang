using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shophang.Areas.AdminCP.DTOs;
using shophang.Models;
using AutoMapper;

namespace shophang.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        }
    }
}
