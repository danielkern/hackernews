using System;

namespace HackerNews.Service.Interfaces
{
    public interface ICacheManager
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItem, DateTimeOffset endDate);

        //TODO: expose to API endpoint so it can be cleared.
        void ClearCacheITem(string cacheKey);
    }
}
