app.controller("AdminController", function ($scope, $location, Service, ShareData, $routeProvider) {

    alert("t1");

    loadAll();

    function loadAll() {
        alert("t2");
        var account = Service.getAccount(ShareData.value);
        account.then(function (q) { $scope.People = q.data; },
            function (error) {
                $scope.error = 'نمایش با شکست مواجه شد', error;
                localStorage.removeItem("jwtToken");
                $routeProvider.otherwise({
                    redirectTo: "/Login"
                });
            });
    }
});