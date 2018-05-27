using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.UI.Models
{
    public class FeedViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime? PubDate { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}