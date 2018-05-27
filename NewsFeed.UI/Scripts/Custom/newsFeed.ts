
/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../typings/knockout.validation/knockout.validation.d.ts" />

class NewsFeedModel {

    feedModel: FeedModel[];
    showAll: KnockoutObservable<boolean>;
    showLoadingIcon: KnockoutObservable<boolean>;
    constructor(model: any) {
        this.feedModel = [];
        this.mapFeedModel(model);
        this.showLoadingIcon = ko.observable(false);
        this.showAll = ko.observable(false);
    }
    LoadRssFeed = (data, event) => {
        var self = this;
        $('#myModal').modal('show');
        this.showLoadingIcon(true);
        $('.modal-title').html(data.title);
        var iframe : any = $('#my-iframe')[0],
            iframedoc = iframe.contentDocument || iframe.contentWindow.document;
        var url = $(this).attr('url');
        iframedoc.body.innerHTML = "";
        $.get(data.link, function (response) {
            iframedoc.body.innerHTML = response;
            self.showLoadingIcon(false);
        });
    }
    LoadAll = () => {
        this.showAll(true);
    }

    mapFeedModel = (model) => {
        ko.utils.arrayMap(model, (item: any) => {
            this.feedModel.push(new FeedModel(item.Title, "https://cors.now.sh/" + item.Link, item.ThumbnailUrl, item.Description, item.PubDate));
        })
    }
}

class NewsArticleModel {
    constructor(externalUrl: string) {
        var iframe: any = $('#my-iframe')[0],
            iframedoc = iframe.contentDocument || iframe.contentWindow.document;
        iframedoc.body.innerHTML = "";
        $.get(externalUrl, function (response) {
            iframedoc.body.innerHTML = response;
        });
    }

}
class FeedModel {
    constructor(public title: string, public link: string, public imageUrl: string, public description: string, public pubDate: Date) {
    }
}