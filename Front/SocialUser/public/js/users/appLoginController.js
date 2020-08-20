appConnect.controller("appLoginController", function ($scope, $controller,$http)
{
    $scope.User = "";
    $scope.Pass = "";
    $scope.Name = "";
    $scope.Phone = "";
    $scope.basePath = "http://localhost:64387";

    $scope.Login = function ()
    {
        $http({
            url: $scope.basePath+'/api/Account/Login',
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': 'POST',
                'Access-Control-Allow-Headers': 'Origin, Methods, Content-Type'
            },
            data: 
                {
                    Email:$scope.User,
                    Password:$scope.Pass
                }
        }).then(function (response)
        {
            console.log("ok");
            loginGrant(response.data['token'],response.data['expiration']);

        },function (response)
        {
            Swal.fire({
                position: 'top-end',
                icon: 'Error',
                title: '<div><h3>Access Denny<h3></div>'+
                        '<div><h6>Verifique los datos</h6></div>',
                showConfirmButton: false,
                timer: 3500
              })
        });
    }

    function loginGrant(token,validTime){

        $scope.token=token;
        $scope.validTime= validTime;

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Access Grant',
            showConfirmButton: false,
            timer: 3500
          })
        
          window.location="./Access";

    };

    $scope.registerUser = function(){

        $http({
            url: $scope.basePath+'/api/Account/Create',
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': 'POST',
                'Access-Control-Allow-Headers': 'Origin, Methods, Content-Type'
            },
            data: 
            {
                "UserName": $scope.User,
                "Email": $scope.User,
                "Password": $scope.Pass
            }
        }).then(function (response)
        {
            SetUserShow(response.data['token'],response.data['expiration']);

        },function (response)
        {
            Swal.fire({
                position: 'top-end',
                icon: 'error',
                title: '<div><h3>No se pude tramitar la Peticion<h3></div>',
                showConfirmButton: false,
                timer: 3500
              })
        });
    }

    function SetUserShow(token,validTime){

        $http({
            url: $scope.basePath+'/api/User',
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': 'POST',
                'Access-Control-Allow-Headers': 'Origin, Methods, Content-Type',
                "Authorization": "Bearer "+token,
                "Content-Type": "application/x-www-form-urlencoded"
            },
            data: 
                {
                    "Name":"cristian", 
                    "Phone":"3117917078", 
                    "Email":"criwong8812@gmail.com",
                    "Pass": "Gara88"
                }
        }).then(function (response)
        {
            console.log("ok");
            window.location="./";

            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: '<div><h3>Usuario Registrado<h3></div>',
                showConfirmButton: false,
                timer: 3500
              })

        },function (response)
        {
            Swal.fire({
                position: 'top-end',
                icon: 'error',
                title: '<div><h3>No se pude tramitar la Peticion<h3></div>',
                showConfirmButton: false,
                timer: 3500
              })
        });
        
          

    };
});