using NewsFeed.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NewsFeed.UI.IManager
{
    public interface IHttpClientManager: IDisposable
    {
        Task<RssFeedViewModel> GetRssFeeds();
    }
}