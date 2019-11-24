var app = angular.module('PackageApp', ['ngRoute']);

app.controller('UplaodController', function ($scope, $route) { $scope.$route = $route; })
app.controller('LoginController', function ($scope, $route) { $scope.$route = $route; })
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

app.config(function ($routeProvider) {
    $routeProvider.
        when('/login', {
            templateUrl: 'login.html',
            controller: 'LoginController'
        }).
        when('/default', {
            templateUrl: 'default.html',
            controller: 'UplaodController'
        }).
        otherwise({
            redirectTo: '/default'
        });
});