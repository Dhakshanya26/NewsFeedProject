using NewsFeed.Service.Enums;
using System.Collections.Generic;

namespace NewsFeed.Service.Models
{
    public class FeedResponse
    {
        public List<FeedModel> Feeds { get; set; }

        public ResultModel Result { get; set; }

        public FeedResponse(List<FeedModel> feedModels)
        {
            Feeds = feedModels;
            Result = new ResultModel(ResultStatus.Success);
        }
        public FeedResponse(ResultModel result)
        {
            Result = result;
            Feeds = null;
        }
    }
}