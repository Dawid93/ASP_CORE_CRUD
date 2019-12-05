using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crud.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [ApiController, Route("api/beer")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository beerRepository;
        private readonly IMapper mapper;

        public BeerController(IBeerRepository beerRepository, IMapper mapper)
        {
            this.beerRepository = beerRepository;
            this.mapper = mapper;
        }
    }
}