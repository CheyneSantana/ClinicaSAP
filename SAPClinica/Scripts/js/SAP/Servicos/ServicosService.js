(function () {
    'use strict';
    vikings.service('ServicosService', ['$http', function ($http) {

        var _FindEspecialidades = function (prServico) {
            return $http.post("/Servicos/getEspecialidades?prServico="+ prServico);
        }

        var _GetServicos = function () {
            return $http.post("/Servicos/getServicos");
        }

        this.FindEspecialidades = _FindEspecialidades;
        this.GetServicos = _GetServicos;
    }]);
})();