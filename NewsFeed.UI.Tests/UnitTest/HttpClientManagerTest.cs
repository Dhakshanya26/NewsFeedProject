using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class HttpClientManagerTest
    {

        #region test GetRssFeeds


        /// <summary>
        /// The Get rss method should return success result when the web api service exists.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WhenValidUrlPassed_ToRssFeedWebApi_ReturnSuccessResultWithFeeds()
        {
            //Arrage
            var rssFeed = JsonConvert.SerializeObject(TestDataGenerator.CreateFakeSuccessRssFeedModel());

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(rssFeed, System.Text.Encoding.UTF8, "application/json"),
            };
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetRssFeeds();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count > 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Success);
        }


        /// <summary>
        /// The Get rss method should return fail result if the web api service has any issue.
        /// </summary>
        /// <returns></returns> 
        [TestMethod]
        public async Task WhenInValidUrlPassed_ToRssFeedWebApi_ReturnFailResultWithoutFeeds()
        {
            //Arrage
            var rssFeed = JsonConvert.SerializeObject(TestDataGenerator.CreateFakeErrorRssFeedModel());

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(rssFeed, System.Text.Encoding.UTF8, "application/json"),
            };
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetRssFeeds();

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
        public async Task WhenAnyExceptionThrown_InRssFeedWebApi_ReturnErrorResultWithoutFeeds()
        {
            //Arrage
            var messageHandler = new FakeHttpMessageHandler(null);
            var _httpClientManager = new HttpClientManager(messageHandler);

            //Act
            var response = await _httpClientManager.GetRssFeeds();

            // Assert
            Assert.IsTrue(response != null && response.Feeds != null);
            Assert.IsTrue(response.Feeds.Count <= 0);
            Assert.IsTrue(response.Result != null && response.Result.ResultStatus == ResultStatus.Error);
        }


        #endregion

         
    }

}
