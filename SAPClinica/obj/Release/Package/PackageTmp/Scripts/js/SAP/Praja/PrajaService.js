(function () {
    'use strict';
    vikings.service('PrajaService', ['$http', function ($http) {

        var _Cadastrar = function (prPrajaDTO) {
            return $http.post('/Praja/Cadastrar', prPrajaDTO);;
        }

        this.Cadastrar = _Cadastrar;
    }]);
})();