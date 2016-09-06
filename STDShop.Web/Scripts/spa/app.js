/// <reference path="../plugins/angular/angular.js" />
var myApp = angular.module('myModule', []);

myApp.controller("schoolController", schoolController);
myApp.directive("stdShopDirective", stdShopDirective);
myApp.service('ValidatorService', ValidatorService);
schoolController.$inject = ['$scope', 'ValidatorService'];
function schoolController($scope, Validator) {
    $scope.checkNumber = function () {
        $scope.message = Validator.checkNumber(10);
    }
    $scope.num = 1;
}
function ValidatorService($window) {
    return {
        checkNumber:checkNumber
    }
    function checkNumber(input) {
        if (input %2 == 0) {
           return 'this is even';
        } else {
            return 'this is odd';
        }
    }
}
function stdShopDirective() {
    return {
        template: "<h1>this is my first custom directive</h1>"
    }
}