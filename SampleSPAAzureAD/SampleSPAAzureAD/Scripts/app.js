var app = angular.module("app", ["AdalAngular"]);

app.config(["$httpProvider", "adalAuthenticationServiceProvider", function ($httpProvider, adalProvider) {
    var endpoints = {
        "https://localhost:44322/": "http://cuespasamplead.onmicrosoft.com/SpaSample"
        // endpoints format is as below
        // API base URL : APP ID URI for hosted API
    };

    adalProvider.init({
        instance: "https://login.microsoftonline.com/",
        tenant: "cuespasamplead.onmicrosoft.com", // tenant domain - without http prefix
        clientId: "1b3be89a-2253-443a-bacf-c4040c2fe400", // angular application Client ID
        endpoints: endpoints
    }, $httpProvider);

}]);

var sampleController = app.controller("sampleController", ["$scope", "$http", "adalAuthenticationService", function ($scope, $http, adalService) {
    $scope.login = login;
    $scope.logout = logout;
    $scope.onlyAdmin = onlyAdmin;
    $scope.callAPI = callAPI;

    $scope.values = "call api to fetch values";

    function login() {
        adalService.login();
    }

    function logout() {
        adalService.logOut();
    }
    function callAPI() {
        $http.get("https://localhost:44322/api/values").success(function (data, status, headers, config) {
            $scope.values = data;
        }).error(function (data, status, headers, config) {
            if (status === undefined || status === 401) {
                console.log("unauthorized request");
                $scope.values = "no values retrieved";
            }
        });
    }
    function onlyAdmin() {
        $http.get("https://localhost:44322/api/values/1").success(function (data, status, headers, config) {
            $scope.admin = true;
        }).error(function (data, status, headers, config) {
            if (status === 401) {
                console.log("not admin");
                $scope.admin = false;
            }
        });
    }

}]);