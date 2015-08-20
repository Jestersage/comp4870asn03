var app = angular.module('myApp', []);



app.controller('ClientController', function ($scope, $http) {

    var onClientComplete = function (response) {
        console.log(JSON.stringify(response));
        $scope.user = response.data;
        $scope.dump = JSON.stringify(response.data);

    };

    var onError = function (reason) {
        $scope.error = "Could not fetch the Client.";
        $scope.dump = JSON.stringify(response.data);
        //$scope.error = reason;
    };

    $scope.search = function () {
        $http.get("http://a3.georgeleung.com/api/Clients/" + username + "/" + fileStatus)
      .then(onClientComplete, onError);
    };

    $http.get("http://a3.georgeleung.com/api/Clients")
       .then(onClientComplete, onError);

});