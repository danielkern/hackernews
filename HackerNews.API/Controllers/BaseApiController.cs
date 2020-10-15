using Microsoft.AspNetCore.Mvc;

namespace HackerNews.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {

        #region [Private/Protected properties]
       
        protected string _apiVersion = "v0";

        #endregion [Private/Protected properties]

        public BaseApiController()
        {
            
        }
    }
}
