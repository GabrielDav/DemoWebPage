/// <reference path="../models/UserTicket.ts"/>
var App;
(function (App) {
    var ApiService = (function () {
        function ApiService($http, apiUrl) {
            this.$http = $http;
            this.apiUrl = apiUrl;
        }
        ApiService.prototype.getTickets = function () {
            return this.$http.get(this.apiUrl + "/tickets");
        };
        ApiService.prototype.saveTicket = function (ticket) {
            return this.$http.post(this.apiUrl + "/tickets", ticket);
        };
        ApiService.$inject = ["$http", "apiUrl"];
        return ApiService;
    }());
    angular.module("app").service("ApiService", ApiService);
})(App || (App = {}));
