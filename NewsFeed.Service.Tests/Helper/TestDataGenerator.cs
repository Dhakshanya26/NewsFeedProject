using NewsFeed.Service.Enums;
using NewsFeed.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewsFeed.Service.Tests.Helper
{
    public static class TestDataGenerator
    {
        public static string GetValidDownloadstring()
        {
            return @"<?xml version='1.0' encoding='UTF-8'?>
<?xml-stylesheet title='XSL_formatting' type='text/xsl' href='/shared/bsp/xsl/rss/nolsol.xsl'?>
<rss xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>
    <channel>
        <title><![CDATA[BBC News - UK]]></title>
        <description><![CDATA[BBC News - UK]]></description>
        <link>http://www.bbc.co.uk/news/</link>
        <image>
            <url>http://news.bbcimg.co.uk/nol/shared/img/bbc_news_120x60.gif</url>
            <title>BBC News - UK</title>
            <link>http://www.bbc.co.uk/news/</link>
        </image>
        <generator>RSS for Node</generator>
        <lastBuildDate>Sun, 27 May 2018 00:52:23 GMT</lastBuildDate>
        <copyright><![CDATA[Copyright: (C) British Broadcasting Corporation, see http://news.bbc.co.uk/2/hi/help/rss/4498287.stm for terms and conditions of reuse.]]></copyright>
        <language><![CDATA[en-gb]]></language>
        <ttl>15</ttl>
        <item>
            <title><![CDATA[England could get new national parks as Gove launches review]]></title>
            <description><![CDATA[Environment Secretary Michael Gove launches a review of the country's protected landscapes.]]></description>
            <link>http://www.bbc.co.uk/news/uk-politics-44268724</link>
            <guid isPermaLink='true'>http://www.bbc.co.uk/news/uk-politics-44268724</guid>
            <pubDate>Sun, 27 May 2018 00:20:36 GMT</pubDate>
            <media:thumbnail width='976' height='549' url='http://c.files.bbci.co.uk/17990/production/_101765669_gettyimages-804644304.jpg'/>
        </item>
    </channel>
</rss>";
        }

        public static string GetInValidDownloadstring()
        {
            return @"<?xml version='1.0' encoding='UTF-8'?>
<?xml-stylesheet title='XSL_formatting' type='text/xsl' href='/shared/bsp/xsl/rss/nolsol.xsl'?>
<rss xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>
    <channel>
        <title><![CDATA[BBC News - UK]]></title>
        <description><![CDATA[BBC News - UK]]></description>
        <link>http://www.bbc.co.uk/news/</link>
        <image>
            <url>http://news.bbcimg.co.uk/nol/shared/img/bbc_news_120x60.gif</url>
            <title>BBC News - UK</title>
            <link>http://www.bbc.co.uk/news/</link>
        </image>
        <generator>RSS for Node</generator>
        <lastBuildDate>Sun, 27 May 2018 00:52:23 GMT</lastBuildDate>
        <copyright><![CDATA[Copyright: (C) British Broadcasting Corporation, see http://news.bbc.co.uk/2/hi/help/rss/4498287.stm for terms and conditions of reuse.]]></copyright>
        <language><![CDATA[en-gb]]></language>
        <ttl>15</ttl>
        <item>
            <title></title>
            <description>></description>
        </item>
    </channel>
</rss>";
        }

        public static FeedResponse CreateFakeSuccessFeedResponse()
        {
            var feeds = new List<FeedModel>() {
                        new FeedModel(){
                            Link="https://test1.com",
                            Title="Test 1",
                            Description="Testing this",
                            PubDate= DateTime.Now,
                            ThumbnailUrl="https://fakeurl.com"
                        }
                    };
            return new FeedResponse(feeds)
            {
                Result = new ResultModel()
                {
                    ResultStatus = ResultStatus.Success
                }
            };

        }

        public static FeedResponse CreateFakeFailureFeedResponse()
        {
            return new FeedResponse(new List<FeedModel>())
            {
                Result = new ResultModel()
                {
                    ResultStatus = ResultStatus.Fail,
                    ResultMessage = "Unexpected error occurred"
                }
            };
        }

        public static FeedResponse CreateFakeErrorFeedResponse()
        {
            return new FeedResponse(new List<FeedModel>())
            {
                Result = new ResultModel()
                {
                    ResultStatus = ResultStatus.Error,
                    ResultMessage = "Unexpected error occurred"
                }
            };

        }

    }
}
