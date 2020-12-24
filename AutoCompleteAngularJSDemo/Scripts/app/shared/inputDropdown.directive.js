(function (app) {
    'use strict';

    app.directive('inputDropdown', inputDropdown);

    inputDropdown.$inject = ['apiService'];

    function inputDropdown(apiService) {
        return {
            restrict: 'E',
            scope: {
                inputName: '@',
                inputPlaceholder: '@',
                customModel: '=ngModel',
                selectedItem: '=selectedItem',
                remoteUrl: '@',
                required: '@'
            },
            templateUrl: '/scripts/app/shared/inputDropdown.html',

            link: function ($scope, $element, $attrs) {
                $scope.dropdownVisible = false;

                $scope.inputChange = function () {
                    var value = btoa(unescape(encodeURIComponent($scope.customModel)));
                    apiService.get($scope.remoteUrl + '/' + value, null,
                    categoryLoadCompleted,
                    categoryLoadFailed);
                };

                $scope.inputFocus = function () {
                    var value = btoa(unescape(encodeURIComponent($scope.customModel)));
                    apiService.get($scope.remoteUrl + '/' + value, null,
                    categoryLoadCompleted,
                    categoryLoadFailed);
                };

                function categoryLoadCompleted(result) {
                    $scope.dropdownItems = result.data;
                    if (result.data.length > 0)
                        showDropdown();
                    else
                        hideDropdown();
                }

                function categoryLoadFailed(result) {
                    hideDropdown();
                }

                $scope.inputBlur = function (event) {
                    if ($scope.pressedDropdown) {
                        // Blur event is triggered before click event, which means a click on a dropdown item wont be triggered if we hide the dropdown list here.
                        $scope.pressedDropdown = false;
                        return;
                    }
                    hideDropdown();
                };

                $scope.dropdownPressed = function () {
                    $scope.pressedDropdown = true;
                }

                var showDropdown = function () {
                    $scope.dropdownVisible = true;
                };
                var hideDropdown = function () {
                    $scope.dropdownVisible = false;
                }

                $scope.selectItem = function (item) {
                    $scope.selectedItem = item;
                    $scope.customModel = item.Name;
                    hideDropdown();
                    $scope.dropdownItems = [item];
                };
            }
        }
    }

})(angular.module('common.ui'));