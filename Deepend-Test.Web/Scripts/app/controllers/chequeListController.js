(function () {
    'use strict';

    window.app.controller('chequeListController', chequeListController);
    chequeListController.$inject = ['httpService'];

    function chequeListController(httpService) {
        var vm = this;
        vm.chequeList = [];

        vm.init = function () {
            httpService.get(api_chequeApi_chequeList)
           .then(function (response) {
               vm.chequeList = response.data;
           })
        };
    }
})();