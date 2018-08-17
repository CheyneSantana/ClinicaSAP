(function () {
    'use strict';
    vikings.controller('EspecialidadeController', ['$scope', '$window', 'toastr', 'ServicosService', 'UtilityService',
        function ($scope, $window, toastr, ServicosService, UtilityService) {

            var vm = this;

            //Variables
            vm.Servico = "";
            vm.FindServico = 0;
            vm.ServicosDTO = [];
            vm.showMedicos = false;
            vm.Medicos = [];
            vm.NomeEspecialidade = "";

            //Methods
            vm.AtivarMenu = AtivarMenu;
            vm.HabilitarServico = HabilitarServico;
            vm.voltar = voltar;
            vm.findEspecialidades = findEspecialidades;
            vm.MostrarMedicos = MostrarMedicos;
            vm.MostrarEspecialidades = MostrarEspecialidades;

            init();
            function init() {
                vm.AtivarMenu();
                vm.HabilitarServico();
            }

            function findEspecialidades(prServico) {
                ServicosService.FindEspecialidades(prServico).then(function (response) {
                    if (response) {
                        vm.ServicosDTO = response.data;
                    }
                });
            }

            function voltar() {
                $window.location.href = "/Servicos/Servicos";
            }

            function AtivarMenu() {
                $(function () {
                    $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
                });
            }

            function HabilitarServico() {
                var lObj = UtilityService.getQueryParams();
                if (lObj) {
                    vm.findEspecialidades(lObj.prServico);
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