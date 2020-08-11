app.service("Service", function ($http, ShareData) {


    this.getTaskList = function() {
        return $http.get(`${location.protocol}//${location.host}/api/Task/GetAll`);
    };

    this.getAccount = function(id) {
        return $http.get(`${location.protocol}//${location.host}/api/Account/Get/` + id);
    };
    
    this.TokenIsValid = function (Token) {
       
        return $http({
            method: "Post",
            url: `${location.protocol}//${location.host}/api/Authentication/tokenIsValid`,
            data: { "token": Token }
        });
    };

    this.login = function (username, Password) {
        
        return $http({
            method: "Post",
            url: `${location.protocol}//${location.host}/api/Authentication/login`,
            data: { "UserName": username, "Password": Password }
        })
    };

    this.logout = function (token)
    {
        return $http({
            method: "Post",
            url: `${location.protocol}//${location.host}/api/Authentication/logout`,
            data: { "token": token }
        })
    }

});