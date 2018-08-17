(function () {
    'use strict';
    vikings.controller('HomeController', ['$scope', '$window', 'toastr', 'HomeService',
        function ($scope, $window, toastr, HomeService) {

        var vm = this;

        //Methods
        vm.AtivarMenu = AtivarMenu;
        vm.getRandomNumber = getRandomNumber;

        //Variables
        vm.slideNumber = 0;

        init();
        function init() {
            vm.AtivarMenu();
            vm.getRandomNumber();
        }

        function AtivarMenu() {
            $(function () {
                $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
            });
        }

        function getRandomNumber() {
            var number = Math.floor((Math.random() * 13) + 3);

            if (number == 14 || number == 15)
                vm.getRandomNumber();
            else
                vm.slideNumber = number;
        }
    }]);
})();