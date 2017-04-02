using Microsoft.AspNetCore.Mvc;
using Conferency.Data;
using System.Collections.Generic;
using Conferency.Domain;

namespace Conferency.Application.Controllers
{
    [Route("api/[controller]")]
    public class ConferencesController : Controller
    {
        private IConferenceRepository _repo;

        public ConferencesController(IConferenceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Conference> conferences = _repo.GetAllConferences();
                return Ok(conferences);
            }
            catch { }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {   
            try
            {
                Conference conference = _repo.GetConference(id);

                if (conference == null) return NotFound($"Conference {id} was not found");

                return Ok(conference);
            }
            catch { }

            return BadRequest();
        }
    }
}
