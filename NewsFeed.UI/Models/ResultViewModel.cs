
namespace NewsFeed.UI.Models
{
    public class ResultViewModel
    {
        public ResultStatus ResultStatus { get; set; }

        public string ResultMessage { get; set; }
    }

    public enum ResultStatus{
        Success=0,
        Fail=1,
        Error =2
    }
}