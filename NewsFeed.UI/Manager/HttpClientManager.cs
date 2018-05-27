using log4net;
using NewsFeed.UI.IManager;
using NewsFeed.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NewsFeed.UI.Manager
{
    public class HttpClientManager : IHttpClientManager
    {
        private HttpMessageHandler _httpMessageHandler;

        /// <summary>
        /// Intialize
        /// </summary>
        public HttpClientManager(HttpMessageHandler httpMessageHandler)
        {
            _httpMessageHandler = httpMessageHandler;
        }


        /// <summary>
        /// Call rssfeed api
        /// </summary>
        /// <returns></returns>
        public async Task<RssFeedViewModel> GetRssFeeds()
        {
            try
            {
                var httpClient = new HttpClient(_httpMessageHandler);
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi.Url"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync(ConfigurationManager.AppSettings["WebApi.BBc.NewsFeed.Url"]);
                if (response.IsSuccessStatusCode)
                {
                    var details = response.Content.ReadAsAsync<RssFeedViewModel>().Result;
                    return details;
                }
                else
                {
                    LogManager.Info("Sorry, it looks like the Rss feed service is not working.");
                    return new RssFeedViewModel()
                    {
                        Result = new ResultViewModel()
                        {
                            ResultStatus = ResultStatus.Fail,
                            ResultMessage = "Sorry, it looks like the Rss feed service is not working."
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                LogManager.Error($"Unexpected error occured on calling GetRssFeeds in HttpClientManager", ex);
                return new RssFeedViewModel()
                {
                    Result = new ResultViewModel()
                    {
                        ResultStatus = ResultStatus.Error,
                        ResultMessage = $"Unexpected Error occured: {ex.Message}"
                    }
                };
            }
        }

        /// <summary>
        /// Dispose external objects if any
        /// </summary>
        public void Dispose()
        {
        }
    }
}