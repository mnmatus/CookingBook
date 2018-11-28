cookingBookApp.controller('recipeListController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {

    $scope.isBusy = false;
    $scope.searchName = '';
    $scope.listRecipe;
    $scope.isNewRecipe;
    $scope.recipe;
    $scope.ingredient;
    
    $scope.getRecipesByName = function () {        
        $http({
            method: 'GET',
            url: '/api/recipe/getrecipesbyname/' + $scope.searchName,            
        }).then(function (response) {            
            $scope.listRecipe = response.data;              
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };    

    $scope.removeIngredient = function (index) {
        $scope.recipe.ingredients.splice(index, 1);
    };  

    $scope.openEditRecipe = function (id) {
        $http({
            method: 'GET',
            url: '/api/recipe/getrecipebyid/' + id,            
        }).then(function (response) {            
            $scope.recipe = response.data;
            $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
            $scope.frmRecipe.$setPristine();
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
            $('#modalFrmRecipe').modal("hide");
        });   
       
    };  

    $scope.updateRecipe = function () {
        if (!$scope.frmRecipe.$valid) {
            $scope.validateForm($scope.frmRecipe.$error);
            return;
        };

        $http({
            method: 'POST',
            url: '/api/recipe/updaterecipe',
            data: $scope.recipe,
        }).then(function (response) {
            $('#modalFrmRecipe').modal("hide");
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };  


    $scope.openAddNewRecipe = function () {          
        $scope.recipe = { name: '', ingredients: [] }
        $scope.isNewRecipe = true;
        $scope.frmRecipe.$setPristine();
        $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
    };  

    $scope.addNewRecipe = function () {  
        if (!$scope.frmRecipe.$valid) {
            $scope.validateForm($scope.frmRecipe.$error);
            return;
        };
        $http({
            method: 'POST',
            url: '/api/recipe/addnewrecipe',
            data: $scope.recipe,
        }).then(function (response) {
            $scope.listRecipe.push($scope.recipe);
            $('#modalFrmRecipe').modal("hide");
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };  

    $scope.addIngredient = function () {        
        $scope.recipe.ingredients.push({ name: $scope.ingredient});        
    };     
});