/// <reference path="../typings/angular/angular.d.ts" />
var appModule = angular.module("app", ["ngRoute", "ui.bootstrap"]);
// constants
appModule.constant("apiUrl", "http://localhost:5000/api");
