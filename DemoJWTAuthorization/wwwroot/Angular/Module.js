/*import { request } from "http";*/

var app = angular.module("MainModule", ["ngRoute"]);


var TokenIsValid = function (token) {
    return false;
};

app.factory("ShareData", function () {
    return { value: 0 }
});

app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

    $routeProvider.when("/Login", {
        templateUrl: "Home/Login",
        controller: "LoginController"
    });

    $routeProvider.when("#!/Admin", {
        templateUrl: "Home/Admin",
        controller: "AdminController"
    });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    var Token = localStorage.getItem("jwt");

    if (Token != null && TokenIsValid(Token)) {
        $routeProvider.otherwise({
            redirectTo: "#!/Admin"
        });
    }
    else {
        $routeProvider.otherwise({
            redirectTo: "/Login"
        });
    }
        
 
}]);

