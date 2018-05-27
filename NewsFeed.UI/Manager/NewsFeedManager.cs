using log4net;
using NewsFeed.UI.IManager;
using NewsFeed.UI.Models;
using System;
using System.Threading.Tasks;

namespace NewsFeed.UI.Manager
{
    public class NewsFeedManager : INewsFeedManager
    {
        private readonly IHttpClientManager _httpClientManager;

        /// <summary>
        /// Intialize
        /// </summary>
        /// <param name="httpClientManager"></param>
        public NewsFeedManager(IHttpClientManager httpClientManager)
        {
            _httpClientManager = httpClientManager;
        }

        /// <summary>
        /// Get rss feed async.
        /// </summary>
        /// <returns></returns>
        public async Task<RssFeedViewModel> GetRssFeeds()
        {
            try
            {
                var feedList = await _httpClientManager.GetRssFeeds();
                return feedList;
            }
            catch (Exception ex)
            {
                LogManager.Error($"Unexpected error occured on calling GetRssFeeds in NewsFeedManager",ex);
                return new RssFeedViewModel()
                {
                    Result = new ResultViewModel()
                    {
                        ResultStatus = ResultStatus.Error,
                        ResultMessage = "Unexpected error occured on calling GetRssFeeds in NewsFeedManagerr"
                    }
                };
            }
        }


        /// <summary>
        /// Dispose all objects
        /// </summary>
        public void Dispose()
        {
            _httpClientManager.Dispose();
        }
    }
}