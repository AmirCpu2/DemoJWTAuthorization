/*import { request } from "http";*/

var app = angular.module("MainModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider, Service, $http) {

    $routeProvider.when("/Login", {
        templateUrl: "Home/Login",
        controller: "LoginController"
    });

    $routeProvider.when("/Admin", {
        templateUrl: "Home/Admin",
        controller: "AdminController"
    });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    if (localStorage.getItem("jwtToken") == null)
        $routeProvider.otherwise({
            redirectTo: "/Login"
        });

    $.ajax({
        type: "Get",
        url: `${location.protocol}//${location.host}/api/Authentication/tokenIsValid`,
        headers: { "Authorization": "Bearer " + localStorage.getItem("jwtToken") },
        success: function (response) {
            if (response != null) {
                $routeProvider.otherwise({
                    redirectTo: "/Login"
                });
                return true;
            }
            else {
                localStorage.removeItem("jwtToken");
                return $routeProvider.otherwise({
                    redirectTo: "/Login"
                });
            }
        },
        error: function error() {
            localStorage.removeItem("jwtToken");
            return $routeProvider.otherwise({
                redirectTo: "/Login"
            });
        }
    });

}]);
