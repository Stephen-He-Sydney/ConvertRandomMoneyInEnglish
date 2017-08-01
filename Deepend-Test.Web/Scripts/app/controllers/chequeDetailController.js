(function () {
    'use strict';

    window.app.controller('chequeDetailController', chequeDetailController);
    chequeDetailController.$inject = ['httpService'];

    function chequeDetailController(httpService) {
        var vm = this;
        vm.chequeDetail = {};

        vm.init = function (chequeId) {
            httpService.get(api_chequeApi_chequeDetail.replace('{chequeId}', chequeId))
           .then(function (response) {
               vm.chequeDetail = response.data;
           })
        };

    }
})();