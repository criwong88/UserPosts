
@extends('layout.basic')
@section('head')

<script src="./js/mdb.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="./bower_components/angular/angular.js"></script>
<script src="./bower_components/sweetalert2.js"></script>

<script src="./js/appConnect.js"></script>
<script src="./js/users/appLoginController.js"></script>


<!------ Include the above in your HEAD tag ---------->

<body ng-app="appConnect" ng-controller="appLoginController">
    <div id="login">
        <h3 class="text-center text-white pt-5">Register Form</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="login-form" class="form">
                            <h3 class="text-center text-info">Login</h3>
                            <div class="form-group">
                                <label for="username" class="text-info">Nombre:</label><br>
                                <input type="text" name="name" id="name" class="form-control"  ng-model="Name">
                            </div>
                            <div class="form-group">
                                <label for="username" class="text-info">Telefono:</label><br>
                                <input type="text" name="telefono" id="telefono" class="form-control"  ng-model="Phone">
                            </div>
                            <div class="form-group">
                                <label for="username" class="text-info">Correo:</label><br>
                                <input type="text" name="username" id="username" class="form-control" ng-model="User">
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info">Password:</label><br>
                                <input type="password" name="password" id="password" class="form-control" ng-model="Pass">
                            </div>
                            <hr>
                            <div class="form-group">
                                <input class="btn btn-info btn-md" value="Crear" ng-click="registerUser()">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>