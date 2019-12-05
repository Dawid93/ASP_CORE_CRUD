using AutoMapper;
using Crud.BuisnesLogic.Dto;
using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.BuisnesLogic.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // BeerProfiles
            CreateMap<Beer, BeerDto>();
            CreateMap<BeerForCreationDto, Beer>();
            CreateMap<BeerForUpdateDto, Beer>();
            CreateMap<Beer, BeerForUpdateDto>();
        }
    }
}
