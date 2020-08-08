app.controller("loginController", function ($scope, $location, PersonService, ShareData) {

    loadAll();

    function loadAll() {
        var list = PersonService.getAllPerson();

        list.then(function (pl) { $scope.People = pl.data; },
            function (error) { $scope.error = 'نمایش با شکست مواجه شد', error; });
    }


    $scope.addPerson = function () {
        $location.path("/addPerson");
    };

    $scope.editPerson = function (personId) {

        ShareData.value = personId;
        $location.path("/editPerson");
    };

    $scope.deletePerson = function (personId) {
        ShareData.value = personId;
        $location.path("/deletePerson");
    };
});