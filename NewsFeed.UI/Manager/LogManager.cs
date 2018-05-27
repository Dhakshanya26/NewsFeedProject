using System;

namespace NewsFeed.UI.Manager
{
    public static class LogManager
    {
        public static log4net.ILog Log { get; set; }

        static LogManager()
        {
            Log = log4net.LogManager.GetLogger(typeof(LogManager));
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }

        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }
        public static void Error(Exception ex)
        {
            Log.Error(ex);
        }
        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}