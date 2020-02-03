app.controller("InExShowController", function ($scope, $http) {
    $scope.$emit('page', "收支总览");
    var ctx = $("#myChart")
    var Cx = new Chart(ctx, {
        type: 'line',
        data: {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
            datasets: [{
                label: 'My First dataset',
                backgroundColor: 'rgb(255, 99, 132)',
                borderColor: 'rgb(255, 99, 132)',
                data: [0, 10, 5, 2, 20, 30, 45]
            }]
        },
        options: {}
    })
})