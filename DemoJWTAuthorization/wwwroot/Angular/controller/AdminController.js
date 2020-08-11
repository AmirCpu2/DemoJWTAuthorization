app.controller("AdminController", function ($scope, $location, Service, ShareData) {

    //Get Token now
    var Token = localStorage.getItem("jwtToken");

    //Check Validate Token
    if (Token != undefined || Token != null) {
        Service.TokenIsValid(Token).then(function success(re) {
            if (re.data == 'False')
                location.href = `${location.protocol}//${location.host}` + '#/Login';
            else
                $('#ContentBody').show();
        }, function error() {
                location.href = `${location.protocol}//${location.host}` + '#/Login';
        });
    }
    else
    {
        location.href = `${location.protocol}//${location.host}` + '#/Login';
    }


    $scope.logout = function () {

        Service.logout(Token)
            .then(function success(response) {
                localStorage.removeItem("jwtToken");
                localStorage.removeItem("userId");
                location.href = `${location.protocol}//${location.host}` + '#/Login';
            }, function error() {
                localStorage.removeItem("jwtToken");
                localStorage.removeItem("userId");
                location.href = `${location.protocol}//${location.host}` + '#/Login';
            });
    }

});