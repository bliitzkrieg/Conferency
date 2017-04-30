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
    public class ConferencesController : Controller
    {
        private IConferenceRepository _repo;
        private ILogger<ConferencesController> _logger;

        public ConferencesController(IConferenceRepository repo, ILogger<ConferencesController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                _logger.LogInformation($"Getting all Conferences");

                IEnumerable<Conference> conferences = _repo.GetAllConferences();
                return Ok(conferences);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting all Conferences: {ex}");
            }

            return BadRequest();
        }

        [HttpGet("{id}", Name = "ConferenceGet")]
        public ActionResult Get(int id)
        {   
            try
            {
                _logger.LogInformation($"Getting a Conference with Id of {id}");

                Conference conference = _repo.GetConference(id);

                if (conference == null) return NotFound($"Conference {id} was not found");

                return Ok(conference);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Threw exception while getting Conference with id of {id} : {ex}");
            }

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]Conference model)
        {
            try
            {
                _logger.LogInformation("Creating a new Conference");

                _repo.Add(model);
                if (await _repo.SaveAllAsync())
                {
                    string newUri = Url.Link("ConferenceGet", new { id = model.Id });
                    return Created(newUri, model);
                }
                else
                {
                    _logger.LogWarning("Could not save Conference");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving Conference: {ex}");
            }

            return BadRequest();
        }
    }
}
