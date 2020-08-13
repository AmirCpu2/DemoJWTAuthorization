app.service("Service", function ($http, ShareData) {


    this.getTaskList = function() {
        return $http({
            method: "Get",
            headers: { 'Authorization': `Bearer ${localStorage.getItem("jwtToken")}` },
            url: `${location.protocol}//${location.host}/api/Task/getTest`
        });
    };

    this.getAccount = function(id) {
        return $http({
            method: "Get",
            headers: {'Authorization': `Bearer ${localStorage.getItem("jwtToken")}`},
            url: `${location.protocol}//${location.host}/api/Account/getPerson?id=${id}`
        });
    };

    this.getAllTask = function () {
        return $http({
            method: "Get",
            headers: { 'Authorization': `Bearer ${localStorage.getItem("jwtToken")}` },
            url: `${location.protocol}//${location.host}/api/Task/getAll`
        });
    };

    this.getPerformanse = function () {
        return $http({
            method: "Get",
            headers: { 'Authorization': `Bearer ${localStorage.getItem("jwtToken")}` },
            url: `${location.protocol}//${location.host}/api/Task/getPerformanse`
        });
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