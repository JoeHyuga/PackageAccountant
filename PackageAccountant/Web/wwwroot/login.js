var app = angular.module('LoginApp', ['ngRoute']);
app.controller('LoginController', function ($scope, $http) {
    $scope.GetUserId = function () {
        $http({
            method: 'POST',
            url: '/api/Login/Login',
            params: { username: $scope.username }
        }).then(function success(response) {
            if (response.data.result == true) {
                location.href = "app.html"
            }
            else {
                alert("用户信息不存在")
            }
        }, function errorCallback(response) {
            alert("出现异常请查看日志");
            console.log(response)
        });
    }
});