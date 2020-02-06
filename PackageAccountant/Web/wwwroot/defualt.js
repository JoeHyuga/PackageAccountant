app.controller("UplaodController", function ($scope, $http) {
    $scope.$emit('page', "上传数据项");
    $scope.step = 1
    $scope.Step1 = function () {
        var file = $("#file")[0].files[0];
        if (file == undefined) {
            alert('请先上传文件')
        } else {
            $scope.step = 2
        }
    }

    $scope.Step2 = function () {
            $scope.step = 1
    }

    $scope.AppendData = function () {
        $scope.hit = "tips：按时间附加到已有数据中"
        $scope.rhit = "append"
    }

    $scope.CleanData = function () {
        $scope.hit = "tips：清除原有数据再导入"
        $scope.rhit = "clean"
    }

    $scope.Upload = function () {
        if ($scope.rhit == undefined || $scope.rhit == "") {
            $scope.hit = "tips：请选选项！！！"
            return;
        }
        var form = new FormData();
        var file = $("#file")[0].files[0];
        form.append("fileName", file);
        form.append("rhit", $scope.rhit);
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