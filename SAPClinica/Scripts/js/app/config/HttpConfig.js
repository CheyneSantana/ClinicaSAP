(function () {
    'use strict';
    vikings.config(['$httpProvider', function ($httpProvider) {

        $httpProvider.interceptors.push("MessageErroInterceptor");

    }]);
})();