app.controller("AdminController", function ($scope, $location, Service, ShareData, $routeProvider) {

    loadAll();

    function loadAll() {
        var account = Service.getAccount();

        account.then(function (q) { $scope.People = q.data; },
            function (error) {
                $scope.error = 'نمایش با شکست مواجه شد', error;
                localStorage.removeItem("jwt");
                $routeProvider.otherwise({
                    redirectTo: "/Login"
                });
            });
    }

    /*
    $scope.addPerson = function () {
        $location.path("/addPerson");
    };

    $scope.editPerson = function (personId) {

        ShareData.value = personId;
        $location.path("/editPerson");
    };

    $scope.deletePerson = function (personId) {
        ShareData.value = personId;
        $location.path("/deletePerson");
    };
    */
});