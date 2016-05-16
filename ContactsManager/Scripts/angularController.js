(function () {
    "use strict";

    angular.module("site")
    .controller("angularController", angularController);

    function angularController($http) {
        var vm = this;

        vm.contacts = []

        $http.get("/contacts/")

        vm.name = "Eugene";
    }
})();