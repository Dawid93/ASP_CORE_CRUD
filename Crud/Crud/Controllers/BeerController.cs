using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crud.BuisnesLogic.Dto;
using Crud.DataAccess;
using Crud.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet]
        public ActionResult<IEnumerable<BeerDto>> GetBeers()
        {
            var beersFromRepo = beerRepository.GetBeers();
            return Ok(mapper.Map<IEnumerable<BeerDto>>(beersFromRepo));
        }

        [HttpGet("{beerId}", Name = "GetBeer")]
        public ActionResult<BeerDto> GetBeer(Guid beerId)
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);
            if(beerFromRepo == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BeerDto>(beerFromRepo));
        }

        [HttpPost]
        public ActionResult<BeerDto> AddNewBeer(BeerForCreationDto beer)
        {
            var beerEntity = mapper.Map<Beer>(beer);
            beerRepository.AddBeer(beerEntity);
            beerRepository.Commit();
            var beerToReturn = mapper.Map<BeerDto>(beerEntity);
            return CreatedAtRoute("GetBeer", new { beerId = beerToReturn.BeerId }, beerToReturn);
        }

        [HttpPut("{beerId}")]
        public ActionResult UpdateBeer(Guid beerId, BeerForUpdateDto beer) 
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);

            if(beerFromRepo == null)
            {
                return NotFound();
            }

            mapper.Map(beer, beerFromRepo);
            beerRepository.UpdateBeer(beerFromRepo);
            beerRepository.Commit();

            return NoContent();
        }

        [HttpPatch("{beerId}")]
        public ActionResult PartialUpdateBeer(Guid beerId, JsonPatchDocument<BeerForUpdateDto> patchDocument)
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);

            if (beerFromRepo == null)
            {
                return NotFound();
            }

            var beerPatch = mapper.Map<BeerForUpdateDto>(beerFromRepo);
            patchDocument.ApplyTo(beerPatch, ModelState);

            if (!TryValidateModel(beerPatch))
                return ValidationProblem(ModelState);

            mapper.Map(beerPatch, beerFromRepo);
            beerRepository.UpdateBeer(beerFromRepo);
            beerRepository.Commit();
            return NoContent();
        }

        [HttpDelete("{beerId}")]
        public ActionResult DeleteBeer(Guid beerId)
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);
            if (beerFromRepo == null)
                return NotFound();
            beerRepository.DeleteBeer(beerFromRepo);
            beerRepository.Commit();
            return NoContent();
        }
    }
}