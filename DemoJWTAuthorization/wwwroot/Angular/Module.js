﻿/*import { request } from "http";*/

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


    //if (localStorage.getItem("jwtToken") == null)

    /*$.ajax({
        type: "post",
        url: `${location.protocol}//${location.host}/api/Authentication/tokenIsValid`,
        data: { "token" : localStorage.getItem("jwtToken")+"" },
        success: function (response) {
            alert(response);

            if (response) {
                
                $routeProvider.otherwise({
                    redirectTo: "/admin"
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
    });*/

}]);
