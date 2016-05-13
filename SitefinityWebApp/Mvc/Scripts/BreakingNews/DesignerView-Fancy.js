angular.module('designer')
    .controller('FancyCtrl', ['$scope', 'properyService', function ($scope, properyService) {
        $scope.feedback.showLoadingIndicator = true;

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);
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

        // Build breaking news message form Date and Message widget properties
        $scope.buildBreakingNewsMessage = function () {
            $scope.properties.BreakingNewsMessage.PropertyValue = $scope.properties.Date.PropertyValue + ' : ' + $scope.properties.Message.PropertyValue;
        };
    }]);