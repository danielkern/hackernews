using HackerNews.Data;
using HackerNews.Data.Enums;
using HackerNews.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.Service
{
    public class StoryService : BaseService, IStoryService
    {
        private const string _cacheKeyPrefix = "story";

        public StoryService(ICacheManager cacheManager): base(cacheManager)
        {
        }

        public async Task<IList<Story>> GetStories(string apiVersion = "v0", EndpointType endpointType = EndpointType.NewStories, int lastItemId = 0, int pageSize = 10) {

            IList<int> storyIds = _cacheManager.GetOrSet($"{_cacheKeyPrefix}_{endpointType}_{lastItemId}_id_list", 
                () => GetStoryIdList(apiVersion, endpointType).Result, 
                DateTime.Now.AddMinutes(1));

            IList<Story> stories = new List<Story>();

            IEnumerable<int> pagedStoryIds = lastItemId == 0 ? storyIds.Take(pageSize) : storyIds.Where(id => id < lastItemId).Take(pageSize);

            Parallel.ForEach(pagedStoryIds, async id => {
                Story story = await GetById(id, apiVersion);
                if (story != null)
                {
                    stories.Add(story);
                }
            });

            stories = _cacheManager.GetOrSet($"{_cacheKeyPrefix}_{endpointType}_{lastItemId}_stories",
                () => stories, 
                DateTime.Now.AddMinutes(1));

            return stories
                .Where(story => story.Dead == false && story.Deleted == false)
                .OrderByDescending(story => story.Time)
                .ToList();
        }

        public async Task<IList<int>> GetStoryIdList(string apiVersion = "v0", EndpointType endpointType = EndpointType.NewStories)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://hacker-news.firebaseio.com/{ apiVersion }/{ endpointType.ToDescription() }.json";
                response = client.GetAsync($"{url}").Result;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                IList<int> storyIds = JsonConvert.DeserializeObject<IList<int>>(jsonResponse);
                return storyIds;
            }
            else
            {
                throw new Exception($"The request failed with status code {response.StatusCode}");
            }
        }

        public async Task<Story> GetById(int id, string apiVersion = "v0")
        {
            HttpResponseMessage response;
            Story story = null;

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://hacker-news.firebaseio.com/{ apiVersion }/item/{ id }.json";
                response = client.GetAsync($"{url}").Result;
            }

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                story = JsonConvert.DeserializeObject<Story>(jsonResponse);
                return story;
            }
            else
            {
                return null;
            }
        }

        public Task<IList<Story>> Search(string query)
        {
            throw new NotImplementedException();
        }

        public Story Post(Story story)
        {
            throw new NotImplementedException();
        }

        public bool Put(Story story)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
