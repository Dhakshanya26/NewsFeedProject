using System;

namespace NewsFeed.Service.IServices
{
    public interface IWebClientService: IDisposable
    {
        string DownloadString(string uri);
    }
}