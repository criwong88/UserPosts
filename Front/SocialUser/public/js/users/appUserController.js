appConnect.controller("appUserController", function ($scope, $controller,$http)
{
     //Instancia del controlador speakController
    $controller('appLoginController', {
        $scope: $scope
    });

    $scope.Init = function(){
        console.log($scope.token);
    }

});