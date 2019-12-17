using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crud.BuisnesLogic.Dto;
using Crud.DataAccess;
using Crud.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [ApiController, Route("api/beerType")]
    public class BeerTypeController : ControllerBase
    {
        private readonly IBeerTypeRepository beerTypeRepository;
        private readonly IMapper mapper;

        public BeerTypeController(IBeerTypeRepository beerTypeRepository, IMapper mapper)
        {
            this.beerTypeRepository = beerTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BeerTypeDto>> GetBeerTypes() {
            var beerTypesFromRepo = beerTypeRepository.GetBeerTypes();
            return Ok(mapper.Map<IEnumerable<BeerTypeDto>>(beerTypesFromRepo));
        }

        [HttpGet("beerTypeId", Name = "GetBeerType")]
        public ActionResult<BeerTypeDto> GetBeerType(Guid beerTypeId)
        {
            var beerTypeFromRepo = beerTypeRepository.GetBeerType(beerTypeId);
            if(beerTypeFromRepo == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BeerTypeDto>(beerTypeFromRepo));
        }

        [HttpPost]
        public ActionResult<BeerTypeDto> CreateBeerType([FromForm]BeerTypeDto beerType)
        {
            var beerTypeEntity = mapper.Map<BeerType>(beerType);
            beerTypeEntity.BeerTypeId = Guid.NewGuid();

            var beerTypeToReturn = mapper.Map<BeerTypeDto>(beerTypeEntity);
            beerTypeRepository.AddBeerType(beerTypeEntity);
            beerTypeRepository.SaveBeerType();
            return CreatedAtRoute("GetBeerType", new { beerTypeId = beerTypeToReturn.BeerTypeId }, beerTypeToReturn);
        }

        [HttpPut]
        public ActionResult UpdateBeerType(Guid beerTypeId, [FromForm]BeerTypeDto beerType)
        {
            var beerTypeFromRepo = beerTypeRepository.GetBeerType(beerTypeId);

            if (beerTypeFromRepo == null)
            {
                return NotFound();
            }

            mapper.Map(beerType, beerTypeFromRepo);
            beerTypeRepository.UpdateBeerType(beerTypeFromRepo);
            beerTypeRepository.SaveBeerType();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteBeerType(Guid beerTypeId)
        {
            var beerTypeFromRepo = beerTypeRepository.GetBeerType(beerTypeId);
            if (beerTypeFromRepo == null)
                return NotFound();
            beerTypeRepository.DeleteBeerType(beerTypeFromRepo);
            beerTypeRepository.SaveBeerType();
            return NoContent();
        }


    }
}