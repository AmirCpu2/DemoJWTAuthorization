app.controller("LoginController", function ($http, $location, Service, ShareData, $scope) {

   //Get Token now
    var Token = localStorage.getItem("jwtToken");

    //TurnOff Error
    $scope.Error = false;

    //Check Validate Token
    if (Token != undefined || Token != null) {
        Service.TokenIsValid(Token).then(function success(res) {
            console.log(res);
            console.log(res.data == 'True');
            if (res.data == 'True') {
                location.href = `${location.protocol}//${location.host}` + '#/Admin';
            }
            else {
                localStorage.removeItem("jwtToken");
                localStorage.removeItem("userId");
                $scope.Error = true;
                $scope.Message = 'token Expiry, Try login..';
                $scope.load = true;
            }
        }, function error() {
            localStorage.removeItem("jwtToken");
            localStorage.removeItem("userId");
            $scope.Error = true;
            $scope.Message = 'token Expiry, Try login..';
            $('#ContentBody').show();
        });

    }
    else {
        $('#ContentBody').show();
    }

    $scope.submit = function () {

        Service.login($scope.UserName, $scope.Password)
            .then(function success(response) {
                console.log("response: " + response.data.token + '\n id: ' + response.data.id);
                localStorage.removeItem("jwtToken");
                localStorage.removeItem("userId");
                localStorage.setItem("jwtToken", response.data.token);
                localStorage.setItem("userId", response.data.id);
                location.href = `${location.protocol}//${location.host}` + '#/Admin';
            }, function error() {
                    $scope.Error = true;
                    $scope.Message = 'Username or Password is Invalid';
            });
    }
});