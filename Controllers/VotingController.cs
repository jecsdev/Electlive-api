﻿using ElectLive_API.Data.Model;
using ElectLive_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ElectLive_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VotingController : Controller
        
    {   /// This represents the private var for repository for whole project... maybe i would change it in the future, who knows...
        private readonly IElecLiveRepository _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">This represents the constructor repository var for whole project... maybe i would change it in the future, who knows...</param>

        public VotingController(IElecLiveRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Represents the id from Voting class</param>
        /// <returns></returns>

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Voting>> GetVoting(int id)
        {
            try
            {
                var result = await _repository.GetVoting(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voting"> Is the class Model</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Voting>> CreateVoting([FromBody] Voting voting)
        {
            try
            {
                if(voting == null)
                {
                    return BadRequest();
                }

                var createdVoting = await _repository.AddVoting(voting);
                return CreatedAtAction(nameof(GetVoting), new { id = createdVoting.Id }, createdVoting);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, ex.Message);
            }
        }
    }
}