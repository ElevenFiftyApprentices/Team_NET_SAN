angular.module('myApp')

//I need to refactor this config portion into a new file
//then I need to name that file to shoppinglist-config.js
.controller('ShoppingListController', ['$scope', 'ShoppingListItems', function($scope, ShoppingListItems){
	var shoplist = $scope;
	shoplist.items = ShoppingListItems.getList();
	//create a new item function
	shoplist.addItem = function(newItem) {

		shoplist.items.push({
			name: shoplist.newItem.name,
			qty: shoplist.newItem.qty,
			priority: shoplist.newItem.priority
		});

		//clear the form

		shoplist.newItem.name = "";
		shoplist.newItem.qty = "";
		shoplist.newItem.priority = "";
	};

	//delete a single item
	shoplist.removeItem = function(item) {
		var removedItem = shoplist.items.indexOf(item);
		shoplist.items.splice(removedItem, 1);
	};
	//delete the entire list
	shoplist.removeAll = function() {
		shoplist.items = [];
	}
}]);