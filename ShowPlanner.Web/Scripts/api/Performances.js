/// <reference path="~/Scripts/PubSub.js"/>
/// <reference path="~/Scripts/api/Server.js" />
/// 
(function ($) {
    "use strict";

    $.extend(true, window, {
        ShowPlanner: {
            api: {
                Performances: Performances
            }
        }
    });

    function Performances(options) {
        // settings
        var self = this;
        var defaults = {};
        var settings = $.extend({}, defaults, options);

        var server = options.server || new ShowPlanner.api.Server(options);

        Performances.prototype.query = function (jsonRequest, successHandler) {
            server.post(settings.queryUrl, jsonRequest, successHandler);
        };

        return self;
    }

})(jQuery);