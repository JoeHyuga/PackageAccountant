app.controller("UplaodController", function ($scope, $http) {
    $scope.$emit('page', "上传数据项"); 
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
            if (data.data.count > 0) {
                alert("上传成功");
            }
            }).catch(function (data) {
                alert("出现异常请查看日志");
                console.log(data);
               
            });
    }
})