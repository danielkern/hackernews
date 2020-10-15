using HackerNews.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace HackerNews.Service
{
    public class CacheManager : ICacheManager
    {
        #region [Private/Protected properties]

        private readonly IMemoryCache _memCache;

        #endregion [Private/Protected properties]

        public CacheManager(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getItem, DateTimeOffset endDate)
        {
            var item = _memCache.Get<T>(cacheKey);
            if (item == null)
            {
                item = getItem();
                _memCache.Set(cacheKey, item, endDate);
            }
            return item;
        }

        public void ClearCacheITem(string cacheKey) {
            _memCache.Remove(cacheKey);
        }
    }
}
