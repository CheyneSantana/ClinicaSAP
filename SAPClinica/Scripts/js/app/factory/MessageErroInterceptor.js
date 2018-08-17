(function () {
    'use strict';
    vikings.factory('MessageErroInterceptor', ['$q', 'toastr', function ($q, toastr) {
        return {
            request: function (config) {
                return config;
            },
            requestError: function (rejection) {
                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.data && response.data instanceof Array && response.data.length > 0 && response.data[0].hasOwnProperty("aErro")) {
                    for (var i = 0; i < response.data.length; i++) {
                        toastr.error(response.data[i].aErro);
                    }
                    return $q.reject(response);
                }
                return response;
            },
            responseError: function (rejection) {
                return $q.reject(rejection);
            }
        }
    }]);
})();