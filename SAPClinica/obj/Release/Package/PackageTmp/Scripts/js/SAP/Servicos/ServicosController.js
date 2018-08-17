(function () {
    'use strict';
    vikings.controller('ServicosController', ['$scope', '$window', 'toastr', 'ServicosService',
        function ($scope, $window, toastr, ServicosService) {

            var vm = this;

            //Variables
            vm.ServicosDTO = [];
            vm.Servicos = [];
            vm.CurrentServico = 0;
            vm.hasEspecialidades = false;
            vm.showMedicos = false;
            vm.Medicos = [];
            vm.NomeEspecialidade = "";

            //Methods
            vm.AtivarMenu = AtivarMenu;
            vm.AbrirEspecialidades = AbrirEspecialidades;
            vm.findEspecialidades = findEspecialidades;
            vm.getServicos = getServicos;
            vm.MostrarMedicos = MostrarMedicos;
            vm.MostrarEspecialidades = MostrarEspecialidades;

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
                if (vm.CurrentServico == prServico) {
                    vm.hasEspecialidades = false;
                    vm.showMedicos = false;
                    vm.CurrentServico = 0;
                }
                else {
                    vm.hasEspecialidades = false;
                    vm.showMedicos = false;
                    vm.ServicosDTO = {};
                    ServicosService.FindEspecialidades(prServico).then(function (response) {
                        if (response) {
                            vm.ServicosDTO = response.data;
                            vm.CurrentServico = prServico;
                            if (vm.ServicosDTO.ESPECIALIDADES.length > 0)
                                vm.hasEspecialidades = true;
                        }
                    });
                }
            }

            function MostrarMedicos(prNomeEspecialidade, prMedicos) {
                vm.hasEspecialidades = false;
                vm.showMedicos = true;
                vm.Medicos = prMedicos;
                vm.NomeEspecialidade = prNomeEspecialidade;
            }

            function MostrarEspecialidades() {
                vm.hasEspecialidades = true;
                vm.showMedicos = false;
            }

        }]);
})();