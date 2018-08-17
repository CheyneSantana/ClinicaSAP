(function () {
    'use strict';
    vikings.controller('PrajaController', ['$scope', '$window', 'toastr', 'PrajaService',
        function ($scope, $window, toastr, PrajaService) {

            var vm = this;

            //Variables
            vm.PrajaDTO = {};
            vm.file = {};

            //Methods
            vm.AtivarMenu = AtivarMenu;
            vm.Cadastrar = Cadastrar;
            vm.limparCampos = limparCampos;

            init();
            function init() {
                vm.AtivarMenu();
            }

            function AtivarMenu() {
                $(function () {
                    $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
                });
            }

            function Cadastrar(file) {
                var file = document.querySelector('input[type=file]').files[0];
                var reader = new FileReader();

                reader.onloadend = function () {
                    vm.PrajaDTO.IMAGEM = reader.result;
                    PrajaService.Cadastrar(vm.PrajaDTO).then(function (response) {
                        if (response) {
                            toastr.success("Cadastro realizado com sucesso!");
                            vm.limparCampos();
                        }
                    });
                }
                reader.readAsDataURL(file);
            }

            function limparCampos() {
                vm.PrajaDTO = {};
                angular.element(document.querySelector('input[type=file]')).val(null);
            }

        }]);
})();