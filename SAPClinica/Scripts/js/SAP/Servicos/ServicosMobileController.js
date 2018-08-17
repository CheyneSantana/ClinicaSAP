(function () {
    'use strict';
    vikings.controller('ServicosMobileController', ['$scope', '$window', 'toastr', 'ServicosService',
        function ($scope, $window, toastr, ServicosService) {

            var vm = this;

            //Variables
            vm.ServicosDTO = [];
            vm.Servicos = [];

            //Methods
            vm.AtivarMenu = AtivarMenu;
            vm.AbrirEspecialidades = AbrirEspecialidades;
            vm.findEspecialidades = findEspecialidades;
            vm.getServicos = getServicos;

            init();
            function init() {
                vm.AtivarMenu();
                vm.getServicos();
            }

            function AtivarMenu() {
                $(function () {
                    $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
                });
            }

            function getServicos() {
                ServicosService.GetServicos().then(function (response) {
                    if (response) {
                        vm.Servicos = response.data;
                    }
                });
            }

            function AbrirEspecialidades(prServico) {
                $window.location.href = "/Servicos/Especialidades?prServico=" + prServico;
            }

            function findEspecialidades(prServico) {
                ServicosService.FindEspecialidades(prServico).then(function (response) {
                    if (response) {
                        vm.ServicosDTO = response.data;
                    }
                });
            }

        }]);
})();