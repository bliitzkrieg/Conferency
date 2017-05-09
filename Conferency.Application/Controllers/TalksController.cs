using Microsoft.AspNetCore.Mvc;
using Conferency.Data;
using System.Collections.Generic;
using Conferency.Domain;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace Conferency.Application.Controllers
{
    [Route("api/[controller]")]
    public class TalksController : Controller
    {
        private ITalkRepository _repo;
        private ILogger<TalksController> _logger;

        public TalksController(ITalkRepository repo, ILogger<TalksController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                _logger.LogInformation($"Getting all Talks");

                IEnumerable<Talk> talks = _repo.GetAllTalks();
                return Ok(talks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting all Talks: {ex}");
            }

            return BadRequest();
        }

        [HttpGet("{id}", Name = "TalkGet")]
        public ActionResult Get(int id)
        {   
            try
            {
                _logger.LogInformation($"Getting a Talk with Id of {id}");

                Talk talk = _repo.GetTalk(id);

                if (talk == null) return NotFound($"Talk {id} was not found");

                return Ok(talk);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Threw exception while getting Talk with id of {id} : {ex}");
            }

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]Talk model)
        {
            try
            {
                _logger.LogInformation("Creating a new Talk");

                _repo.Add(model);
                if (await _repo.SaveAllAsync())
                {
                    string newUri = Url.Link("TalkGet", new { id = model.Id });
                    return Created(newUri, model);
                }
                else
                {
                    _logger.LogWarning("Could not save Talk");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving Talk: {ex}");
            }

            return BadRequest();
        }
    }
}
