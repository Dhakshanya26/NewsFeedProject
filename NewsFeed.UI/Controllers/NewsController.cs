using NewsFeed.UI.IManager;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsFeed.UI.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsFeedManager _newFeedManager;    

        /// <summary>
        /// Intialize
        /// </summary>
        /// <param name="newFeedManager"></param>
        public NewsController(INewsFeedManager newFeedManager)
        {
            _newFeedManager = newFeedManager;
        }

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult>  Index()
        {
            var rssFeeds = await _newFeedManager.GetRssFeeds();
            return View(rssFeeds);
        }

    }
 
}