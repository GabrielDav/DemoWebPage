/// <reference path="../services/ApiService.ts"/>
/// <reference path="../models/UserTicket.ts"/>

namespace App {

    export interface ITicketsController {
        error: boolean;
        success: boolean;
        submitting: boolean;
    }

    class TicketsController implements ITicketsController {

        static $inject = ["ApiService"];
        
        error: boolean;
        success: boolean;
        submitting: boolean;

        
        constructor(private apiService: IApiService) {
            
        }

        save(ticket: IUserTicket): void {
            this.submitting = true;
            this.apiService.saveTicket(ticket).then(() => {
                this.success = true;
            },
                () => {
                    this.error = true;
                }).finally(() => {
                    this.submitting = false;
            });
        }

        retry(): void {
            this.error = false;
        }
        
    }

    angular.module("app").controller("TicketController", TicketsController);

}