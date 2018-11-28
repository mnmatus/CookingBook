cookingBookApp.controller('loginController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {
    $scope.userName;
    $scope.password;
    $scope.login = function () {
        $http({
            method: 'POST',
            url: '/api/user/authenticate',
            data: {
                    UserName: $scope.userName,
                    Password: $scope.password,                
                  },
        }).then(function (response) {            
            userToken.set(response.data.token);
            $window.location.href = '/Home/Index';
        }).catch(function (response) {
            $scope.errorMessage = 'Invalid username and/or password.';
            $scope.password = '';
            $scope.isNotValid = true;           
            $scope.frmLogin.$setPristine();
        });
    };

    $scope.validate = function () {
        $http({
            method: 'POST',
            url: '/api/auth/validate',
        }).then(function (response) {            
            if (response.data != "") {
                $window.location.href = '/Home/Index';
            }
        });
    };

    $scope.validate = function () {
        $http({
            method: 'POST',
            url: '/api/auth/validate',
        }).then(function (response) {            
            if (response.data != "") {
                $window.location.href = '/Home/Index';
            }
        });
    };
    $scope.validate();

});