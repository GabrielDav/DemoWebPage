/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>
var App;
(function (App) {
    var HeaderController = (function () {
        function HeaderController($location) {
            this.$location = $location;
        }
        HeaderController.prototype.isActive = function (location) {
            return location === this.$location.path();
        };
        HeaderController.$inject = ["$location"];
        return HeaderController;
    }());
    angular.module("app").controller("HeaderController", HeaderController);
})(App || (App = {}));
