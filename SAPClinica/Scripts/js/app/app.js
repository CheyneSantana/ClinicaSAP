var vikings = angular.module('vikings', ['toastr', 'ngMask', 'angular-loading-bar']);

vikings.run(['$rootScope', function ($rootScope) {
}]);

vikings.constant('Constants', {
    KDLogical: {
        KDNo: 0,
        KDYes: 1
    }
});