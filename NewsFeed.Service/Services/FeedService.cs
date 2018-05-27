using NewsFeed.Service.Enums;
using NewsFeed.Service.Helper;
using NewsFeed.Service.IServices;
using NewsFeed.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace NewsFeed.Service.Services
{
    public class FeedService : IFeedService
    {
        private readonly IWebClientService _webClientService;
        /// <summary>
        /// initialize
        /// </summary>
        public FeedService(IWebClientService webClientService)
        {
            _webClientService = webClientService;
        }

        /// <summary>
        /// Get rss feed from the bbc news
        /// </summary>
        /// <returns></returns>
        public FeedResponse GetRssFeed()
        {
            try
            {
                var feeds = new List<FeedModel>();
                var RSSData = _webClientService.DownloadString(System.Configuration.ConfigurationManager.AppSettings["Feed.Root"]);
                XDocument xml = XDocument.Parse(RSSData);
                var media = XNamespace.Get(System.Configuration.ConfigurationManager.AppSettings["Feed.Root.Media"]); ;

                feeds = (from x in xml.Descendants("item")
                         select new FeedModel()
                         {
                             Title = x.Element("title") != null ? ((string)x.Element("title")) : string.Empty,
                             Link = x.Element("link") != null ? ((string)x.Element("link")) : string.Empty,
                             Description = x.Element("description") != null ? ((string)x.Element("description")) : string.Empty,
                             PubDate = x.Element("pubDate") != null ? DateTime.Parse(((string)x.Element("pubDate"))) : default(DateTime?),
                             ThumbnailUrl = x.Element(media + "thumbnail") != null ? x.Element(media + "thumbnail").Attribute("url").Value : string.Empty
                         })?.OrderByDescending(x => x.PubDate).ToList();
                return new FeedResponse(feeds);
            }

            catch (Exception ex)
            {
                LogManager.Error($"Unexpected error occured on calling GetRssFeed in Feedservice", ex);
                return new FeedResponse(new ResultModel(ResultStatus.Error, ex.Message));
            }
        }


        /// <summary>
        /// Dispose objects if any.
        /// </summary>
        public void Dispose()
        {
            _webClientService.Dispose();
        }

    }
}