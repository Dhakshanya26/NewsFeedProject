using NewsFeed.UI.Models;
using System;
using System.Collections.Generic;

namespace NewsFeed.UI.Tests.SetUp
{
    public static class TestDataGenerator
    {
        #region Dummy Data
        public static RssFeedViewModel CreateFakeSuccessRssFeedModel()
        {
            return new RssFeedViewModel()
            {
                Feeds = new List<FeedViewModel>() {
                        new FeedViewModel(){
                            Link="https://test1.com",
                            Title="Test 1",
                            Description="Testing this",
                            PubDate= DateTime.Now,
                            ThumbnailUrl="https://fakeurl.com"
                        }
                    },
                Result = new ResultViewModel()
                {
                    ResultStatus = ResultStatus.Success
                }
            };

        }

        public static RssFeedViewModel CreateFakeFailureRssFeedModel()
        {
            return new RssFeedViewModel()
            {
                Result = new ResultViewModel()
                {
                    ResultStatus = ResultStatus.Fail,
                    ResultMessage = "Unexpected error occurred"
                }
            };
        }

        public static RssFeedViewModel CreateFakeErrorRssFeedModel()
        {
            return new RssFeedViewModel()
            {
                Result = new ResultViewModel()
                {
                    ResultStatus = ResultStatus.Error,
                    ResultMessage = "Unexpected error occurred"
                }
            };

        }

        #endregion
    }
}
