angular.module('iadv')
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
    .controller('portfolioController', function ($scope, $sce, dataService) {
        $scope.tags = [],
        $scope.projects = [],
        $scope.filteredTags = [],
        $scope.projectsLoaded = true,

        $scope.initData = function () {
            var saved = StateManager.getData(Helper.statePortfolioKey);
            if (saved != undefined) {
                $scope.tags = saved.tags;
                $scope.projects = saved.projects;
                $scope.projectsLoaded = true;
                return;
            }

            $scope.projectsLoaded = false;
            dataService.getPortfolioData()
            .then(function (data) {
                $scope.tags = data.tags;
                $scope.projects = data.projects;
                $scope.projectsLoaded = true;
                StateManager.setData(Helper.statePortfolioKey, data);
            });
        },

        $scope.buildPerion = function (project) {
            return project.startDate + ' - ' + project.endDate;
        },

        $scope.displaySafeHtml = function (html) {
            return $sce.trustAsHtml(html);
        },

        $scope.displayMoreInfo = function (project) {
            project.showAdvInfo = true;
        },

        $scope.elementInFilter = function (tag) {
            var ind = $scope.filteredTags.indexOf(tag);
            if (ind == -1)
                $scope.filteredTags.push(tag);
            else
                $scope.filteredTags.splice(ind, 1);
        };

        $scope.tagsFilter = function (project) {
            if ($scope.filteredTags.length == 0)
                return true;
            var cnt = Helper.intersect(project.tags, $scope.filteredTags);
            return cnt.length > 0;
        };
    })
;