using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsFeed.Service.Enums;
using NewsFeed.Service.IServices;
using NewsFeed.Service.Services;
using NewsFeed.Service.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Service.Tests.UnitTest
{
    [TestClass]
    public class FeedServiceTest
    {

        #region test GetRssFeed

        [TestMethod]
        public void WhenRssFeedCallSuccess_ShouldReturnSuccessResponseWithFeeds()
        {
            //Arrage
            var mockWebClientService = new Mock<IWebClientService>();
            mockWebClientService.Setup(m => m.DownloadString(It.IsAny<string>())).Returns(TestDataGenerator.GetValidDownloadstring());
            var feedService = new FeedService(mockWebClientService.Object);

            //Act
            var response = feedService.GetRssFeed();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public void WhenInvalidDataReturnedFromRssFeedCall_ShouldHandleNullCheckAndReturnSuccessResultWithEmptyFeedData()
        {
            //Arrage
            var mockWebClientService = new Mock<IWebClientService>();
            mockWebClientService.Setup(m => m.DownloadString(It.IsAny<string>())).Returns(TestDataGenerator.GetInValidDownloadstring());
            var feedService = new FeedService(mockWebClientService.Object);

            //Act
            var response = feedService.GetRssFeed();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null );
            Assert.IsTrue(response.Feeds.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public void WhenAnyExceptionOccurs_OnRssFeedCall_ShouldReturnErrorResponseWithoutFeeds()
        {
            //Arrage
            var mockWebClientService = new Mock<IWebClientService>();
            mockWebClientService.Setup(m => m.DownloadString(It.IsAny<string>())).Returns(string.Empty);
            var feedService = new FeedService(mockWebClientService.Object);

            //Act
            var response = feedService.GetRssFeed();

            // Assert
            Assert.IsTrue(response != null && response.Feeds == null);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Error);
        }
         
        #endregion

    }
}
