using HackerNews.Data;
using HackerNews.Data.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Service.Interfaces
{
    public interface IStoryService
    {
        Task<IList<Story>> GetStories(string apiVersion = "v0", EndpointType endpointType = EndpointType.NewStories, int lastItemId = 0, int pageSize = 10);

        Task<IList<int>> GetStoryIdList(string apiVersion = "v0", EndpointType endpointType = EndpointType.NewStories);

        Task<Story> GetById(int id, string apiVersion = "v0");

        Task<IList<Story>> Search(string query);

        Story Post(Story story);

        bool Put(Story story);

        bool DeleteById(int id);
    }
}
