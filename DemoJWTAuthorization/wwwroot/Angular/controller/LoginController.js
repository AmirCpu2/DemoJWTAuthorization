app.controller("LoginController", function ($scope, $location, Service, ShareData) {

    $.when(
        Service.TokenIsValid()
    ).then(function (R) {
        console.log(R);

        if (Token != null && R) {
            console.log(R);
            $routeProvider.otherwise({
                redirectTo: "/Admin"
            });
        }
        else {
            console.log(R);
            $routeProvider.otherwise({
                redirectTo: "/Login"
            });
        }

    });

    $scope.submit = function () {
        
        $.when(
            Service.login($scope.UserName, $scope.Password)
        ).then(function (R) {
            ShareData.value = $scope.UserName;
            console.log(R);

            if (Token != null && R) {
                alert("true");
                $routeProvider.otherwise({
                    redirectTo: "/Admin"
                });
            }
            else {
                alert("false");
                $routeProvider.otherwise({
                    redirectTo: "/Login"
                });
            }

        });

        //console.log(result);
    }
});