// SitefinityWebapp\Mvc\Scripts\Webinar\DesignerView-Friendly.js

angular.module('designer').requires.push('sfSelectors');

angular.module('designer')
    .controller('FriendlyCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;
        $scope.itemType = "Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar";

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    if ($scope.properties.Start.PropertyValue && !($scope.properties.Start.PropertyValue instanceof Date)) {
                        var startDate = $scope.properties.Start.PropertyValue;
                        // This parsing is specific for UK dates. It may be different depending on your website culture.
                        // Dealing with dates is always a complex matter in the programming :)
                        $scope.properties.Start.PropertyValue = new Date(startDate.split('/')[2], startDate.split('/')[1] - 1, startDate.split('/')[0]);
                    }
                    
                    if ($scope.properties.End.PropertyValue && !($scope.properties.End.PropertyValue instanceof Date)) {
                        var endDate = $scope.properties.End.PropertyValue;
                        $scope.properties.End.PropertyValue = new Date(endDate.split('/')[2], endDate.split('/')[1] - 1, endDate.split('/')[0]);
                    }                    
                }
            }, function (data) {
                $scope.feedback.showError = true;

                if (data) {
                    $scope.feedback.errorMessage = data.Detail;
                }
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });

        $scope.$watch('properties.SelectedItem.PropertyValue', function (newValue, oldValue) {
            if (newValue) {
                $scope.selectedItem = JSON.parse(newValue);
            }
        });

        $scope.$watch('selectedItem', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.SelectedItem.PropertyValue = JSON.stringify(newValue);
            }
        });

    }]);