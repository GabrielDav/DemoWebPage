/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>
var App;
(function (App) {
    var TicketsListController = (function () {
        function TicketsListController(apiService) {
            this.apiService = apiService;
        }
        TicketsListController.prototype.loadTickets = function () {
            var _this = this;
            this.loading = true;
            this.apiService.getTickets().then(function (response) {
                _this.tickets = response.data;
            }).finally(function () { _this.loading = false; });
        };
        TicketsListController.$inject = ["ApiService"];
        return TicketsListController;
    }());
    angular.module("app").controller("TicketsListController", TicketsListController);
})(App || (App = {}));
