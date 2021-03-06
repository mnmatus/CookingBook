﻿cookingBookApp.controller('indexController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {

    $scope.listIngredients;
    $scope.listUserRecipe;
    $scope.recipeId;
    var getRecipesByUser = function () {        
        $http({
            method: 'GET',
            url: '/api/recipe/getrecipesbyuser',
        }).then(function (response) {   
            $scope.listUserRecipe = response.data;
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };    
    getRecipesByUser();
    $scope.recipeSelected = function () {
        if (!$scope.recipeId) {
            $scope.listIngredients = [];
        }
        else {
            $http({
                method: 'GET',
                url: '/api/recipe/getrecipebyid/' + $scope.recipeId,
            }).then(function (response) {                
                $scope.listIngredients = response.data.ingredients;
            }).catch(function () {
                $('#modal-error').find('.modal-body').text('Unexpected error encountered');
                $('#modal-error').modal('show');
            });   
        };       
        
    };

    $scope.toggleIngredientSelection = function (event, id) {        
        $http({
            method: 'POST',
            url: '/api/ingredient/updateingredient/',
            data: { Id: id, IsChecked: event.target.checked }
        }).then(function (response) {           
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });   
        
    };

    $scope.resetSelection = function () {
        if (!$scope.recipeId) {
            return;
        }
        else {
            $http({
                method: 'POST',
                url: '/api/ingredient/resetingredientsselection/' + $scope.recipeId,
            }).then(function (response) {
                //$scope.listIngredients = response.data.ingredients;
                debugger;
                angular.forEach($scope.listIngredients, function (value, key) {
                    debugger;
                    value.isChecked = false;
                    //var index = $scope.listConsignment.findIndex(c => c.GuidId === value.GuidId);
                    //$scope.listIngredients[index] = value;
                });
            }).catch(function () {
                $('#modal-error').find('.modal-body').text('Unexpected error encountered');
                $('#modal-error').modal('show');
            });
        };

    };
});