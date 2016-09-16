/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>
var App;
(function (App) {
    var TicketsController = (function () {
        function TicketsController(apiService) {
            this.apiService = apiService;
        }
        TicketsController.prototype.save = function (ticket) {
            var _this = this;
            this.submitting = true;
            this.apiService.saveTicket(ticket).then(function () {
                _this.success = true;
            }, function () {
                _this.error = true;
            }).finally(function () {
                _this.submitting = false;
            });
        };
        TicketsController.prototype.retry = function () {
            this.error = false;
        };
        TicketsController.$inject = ["ApiService"];
        return TicketsController;
    }());
    angular.module("app").controller("TicketController", TicketsController);
})(App || (App = {}));
