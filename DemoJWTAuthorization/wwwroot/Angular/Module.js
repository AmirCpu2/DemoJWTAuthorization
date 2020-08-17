/*import { request } from "http";*/

var app = angular.module("MainModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

app.config(["$routeProvider", "$locationProvider", function ( $routeProvider, $locationProvider) {

    $routeProvider.when("/Login", {
        templateUrl: "Home/Login",
        controller: "LoginController"
    });

    $routeProvider.when("/Admin", {
        templateUrl: "Home/Admin",
        controller: "AdminController"
    });

    $routeProvider.otherwise({
        redirectTo: "/Login"
    });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });


    
}]);
