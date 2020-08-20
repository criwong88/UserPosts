
@extends('layout.basic')
@section('head')

<script src="./js/mdb.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="./bower_components/angular/angular.js"></script>
<script src="./bower_components/sweetalert2.js"></script>

<script src="./js/appConnect.js"></script>
<script src="./js/users/appUserController.js"></script>
<script src="./js/users/appLoginController.js"></script>



<body ng-app="appConnect" ng-controller="appUserController" ng-init="Init()">

    <h1 ng-model="token">hola {$ $scope.token $} <h2>

</body>