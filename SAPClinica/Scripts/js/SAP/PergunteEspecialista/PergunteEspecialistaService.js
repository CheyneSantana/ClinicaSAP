(function () {
    'use strict';
    vikings.service('PergunteEspecialistaService', ['$http', function ($http) {
        var _GetEspecialidades = function () {
            return $http.post('/PergunteEspecialista/findAllEspecialidades');
        }

        var _EnviarEmail = function (prEnvioDTO) {
            return $http.post('/PergunteEspecialista/EnviarPergunta', prEnvioDTO);
        }

        this.GetEspecialidades = _GetEspecialidades;
        this.EnviarEmail = _EnviarEmail;
    }]);
})();