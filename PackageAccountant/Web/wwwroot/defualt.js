var app = angular.module('PackageApp', ['ngRoute']);

app.controller("UplaodController", function ($scope, $http) {
    $scope.Upload = function () {
        var form = new FormData();
        var file = $("#file")[0].files[0];
        form.append("fileName", file);
        $http.post("/api/values/UploadFiles", form, {
            transformRequest: angular.identity,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (data) {
            alert("true");
            }).catch(function (data) {
                console.log(data);
            });
        //$.post('/api/values/UploadFiles',
        //    {
        //        data: form,
        //        transformRequest: angular.identity,
        //        headers: {
        //            'Content-Type': undefined
        //        }
        //    }, function (data) {
        //        console.log(data);
        //    });
    }

    $scope.GetUserId = function () {
        $http({
            method: 'GET',
            url: '/api/Login/Login',
            params: { userid: $scope.userid }
        }).then(function success(response) {
            console.log(response);
        }, function errorCallback(response) {
            console.log(response)
        });
    }
})