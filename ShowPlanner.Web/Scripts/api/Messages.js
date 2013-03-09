/// <reference path="~/Scripts/PubSub.js"/>
/// <reference path="~/Scripts/api/Server.js" />
/// 
(function ($) {
    "use strict";

    $.extend(true, window, {
        ShowPlanner: {
            api: {
                Messages: {
                    ApiException : "ApiException"
                }
            }
        }
    });

})(jQuery);