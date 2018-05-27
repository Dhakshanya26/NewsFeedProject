using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsFeed.UI.Controllers;
using NewsFeed.UI.IManager;
using NewsFeed.UI.Models;
using NewsFeed.UI.Tests.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsFeed.UI.Tests.UnitTest
{
    [TestClass]
    public class NewsControllerTest
    {

        /// <summary>
        /// Positive case
        /// </summary>
        [TestMethod]
        public async Task WhenValid_RssFeedCallInvoked_ReturnSuccessResult()
        {
            // Arrange
            var mockedNewsFeedManager = new Mock<INewsFeedManager>();
            NewsController newController = new NewsController(mockedNewsFeedManager.Object);
            mockedNewsFeedManager.Setup(m => m.GetRssFeeds()).Returns(Task.FromResult(TestDataGenerator.CreateFakeSuccessRssFeedModel()));

            // Act
            var result =await newController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model != null);
            var model = (RssFeedViewModel)result.Model;
            Assert.IsTrue(model != null && model.Feeds != null && model.Feeds.Count>0);
            Assert.IsTrue(model != null && model.Result != null && model.Result.ResultStatus == ResultStatus.Success);
        }

        /// <summary>
        /// Negative case
        /// </summary>
        [TestMethod]
        public async Task WhenInValid_RssFeedCallInvoked_ReturnFailureResult()
        {
            // Arrange
            var mockedNewsFeedManager = new Mock<INewsFeedManager>();
            NewsController newController = new NewsController(mockedNewsFeedManager.Object);
            mockedNewsFeedManager.Setup(m => m.GetRssFeeds()).Returns(Task.FromResult(TestDataGenerator.CreateFakeFailureRssFeedModel()));

            // Act
            var result = await newController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model != null);
            var model = (RssFeedViewModel)result.Model;
            Assert.IsTrue(model != null && model.Feeds != null && model.Feeds.Count <= 0);
            Assert.IsTrue(model != null && model.Result != null && model.Result.ResultStatus == ResultStatus.Fail);
        }

        /// <summary>
        /// Exception case
        /// </summary>
        [TestMethod]
        public async Task WhenExceptionOccuredOn_RssFeedCall_ReturnErrorResult()
        {
            // Arrange
            var mockedNewsFeedManager = new Mock<INewsFeedManager>();
            NewsController newController = new NewsController(mockedNewsFeedManager.Object);
            mockedNewsFeedManager.Setup(m => m.GetRssFeeds()).Returns(Task.FromResult(TestDataGenerator.CreateFakeErrorRssFeedModel()));

            // Act
            var result = await newController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model != null);
            var model = (RssFeedViewModel)result.Model;
            Assert.IsTrue(model != null && model.Feeds != null && model.Feeds.Count <= 0);
            Assert.IsTrue(model != null && model.Result != null && model.Result.ResultStatus== ResultStatus.Error);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public async Task WhenExceptionOccuredOnRssCall_ThrowException()
        {
            // Arrange
            var mockedNewsFeedManager = new Mock<INewsFeedManager>();
            NewsController newController = new NewsController(mockedNewsFeedManager.Object);
            mockedNewsFeedManager.Setup(m => m.GetRssFeeds()).Throws(new NullReferenceException());

            // Act
            var result = await newController.Index() as ViewResult;

        }
    }
}
