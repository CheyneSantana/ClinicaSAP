(function () {
    'use strict';
    vikings.service('UtilityService', ['$window', function ($window) {

        //Retorna um objeto contendo os parametros e seus respectivos valores que são informados na URL
        //Exemplo URL: www.site.com?pr1=10&pr2=teste
        //retornara um objeto:
        // obj.pr1 = 10
        // obj.pr2 = "teste"
        this.getQueryParams = function (qs) {
            if (!qs)
                if ($window.location.search)
                    qs = $window.location.search;
                else
                    return null;

            qs = qs.split('+').join(' ');

            var params = {},
                tokens,
                re = /[?&]?([^=]+)=([^&]*)/g;

            while (tokens = re.exec(qs)) {
                params[decodeURIComponent(tokens[1])] = decodeURIComponent(tokens[2]);
            }

            return params;
        }

        //Retorna um Array do enumerado KDLogical (pode ser usado em select/combobox)
        this.getKDLogical = function () {
            return [{ Key: 0, Value: "Não" }, { Key: 1, Value: "Sim" }];
        }

        this.getMeses = function () {
            return ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'];
        }

        this.getMesesSigla = function () {
            return ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'];
        }

    }]);
})();