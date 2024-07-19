var nsiHelper = function () {
    const DEFAULT_API_URL = 'https://localhost:7169/api/';

    function ajax(url, method, data, headers, parameters, success, error, beforeSend, complete, contentType, async) {
        $.ajax({
            url: (DEFAULT_API_URL + url + parameters),
            method: method,
            data: data,
            headers: headers,
            success: success,
            error: error,
            beforeSend: beforeSend,
            complete: complete,
            contentType: contentType,
            async: async
        });
    };

    function showLoader(container) {
        if (!$(container).hasClass('dot-carousel'))
            $(container).addClass('dot-carousel');
    }

    function hideLoader(container) {
        if ($(container).hasClass('dot-carousel'))
            $(container).removeClass('dot-carousel');
    }

    return {
        Ajax: ajax,
        ShowLoader: showLoader,
        HideLoader: hideLoader
    }
}();