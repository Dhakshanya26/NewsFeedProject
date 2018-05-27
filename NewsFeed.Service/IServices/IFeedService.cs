using NewsFeed.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace NewsFeed.Service.IServices
{
    public interface IFeedService : IDisposable
    {
        FeedResponse GetRssFeed();        
    }
}