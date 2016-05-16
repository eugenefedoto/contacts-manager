(function () {
    "use strict";

    angular.module("AngularFormsApp")
    .controller("cfController", cfController);

    function cfController() {
        var vm = this;
        vm.newContact = {};

        vm.addTrip = function () {
            alert(vm.newContact.firstName);
        };
    }
})();