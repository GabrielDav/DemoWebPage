namespace App {

    var app = angular.module('app');

    app.config([
        '$routeProvider',
        '$locationProvider',
        ($routeProvider, $locationProvider) => {

            $routeProvider
                .when('/', {
                    templateUrl: 'views/contact-us.html',
                    controller: 'TicketController',
                    controllerAs: 'ctrl'
                }).when('/contact-us', {
                    templateUrl: 'views/contact-us.html',
                    controller: 'TicketController',
                    controllerAs: 'ctrl'
                }).when('/tickets', {
                    templateUrl: 'views/tickets.html',
                    controller: 'TicketsListController',
                    controllerAs: 'ctrl'
                }).otherwise({
                    templateUrl: 'views/not-found.html'
                });

            $locationProvider.html5Mode(false);
        }]);

}