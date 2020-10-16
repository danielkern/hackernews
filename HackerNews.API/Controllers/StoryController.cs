using HackerNews.Data;
using HackerNews.Data.Enums;
using HackerNews.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HackerNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : BaseApiController
    {

        #region [Private/Protected properties]

        private IStoryService _storyService;

        #endregion [Private/Protected properties]


        public StoryController(IStoryService storyService) : base()
        {
            _storyService = storyService;
        }

        // GET api/story
        [HttpGet]
        public ActionResult<IEnumerable<Story>> Get([FromQuery] EndpointType storyType = EndpointType.NewStories, [FromQuery] int lastItemId = 0, [FromQuery] int size = 50)
        {
            try
            {
                var stories = _storyService.GetStories(_apiVersion, storyType, lastItemId, size).Result;
                return Ok(stories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/story/5
        [HttpGet("search")]
        public ActionResult<string> Search([FromQuery] string query)
        {
            return "value";
        }

        // GET api/story/5
        [HttpGet("{id}")]
        public ActionResult<Story> Get(int id)
        {
            return _storyService.GetById(id, _apiVersion).Result;
        }

        // POST api/story
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/story/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/story/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
