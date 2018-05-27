using NewsFeed.Service.IServices;
using System.Net;

namespace NewsFeed.Service.Services
{

    /// <summary>
    /// Web Client
    /// </summary>
    public class WebClientService : IWebClientService
    {
        private  WebClient _webClient = new  WebClient();

        /// <summary>
        /// Download string
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string DownloadString(string uri)
        {
            return _webClient.DownloadString(uri);
        }


        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            _webClient = null; 
        }

    }
}