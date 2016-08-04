angular.module('root', [])
    .controller("index", ["$scope", function ($scope) {
        $scope.message = "Hello World";
        $scope.city = "Toronto";

        // Repeaters
        $scope.products = [
			{ id: 1, name: "Hockey puck" },
			{ id: 2, name: "Golf club" },
			{ id: 3, name: "Baseball bat" },
			{ id: 4, name: "Lacrosse stick" }
        ];

        // Css binding
        $scope.value = 1
        $scope.isBold = function () { return $scope.value % 2 === 0; };
        $scope.isItalic = function () { return $scope.value % 3 === 0; };
        $scope.isUnderlined = function () { return $scope.value % 5 === 0; };

        // 2 ways binding
        $scope.favoriteWord;
        $scope.favoriteColor;
        $scope.favoriteShape;

        // Visibiity: ng-show; ng-hide; ng-if
        $scope.isFirstElementVisible = true;
        $scope.isSecondElementVisible = true;
    }]);

