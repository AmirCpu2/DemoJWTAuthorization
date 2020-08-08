app.service("Service", function($http) {

    this.getTaskList = function() {
        return $http.get("http://localhost:44386/api/Task/GetAll");
    };

    this.getAccount = function(id) {
        return $http.get("http://localhost:44386/api/Account/Get" + id);
    };

    this.login = function(username,Password) {
        var request = $http({
            method: "post",
            url: "http://localhost:44386/api/Account/login",
            data: { "UserName": username, "Password": Password }
        });

        return request;
    };

});