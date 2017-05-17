var app = angular.module('myApp', ['ngRoute'])

//I need to refactor this config portion into a new file
//then I need to name that file to shoppinglist-config.js
.config(['$routeProvider', function($routeProvider){
	$routeProvider
		.when('/', {
			templateUrl: "views/home.html"
		}).otherwise({
			redirectTo: '/home'
		})
		.when('/home', {
			templateUrl: "views/home.html",
			controller: "HomeController"
		})
		.when('/shopping-list', {
			templateUrl: "views/shopping-list.html",
			controller: "ShoppingListController",
			controllerAs: "shoplist"
		}).otherwise({
			redirectTo: '/home'
		});
}]);