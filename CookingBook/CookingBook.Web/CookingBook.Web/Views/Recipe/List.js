cookingBookApp.controller('recipeListController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {

    $scope.isBusy = false;
    $scope.searchName = '';
    $scope.listRecipe;
    $scope.isNewRecipe;
    $scope.recipe;
    $scope.ingredient;
    
    $scope.getRecipesByName = function () {        
        $http({
            method: 'POST',
            url: rootDir + 'api/recipe/getrecipesbyname/' + $scope.searchName,            
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
            url: rootDir + 'api/recipe/getrecipebyid/' + id,            
        }).then(function (response) {            
            $scope.recipe = response.data;
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });   
        $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
    };  

    $scope.updateRecipe = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/recipe/updaterecipe',
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
        $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
    };  

    $scope.addNewRecipe = function () {        
        $http({
            method: 'POST',
            url: rootDir + 'api/recipe/addnewrecipe',
            data: $scope.recipe,
        }).then(function (response) {
            
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };  

    $scope.addIngredient = function () {        
        $scope.recipe.ingredients.push({ name: $scope.ingredient});        
    };     
});