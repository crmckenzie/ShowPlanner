/// <reference path="~/Scripts/PubSub.js"/>

(function ($) {
    "use strict";

    $.extend(true, window, {
        ShowPlanner: {
            api: {
                Server: Server
            }
        }
    });

    function Server(options) {
        // settings
        var self = this;
        var defaults = {};
        var settings = $.extend({}, defaults, options);


        return self;
    }


    Server.prototype.log = function (message) {
        if (console && console.log) {
            var formattedMessage = "" + new Date() + ": " + message;
            console.log(formattedMessage);
        }
    };

    // methods
    Server.prototype.post = function (url, data, success) {
        var self = this;
        self.log("Invoking url: " + url);

        var stringified = JSON.stringify(data);

        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            data: stringified,
            contentType: "application/json; charset=utf-8"
        })
            .success(function (response, jqXHR, ajaxOptions) {
                self.log("Call to " + url + " succeeded.");

                success(response, jqXHR, ajaxOptions);
            })
            .error(function (event, jqXHR, ajaxOptions, thrownError) {
                self.log("Call to " + url + " failed.");
                PubSub.publish(ShowPlanner.api.Messages.ApiException, event);
            });
    };

    Server.prototype.get = function (url, data, success) {
        var self = this;
        
        self.log("Invoking url: " + url);

        var stringified = JSON.stringify(data);

        $.ajax({
            data: data,
            url: url,
            type: "GET",
            dataType: "json",
        })
        .success(function (response, jqXHR, ajaxOptions) {
            self.log("Call to " + url + " succeeded.");
            success(response, jqXHR, ajaxOptions);
        })
        .error(function (event, jqXHR, ajaxOptions, thrownError) {
            self.log("Call to " + url + " failed.");
            PubSub.publish(ShowPlanner.api.Messages.ApiException, event);
        });
    };

})(jQuery);