using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkes.API.Models;
using NZWalkes.API.Models.DTOs;
using NZWalkes.API.Repositers;
using System.Drawing.Drawing2D;

namespace NZWalkes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IWalksRpositery _walkRepository;
        public WalksController(IRegionRepository regionRepository, IWalksRpositery walkRepository)
        {

            _regionRepository = regionRepository;
            _walkRepository = walkRepository;
        }


        [HttpGet]
        [Route("/GetWalks")]
        public async Task<IActionResult> Get()
        { 

         var walks = await _walkRepository.GetAllAsync();
            return Ok(walks);
        }


        [HttpPost]
        [Route("/CreateWalk")]
        public async Task<IActionResult> Create([FromBody] Walk walk)
        {
            await _walkRepository.Create(walk);
            return CreatedAtAction(nameof(GetById), new { id = walk.Id }, walk);
        }

        [HttpGet]
        [Route("/GetWalkById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var record = await _walkRepository.GetByID(id);

            return Ok(record);
        }


        [HttpPut]
        [Route("/UpdateWalk/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, Walk walk)
        {

            await _walkRepository.Update(id, walk);
            return Ok(walk);

        }

        [HttpDelete]
        [Route("/DeleteWalk/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _walkRepository.Delete(id);
            return Ok($"Item with Id {id} was deleted ");
        }
    }
}
