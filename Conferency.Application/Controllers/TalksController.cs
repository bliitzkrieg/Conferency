using Microsoft.AspNetCore.Mvc;
using Conferency.Data;
using System.Collections.Generic;
using Conferency.Domain;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using Conferency.Application.Models;

namespace Conferency.Application.Controllers
{
    [Route("api/[controller]")]
    public class TalksController : Controller
    {
        private ITalkRepository _repo;
        private ILogger<TalksController> _logger;
        private ITagRepository _tagRepo;

        public TalksController(ITalkRepository repo, ILogger<TalksController> logger, ITagRepository tagRepo)
        {
            _repo = repo;
            _logger = logger;
            _tagRepo = tagRepo;
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
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting Talk with id of {id} : {ex}");
            }

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]TalkViewModel model)
        {
            try
            {
                _logger.LogInformation("Creating a new Talk");

                List<Tag> tags = _tagRepo.FindOrCreateTags(model.Tags);

                Talk talk = new Talk { Name = model.Name, Url = model.Url };

                List<TalkTag> talkTags = new List<TalkTag>();
                tags.ForEach(tag =>
                {
                    var talkTag = new TalkTag
                    {
                        TagId = tag.Id,
                        Talk = talk
                    };

                    _repo.Add(talkTag);
                    talkTags.Add(talkTag);
                });

                if (await _repo.SaveAllAsync())
                {
                    string newUri = Url.Link("TalkGet", new { id = talk.Id });
                    return Created(newUri, talk);
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
