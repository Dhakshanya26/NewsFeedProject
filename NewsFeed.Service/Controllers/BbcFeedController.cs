using NewsFeed.Service.IServices;
using NewsFeed.Service.Models;
using System.Web.Http;

namespace NewsFeed.Service.Controllers
{
    public class BbcFeedController : ApiController
    {
        private readonly IFeedService _feedService;
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="feedService"></param>
        public BbcFeedController(IFeedService feedService)
        {
            _feedService = feedService;
        }


        /// <summary>
        /// Get rss feed from the bbc news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FeedResponse GetRssFeed()
        {
                return _feedService.GetRssFeed();
        }       
    }
}
