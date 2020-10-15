using HackerNews.Service.Interfaces;

namespace HackerNews.Service
{
    public abstract class BaseService
    {

        #region [Private/Protected properties]

        protected readonly ICacheManager _cacheManager;

        #endregion [Private/Protected properties]

        public BaseService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
    }
}
