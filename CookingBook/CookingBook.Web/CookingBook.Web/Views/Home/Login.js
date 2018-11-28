cookingBookApp.controller('loginController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {
    $scope.userName;
    $scope.password;
    $scope.login = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/user/authenticate',
            data: {
                    UserName: $scope.userName,
                    Password: $scope.password,                
                  },
        }).then(function (response) {
            debugger;
            userToken.set(response.data.token);
            $window.location.href = rootDir + 'Home/Index';
        }).catch(function (response) {
            $scope.errorMessage = response.data.error_description;
            $scope.password = '';
            $scope.isNotValid = true;
            if (response.data.error_description = 'Invalid username and/or password.') {
                $scope.userName = '';
            };
            $scope.frmLogin.$setPristine();
        });
    };

    $scope.validate = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/auth/validate',
        }).then(function (response) {
            debugger;
            if (response.data != "") {
                $window.location.href = rootDir + 'Home/Index';
            }
        });
    };

    $scope.validate = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/auth/validate',
        }).then(function (response) {
            debugger;
            if (response.data != "") {
                $window.location.href = rootDir + 'Home/Index';
            }
        });
    };
    $scope.validate();

});