/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../typings/knockout.validation/knockout.validation.d.ts" />
var NewsFeedModel = (function () {
    function NewsFeedModel(model) {
        var _this = this;
        this.LoadRssFeed = function (data, event) {
            var self = _this;
            $('#myModal').modal('show');
            _this.showLoadingIcon(true);
            $('.modal-title').html(data.title);
            var iframe = $('#my-iframe')[0], iframedoc = iframe.contentDocument || iframe.contentWindow.document;
            var url = $(_this).attr('url');
            iframedoc.body.innerHTML = "";
            $.get(data.link, function (response) {
                iframedoc.body.innerHTML = response;
                self.showLoadingIcon(false);
            });
        };
        this.LoadAll = function () {
            _this.showAll(true);
        };
        this.mapFeedModel = function (model) {
            ko.utils.arrayMap(model, function (item) {
                _this.feedModel.push(new FeedModel(item.Title, "https://cors.now.sh/" + item.Link, item.ThumbnailUrl, item.Description, item.PubDate));
            });
        };
        this.feedModel = [];
        this.mapFeedModel(model);
        this.showLoadingIcon = ko.observable(false);
        this.showAll = ko.observable(false);
    }
    return NewsFeedModel;
}());
var NewsArticleModel = (function () {
    function NewsArticleModel(externalUrl) {
        var iframe = $('#my-iframe')[0], iframedoc = iframe.contentDocument || iframe.contentWindow.document;
        iframedoc.body.innerHTML = "";
        $.get(externalUrl, function (response) {
            iframedoc.body.innerHTML = response;
        });
    }
    return NewsArticleModel;
}());
var FeedModel = (function () {
    function FeedModel(title, link, imageUrl, description, pubDate) {
        this.title = title;
        this.link = link;
        this.imageUrl = imageUrl;
        this.description = description;
        this.pubDate = pubDate;
    }
    return FeedModel;
}());
//# sourceMappingURL=newsFeed.js.map