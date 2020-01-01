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
            if (data.data.count == -1) {
                alert("出现异常请查看日志");
            }
            }).catch(function (data) {
                console.log(data);
            });
    }
})