using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalkes.API.data;
using NZWalkes.API.Models;
using NZWalkes.API.Models.DTOs;
using NZWalkes.API.Repositers;
using System.Drawing;

namespace NZWalkes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
       
        private readonly IRegionRepository _regionRepository;
        public RegionController( IRegionRepository regionRepository)
        {
          
            _regionRepository = regionRepository;
        }

        [HttpGet]
        [Route("/GetAll")]
      

        public async Task<IActionResult> GetAll() 
        {

            // get the values from DataBase first 
            var regionsDomain = await _regionRepository.GetAllAsync();

            // map the result to region DTO

            var regionsDTO = new List<RegionDTO>();

            foreach (var region in regionsDomain) 
            {
                regionsDTO
               .Add(new RegionDTO()
               {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
               }
               );
            }

            return Ok(regionsDTO);
        }



        [HttpGet]
        [Route("/GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {

            // get the recored from database 
           var regionDomain = await _regionRepository.GetByID(id);

            var regionDTO = new RegionDTO()
            {
            Id = id,
            Code= regionDomain.Code,
            Name = regionDomain.Name,
            RegionImageUrl = regionDomain.RegionImageUrl,
            };

            if (regionDomain == null)
            {
                return NotFound();
            }

            return Ok(regionDTO);

        }


        [HttpPost]
        [Route("/Create")]
        public async Task<IActionResult> Create([FromBody] RegionDtoAdd regionToAdd)
        {

    if(ModelState.IsValid)
            {
                // cretae record in database 
                var RegionDomain = new RegionModel
                {
                    //Id =  Guid.NewGuid(),
                    Name = regionToAdd.Name,
                    RegionImageUrl = regionToAdd.RegionImageUrl,
                    Code = regionToAdd.Code,
                };

                await _regionRepository.Create(RegionDomain);



                // map the result to DTO Model to display to client

                var RegionDto = new RegionDTO
                {
                    Id = RegionDomain.Id,
                    Name = RegionDomain.Name,
                    Code = RegionDomain.Code,
                    RegionImageUrl = RegionDomain.RegionImageUrl,
                };
                return CreatedAtAction(nameof(GetById), new { id = RegionDomain.Id }, RegionDto);
            }

          else 
            { 
                return BadRequest(); 
            }


        }




        [HttpPut]
        [Route("/Update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id , RegionUpdateDto regionupdatedto) 
        


        {
            var RegionDomainRecord = new RegionModel 
            {
             Code = regionupdatedto.Code,
             RegionImageUrl = regionupdatedto.RegionImageUrl,
             Name = regionupdatedto.Name,
            };

            await _regionRepository.Update(id, RegionDomainRecord);

             if (RegionDomainRecord == null)
            {
                return NotFound();
            }


             // Update the domain model to DTO model 

            RegionDomainRecord.Name = regionupdatedto.Name;
            RegionDomainRecord.Code = regionupdatedto.Code;
            RegionDomainRecord.RegionImageUrl = regionupdatedto.RegionImageUrl;




            var RegionDTO = new RegionDTO 
            {
            Id = id,
            Name = RegionDomainRecord.Name,
            Code= RegionDomainRecord.Code,
            RegionImageUrl= RegionDomainRecord.RegionImageUrl,
            };

            return Ok(RegionDTO);
                
        }


        [HttpDelete]
        [Route("/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            // get the recored from database 
            var regionDomain = await _regionRepository.Delete(id);
            return Ok($"Record with id {regionDomain.Id} Deleted");

        }


    }
}
