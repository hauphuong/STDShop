/// <reference path="../plugins/angular/angular.js" />
var myApp = angular.module('myModule', []);
//myApp.controller("myController", myController);
//myController.$inject = ['$scope'];
//declare
//function myController($scope) {
//    $scope.message = "This is my message from controller";
//}
myApp.controller("schoolController", schoolController);
myApp.controller("studentController", studentController);
myApp.controller("teacherController", teacherController);

function schoolController($scope) {
    $scope.message = "This is my message from school controller";
}
function studentController($rootScope, $scope) {
     $scope.message = "This is my message from student controller";
     //$rootScope.message = "This is my message from student controller";
}
function teacherController($scope) {
    $scope.message = "This is my message from teacher controller";
}