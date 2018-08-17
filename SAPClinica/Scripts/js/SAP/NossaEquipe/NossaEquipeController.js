(function () {
    'use strict';
    vikings.controller('NossaEquipeController', ['$scope', '$window', 'toastr', function ($scope, $window, toastr) {

        var vm = this;

        //Methods
        vm.AtivarMenu = AtivarMenu;

        init();
        function init() {
            vm.AtivarMenu();
        }

        function AtivarMenu() {
            $(function () {
                $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
            });
        }
    }]);
})();