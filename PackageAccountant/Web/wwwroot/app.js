var app = angular.module('PackageApp', ['ngRoute']);

app.controller('UplaodController', function ($scope, $route) { $scope.$route = $route; })
app.controller('InExShowController', function ($scope, $route) { $scope.$route = $route; })
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

app.config(function ($routeProvider) {
    $routeProvider.
        when('/default', {
            templateUrl: 'default.html',
            controller: 'UplaodController'
        }).
        when('/inexshow', {
            templateUrl: 'inexshow.html',
            controller: 'InExShowController'
        }).
        otherwise({
            redirectTo: '/default'
        });
});
app.controller("AppController", function ($scope, $http) {
    // 父级接收  
    $scope.$on('page', function (event, data) {
        $scope.page = data;
    });

    $scope.GetMenuList = function () {
        $http.get("/api/App/GetMenuList").then(
            function (data) {
                $scope.menulist = data.data.list;
        })
    }

    $scope.GetMenuList();
})
 