'use strict';

angular.module('TaskManager', [
    'ngRoute',
    'ngAnimate',
    'ngMessages'
])
    .config(['$routeProvider',function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController'
            })
    }]);