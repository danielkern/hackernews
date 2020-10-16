using HackerNews.Data;
using HackerNews.Data.Enums;
using HackerNews.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.Service.Tests
{
    [TestClass]
    public class StoryServiceTest
    {
        private readonly IStoryService _storyService;
        private readonly CacheManager _cacheManager;
        private readonly Mock<IMemoryCache> _mockMemoryCache;
        private readonly Mock<ICacheManager> _mockCacheManager;
        private readonly Mock<IStoryService> _mockStoryService;

        public StoryServiceTest()
        {
            _mockCacheManager = new Mock<ICacheManager>();
            _mockMemoryCache = new Mock<IMemoryCache>();
            _cacheManager = new CacheManager(_mockMemoryCache.Object);
            _storyService = new StoryService(_cacheManager);
            _mockStoryService = new Mock<IStoryService>();
        }

        [TestMethod]
        public void ShouldGetStories()
        {
            IList<Story> expectedStories = new List<Story>() {
                new Story
                {
                    Id = 100,
                    Title = "Some cool story!"
                },
                new Story
                {
                    Id = 101,
                    Title = "Another great story!"
                }
            };

            _mockCacheManager.Setup(x=>x.GetOrSet(It.IsAny<string>(), It.IsAny<Func<IEnumerable<int>>>(), It.IsAny<DateTimeOffset>())).Returns(expectedStories.Select(s => s.Id).ToList());
            _mockCacheManager.Setup(x => x.GetOrSet(It.IsAny<string>(), It.IsAny<Func<IList<Story>>>(), It.IsAny<DateTimeOffset>())).Returns(expectedStories);
            StoryService storyService = new StoryService(_mockCacheManager.Object);
            IList<Story> result = storyService.GetStories("v0", EndpointType.NewStories, 0, 25).Result;

            Assert.AreEqual(result.First(), expectedStories.First());
            Assert.IsTrue(expectedStories.Count == 2);
        }

        [TestMethod]
        public void ShouldGetStoryById()
        {
            Story expectedStory = new Story
            {
                Id = 100,
                Title = "Some cool story!"
            };

            _mockStoryService.Setup(service => service.GetById(100, "v0")).Returns(Task.FromResult(expectedStory));

            Assert.AreEqual(_mockStoryService.Object.GetById(100, "v0").Result, expectedStory);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ShouldThrowNotImplementedException_DeleteById()
        {
            _storyService.DeleteById(5);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ShouldThrowNotImplementedException_Post()
        {
            _storyService.Post(new Story());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ShouldThrowNotImplementedException_Put()
        {
            _storyService.Put(new Story());
        }
    }
}
