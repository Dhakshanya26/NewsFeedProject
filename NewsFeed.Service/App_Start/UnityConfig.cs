using log4net;
using NewsFeed.Service.IServices;
using NewsFeed.Service.Services;
using Unity;
using Unity.Injection;

namespace NewsFeed.Service
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IWebClientService, WebClientService>();
            container.RegisterType<IFeedService, FeedService>(new InjectionConstructor(new ResolvedParameter<IWebClientService>()));

            return container;
        }
    }
}