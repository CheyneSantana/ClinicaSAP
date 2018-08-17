(function () {
    'use strict';
    vikings.controller('PergunteEspecialistaController', ['$scope', '$window', 'toastr', 'PergunteEspecialistaService',
        function ($scope, $window, toastr, PergunteEspecialistaService) {

            var vm = this;

            //Variables
            vm.Especialidade = {};
            vm.ServicosDTO = [];
            vm.EnvioDTO = {};

            //Methods
            vm.AtivarMenu = AtivarMenu;
            vm.getEspecialidades = getEspecialidades;
            vm.Enviar = Enviar;
            vm.LimparCampos = LimparCampos;

            init();
            function init() {
                vm.AtivarMenu();
                vm.getEspecialidades();
            }

            function AtivarMenu() {
                $(function () {
                    $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active');
                });
            }

            function getEspecialidades() {
                PergunteEspecialistaService.GetEspecialidades().then(function (response) {
                    if (response)
                        vm.ServicosDTO = response.data;
                });
            }

            function Enviar() {
                vm.EnvioDTO.EspecialidadeId = vm.Especialidade.ESPECIALIDADEID;
                vm.EnvioDTO.NomeEspecialidade = vm.Especialidade.NOMEESPECIALIDADE;
                PergunteEspecialistaService.EnviarEmail(vm.EnvioDTO).then(function (response) {
                    if (response) {
                        toastr.success("Email enviado. Obrigado!");
                        vm.LimparCampos();
                    }
                });
            }

            function LimparCampos() {
                vm.EnvioDTO = {};
            }
        }]);
})();