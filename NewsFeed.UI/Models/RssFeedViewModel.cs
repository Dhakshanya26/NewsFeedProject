using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.UI.Models
{
    public class RssFeedViewModel
    {
        public List<FeedViewModel> Feeds { get; set; }
        public ResultViewModel Result { get; set; }

        public RssFeedViewModel() : this(new List<FeedViewModel>())
        {
        }
        public RssFeedViewModel(List<FeedViewModel> feeds)
        {
            Feeds = feeds;
        }
    }
}