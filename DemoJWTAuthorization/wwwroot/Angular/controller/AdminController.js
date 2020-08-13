﻿app.controller("AdminController", function ($scope, $location, Service, ShareData) {

    //Get Token now
    var Token = localStorage.getItem("jwtToken");
    //Get Account Id now
    var userId = localStorage.getItem("userId");

    //Check Validate Token
    if (Token != undefined || Token != null || userId!=null) {
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

    Service.getAccount(userId).then(
        function success(re) {
            console.log(re.data.Fname + " " + re.data.Lname);
            $scope.FullName = re.data.Fname + " " + re.data.Lname;
        }, function error() {
            localStorage.removeItem("jwtToken");
            location.href = `${location.protocol}//${location.host}` + '#/Login';
        }
    );

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


    $scope.getAccount = function () {

        Service.getAccount(userId).then(
            function success(re) {
                console.log(re.data.Fname + " " + re.data.Lname);
                $scope.FullName = re.data.Fname + " " + re.data.Lname;
            }, function error() {
                localStorage.removeItem("jwtToken");
                location.href = `${location.protocol}//${location.host}` + '#/Login';
            }
        );
    }


    function loadChart (data) {

        chartColor = "#FFFFFF";

        console.log(data);

        ctx = document.getElementById('chartHours').getContext("2d");

        myChart = new Chart(ctx, {
            type: 'line',

            data: {
                labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct"],
                datasets: Charts,
                data: data
            },
            options: {
                legend: {
                    display: false
                },

                tooltips: {
                    enabled: false
                },

                scales: {
                    yAxes: [{

                        ticks: {
                            fontColor: "#9f9f9f",
                            beginAtZero: false,
                            maxTicksLimit: 5,
                            //padding: 20
                        },
                        gridLines: {
                            drawBorder: false,
                            zeroLineColor: "#ccc",
                            color: 'rgba(255,255,255,0.05)'
                        }

                    }],

                    xAxes: [{
                        barPercentage: 1.6,
                        gridLines: {
                            drawBorder: false,
                            color: 'rgba(255,255,255,0.1)',
                            zeroLineColor: "transparent",
                            display: false,
                        },
                        ticks: {
                            padding: 20,
                            fontColor: "#9f9f9f"
                        }
                    }]
                },
            }
        });

    }


    //init task list
    $scope.Tasks = [];

    Service.getAllTask().then(
        function success(re) {
            console.log('getAllTask:');
            console.log(re.data);
            $scope.Tasks = re.data;
            console.log('scope1!:');
            console.log($scope.Tasks[0].description);
            console.log($scope.Tasks[0].agent);
        }, function error() {
            //localStorage.removeItem("jwtToken");
            //location.href = `${location.protocol}//${location.host}` + '#/Login';
        }
    );

    var Charts = [{
        borderColor: "#6bd098",
        backgroundColor: "#6bd098",
        pointRadius: 0,
        pointHoverRadius: 0,
        borderWidth: 3,
        data: [ 300, 310, 316, 322, 330, 326, 333, 345, 338, 354]
        },
        {
            borderColor: "#f17e5d",
            backgroundColor: "#f17e5d",
            pointRadius: 0,
            pointHoverRadius: 0,
            borderWidth: 3,
            data: [300, 310, 316, 322, 330, 326, 333, 345, 338, 354]
        },
        {
            borderColor: "#fcc468",
            backgroundColor: "#fcc468",
            pointRadius: 0,
            pointHoverRadius: 0,
            borderWidth: 3,
            data: [300, 310, 316, 322, 330, 326, 333, 345, 338, 354]
        }];

    Service.getPerformanse().then(
        function success(re) {
            Charts[0].data = re.data[0];
            Charts[1].data = re.data[1];
            Charts[2].data = re.data[2];
            loadChart(Charts);
        }, function error() {
            localStorage.removeItem("jwtToken");
            location.href = `${location.protocol}//${location.host}` + '#/Login';
        }
    );
});