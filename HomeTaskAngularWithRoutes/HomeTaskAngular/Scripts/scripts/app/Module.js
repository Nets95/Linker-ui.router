(function (angular) {
    var app = angular.module("linkModule", ['ui.router'])
         .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
             $stateProvider
                 .state('table', {
                     url: '/table',
                     templateUrl: '/Scripts/scripts/app/Templates/Table.html'
                 })
                 .state('search', {
                     url:'/search',
                     templateUrl: '/Scripts/scripts/app/Templates/Search.html'
                 })
                 .state('add', {
                     url:'/add',
                     templateUrl: '/Scripts/scripts/app/Templates/Add.html'
                 });
                 $urlRouterProvider.otherwise('/table');
         }]);
})(angular);