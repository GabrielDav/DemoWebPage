/// <reference path="../models/UserTicket.ts"/>

namespace App {
    
    export interface IApiService {

        getTickets(): ng.IPromise<ng.IHttpPromiseCallbackArg<IUserTicket[]>>;

        saveTicket(ticket: IUserTicket): ng.IPromise<any>;

    }

    class ApiService implements IApiService {

        static $inject = ["$http", "apiUrl"];

        public constructor(private $http: ng.IHttpService, private apiUrl: string) {
        }

        getTickets(): ng.IPromise<ng.IHttpPromiseCallbackArg<IUserTicket[]>> {
            return this.$http.get<IUserTicket[]>(this.apiUrl + "/tickets");
        }

        saveTicket(ticket: IUserTicket): ng.IPromise<any> {
            return this.$http.post(this.apiUrl + "/tickets", ticket);
        }
    }

    angular.module("app").service("ApiService", ApiService);

}