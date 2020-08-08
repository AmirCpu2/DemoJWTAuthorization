app.controller("LoginController", function ($scope, $location, Service, ShareData) {

    
    $scope.clickLogin = function () {
        alert($scope.UserName + ' ' + $scope.Password);
        //Service.login($scope.UserName, $scope.Password);
        //$location.path("/addPerson");
    };
    
});