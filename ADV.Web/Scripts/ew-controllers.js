angular.module('ew', ['ui.router', 'ngAnimate', 'ui.bootstrap'])
    .factory('dataService', function ($http, apiCall) {
        return {
            getPortfolioData: function (/*item*/) {
                return apiCall.postFata('data', 'getPortfolioData').then(
                  function (response) {
                      return response;
                  });
            },
        }
    })
    .controller('homeController', function ($scope, $rootScope) {

    })
    .controller('wordsController', function ($scope, $rootScope) {
        $scope.words = [],

        $scope.addWord = function () {
            console.log($scope.words);
            $scope.words.push({ "word": "", "translate": "", "type": "0" });
        }
    })