/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>

namespace App {

    export interface IHeaderController {
        isActive(location: string): boolean;
    }

    class HeaderController implements IHeaderController {

        static $inject = ["$location"];
        

        constructor(private $location: ng.ILocationService) {

        }

        isActive(location: string): boolean {
            return location === this.$location.path();
        }
    }

    angular.module("app").controller("HeaderController", HeaderController);

}