using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crud.BuisnesLogic.Dto;
using Crud.DataAccess;
using Crud.DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment enviroment;

        public BeerController(IBeerRepository beerRepository, IMapper mapper, IWebHostEnvironment enviroment)
        {
            this.beerRepository = beerRepository;
            this.mapper = mapper;
            this.enviroment = enviroment;
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
        public async Task<ActionResult<BeerDto>> AddNewBeer([FromForm]BeerForCreationDto beer)
        {
            var beerEntity = mapper.Map<Beer>(beer);
            beerEntity.BeerId = Guid.NewGuid();

            if (beer.BeerImgFile != null && beer.BeerImgFile.Length > 0)
            {
                beerEntity.BeerLabelImg = await SaveFile(beer.BeerImgFile, beerEntity.BeerId.ToString());
            }
            var beerToReturn = mapper.Map<BeerDto>(beerEntity);
            beerRepository.AddBeer(beerEntity);
            beerRepository.SaveBeer();
            return CreatedAtRoute("GetBeer", new { beerId = beerToReturn.BeerId }, beerToReturn);
        }

        [HttpPut("{beerId}")]
        public async Task<ActionResult> UpdateBeer(Guid beerId, [FromForm]BeerForUpdateDto beer) 
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);

            if(beerFromRepo == null)
            {
                return NotFound();
            }

            if (beer.BeerImgFile != null && beer.BeerImgFile.Length > 0)
            {
                beerFromRepo.BeerLabelImg = await SaveFile(beer.BeerImgFile, beerFromRepo.BeerId.ToString());
            }

            mapper.Map(beer, beerFromRepo);
            beerRepository.UpdateBeer(beerFromRepo);
            beerRepository.SaveBeer();

            return NoContent();
        }

        [HttpPatch("{beerId}")]
        public ActionResult PartialUpdateBeer(Guid beerId, [FromForm]JsonPatchDocument<BeerForUpdateDto> patchDocument)
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
            beerRepository.SaveBeer();
            return NoContent();
        }

        [HttpDelete("{beerId}")]
        public ActionResult DeleteBeer(Guid beerId)
        {
            var beerFromRepo = beerRepository.GetBeer(beerId);
            if (beerFromRepo == null)
                return NotFound();
            beerRepository.DeleteBeer(beerFromRepo);
            beerRepository.SaveBeer();
            return NoContent();
        }

        private async Task<string> SaveFile(IFormFile file, string name)
        {
            string ext = Path.GetExtension(file.FileName);
            string folderName = "\\BeerLabels";
            string path; 

            if(!Directory.Exists(enviroment.WebRootPath + folderName)) {
                Directory.CreateDirectory(enviroment.WebRootPath + folderName);
            }

            path = enviroment.WebRootPath + folderName;

            using (var stream = System.IO.File.Create(path + @"\" + name + ext))
            {
                await file.CopyToAsync(stream);
                return @"\BeerLabels\" + name + ext;
            }
        }
    }
}