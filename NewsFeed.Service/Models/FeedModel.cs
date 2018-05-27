using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Service.Models
{
    public class FeedModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public string ThumbnailUrl { get; set; }
        public DateTime? PubDate { get; set; }
    }
}