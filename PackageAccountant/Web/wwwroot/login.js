var app = angular.module('LoginApp', ['ngRoute']);
app.controller('LoginController', function ($scope, $http) {
    $scope.GetUserId = function () {
        $http({
            method: 'GET',
            url: '/api/Login/Login',
            params: { userid: $scope.userid }
        }).then(function success(response) {
            if (response.status == 200) {
                location.href ="app.html"
            }
        }, function errorCallback(response) {
            console.log(response)
        });
    }
});