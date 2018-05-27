using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsFeed.UI.IManager;
using NewsFeed.UI.Manager;
using NewsFeed.UI.Models;
using NewsFeed.UI.Tests.SetUp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsFeed.UI.Tests.UnitTest
{
    [TestClass]
    public class NewsFeedManagerTest
    {

        #region test GetRssFeeds


        /// <summary>
        /// The Get rss method should return success result if no issue.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WhenSuccessfulHttpClientInvoked_ShouldReturn_SuccessResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            mockHttpClientManager.Setup(m => m.GetRssFeeds()).Returns(Task.FromResult(TestDataGenerator.CreateFakeSuccessRssFeedModel()));
            var newsFeedManager = new NewsFeedManager(mockHttpClientManager.Object);

            //Act
            var response = await newsFeedManager.GetRssFeeds();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }


        /// <summary>
        /// The Get rss method should return fail result if the httpclient request has any issue.
        /// </summary>
        /// <returns></returns> 
        [TestMethod]
        public async Task WhenHttpClientInvokedIsNotOk_ShouldReturn_FailureResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            mockHttpClientManager.Setup(m => m.GetRssFeeds()).Returns(Task.FromResult(TestDataGenerator.CreateFakeFailureRssFeedModel()));
            var newsFeedManager = new NewsFeedManager(mockHttpClientManager.Object);

            //Act
            var response = await newsFeedManager.GetRssFeeds();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count <= 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Fail);
        }

        /// <summary>
        /// The Get rss method should return error result if any exception occurs.
        /// </summary>
        /// <returns></returns> 
        [TestMethod]
        public async Task WhenHttpClientThrowsAnyError_ShouldReturn_ErrorResult()
        {
            //Arrage
            var mockHttpClientManager = new Mock<IHttpClientManager>();
            var newsFeedManager = new NewsFeedManager(null);

            //Act
            var response = await newsFeedManager.GetRssFeeds();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count <= 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Error);
        }

        #endregion


    }

}
