using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsFeed.Service.Controllers;
using NewsFeed.Service.Enums;
using NewsFeed.Service.IServices;
using NewsFeed.Service.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Service.Tests.UnitTest
{
    [TestClass]
    public class BbcFeedControllerTest
    {
        [TestMethod]
        public void WhenValidRssCallInvoked_ReturnSuccessResponse()
        {
            var mockFeedService = new Mock<IFeedService>();
            mockFeedService.Setup(m => m.GetRssFeed()).Returns(TestDataGenerator.CreateFakeSuccessFeedResponse());
            var bbcFeedController = new BbcFeedController(mockFeedService.Object);

            //Act
            var response = bbcFeedController.GetRssFeed();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }

        [TestMethod]
        public void WhenInValidRssCallInvoked_ReturnFailureResponse()
        {
            var mockFeedService = new Mock<IFeedService>();
            mockFeedService.Setup(m => m.GetRssFeed()).Returns(TestDataGenerator.CreateFakeFailureFeedResponse());
            var bbcFeedController = new BbcFeedController(mockFeedService.Object);

            //Act
            var response = bbcFeedController.GetRssFeed();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count <= 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Fail);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void WhenExceptionOccuredOnRssCall_ThrowException()
        {
            var mockFeedService = new Mock<IFeedService>();
            mockFeedService.Setup(m => m.GetRssFeed()).Throws(new NullReferenceException());
            var bbcFeedController = new BbcFeedController(mockFeedService.Object);

            //Act
            var response = bbcFeedController.GetRssFeed();

        }
    }
}
