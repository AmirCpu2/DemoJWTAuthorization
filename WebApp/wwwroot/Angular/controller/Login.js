(function () {
    'use strict';

    angular
        .module('app')
        .controller('Login', Login);

    Login.$inject = ['$location'];

    function Login($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Login';

        activate();

        function activate() { }
    }
})();
