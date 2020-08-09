app.service("Service", function($http) {

    this.getTaskList = function() {
        return $http.get("https://localhost:44386/api/Task/GetAll");
    };

    this.getAccount = function(id) {
        return $http.get("https://localhost:44386/api/Account/Get/" + id);
    };
    
    this.TokenIsValid = function () {
        var Token = localStorage.getItem("jwtToken");
        $http({
            method: "Get",
            url: "https://localhost:44386/api/Authentication/tokenIsValid",
            Headers: { "Authorization": "Bearer " + Token }
            })
            .then(function success(response) {
                if (response!=null)
                    return true;
                else
                {
                    localStorage.removeItem("jwtToken");
                    return false;
                }
            },
            function error() {
                localStorage.removeItem("jwtToken");
                return false;
            });
    };

    this.login = function (username, Password) {
        
        $http({
            method: "Post",
            url: 'https://localhost:44386/api/Authentication/login',
            data: { "UserName": username, "Password": Password }
        }).then(function success(response) {
            
            //Update Token
            localStorage.removeItem("jwtToken");
            localStorage.setItem("jwtToken", response.data.token);
            
            return true;
            // this function will be called when the request is success
        }, function error() {
                return false;
                localStorage.removeItem("jwtToken");
        });
    };

});