using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<Cities, CityDto>();
            CreateMap<CityDto,Cities >();

            CreateMap<Authors, AuthorDto>();
            CreateMap<AuthorDto, Authors>();
            

        }
    }
}
