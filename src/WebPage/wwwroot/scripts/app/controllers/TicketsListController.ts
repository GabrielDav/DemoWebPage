/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>

namespace App {

    export interface ITicketsListController {
        tickets: IUserTicket[];
        loading: boolean;
    }

    class TicketsListController implements ITicketsListController {

        static $inject = ["ApiService"];

        tickets: IUserTicket[];
        loading: boolean;
        
        constructor(private apiService: IApiService) {

        }

        loadTickets(): void {
            this.loading = true;
            this.apiService.getTickets().then(response => {
                this.tickets = response.data;
            }).finally(() => { this.loading = false });
        }
    }

    angular.module("app").controller("TicketsListController", TicketsListController);

}