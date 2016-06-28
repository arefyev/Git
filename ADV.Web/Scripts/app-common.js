angular.module('iadv', ['ui.router', 'ngAnimate', 'ui.bootstrap'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("profile");

        $stateProvider
            .state('profile', { url: "/profile", templateUrl: "profile" })
            .state('experience', { url: "/experience", templateUrl: "experience" })
            .state('portfolio', { url: "/portfolio", templateUrl: "portfolio" });
    })
    .directive("stickyNav", function stickyNav($window) {
        function stickyNavLink(scope, element) {
            var w = angular.element($window);

            function toggleStickyNav() {
                var size = element[0].clientHeight,
                top = angular.element(document.querySelector(".main-content"))[0].offsetTop;
                if (angular.element(document.querySelector(".scroller"))[0].scrollTop > angular.element(document.querySelector("header"))[0].offsetHeight + top) {
                    element.addClass('fixed');
                    element.removeClass('normal');
                    element.css("width", document.getElementsByClassName('container')[0].clientWidth + 'px');
                    // angular.element(document.querySelector(".content")).css("marginTop", size + 'px');
                } else {
                    element.removeClass('fixed');
                    element.addClass('normal');
                    //  angular.element(document.querySelector(".content")).css('marginTop', '0');
                    element.css('width', 'auto');
                }
            }
            w.bind('resize', function stickyNavResize() {
                element.removeClass('fixed');
                toggleStickyNav();

            });
            //.slim-scroll-wrapper -> scroller
            angular.element(document.querySelector(".scroller")).bind('scroll', function () { toggleStickyNav() });
        }

        return {
            scope: {},
            restrict: 'A',
            link: stickyNavLink
        };
    })
    .directive('activeLink', ['$location', function (location) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs, controller) {
                var clazz = attrs.activeLink;
                var path = attrs.href.substring(1);
                scope.location = location;
                scope.$watch('location.path()', function (newPath) {
                    if (path === newPath) {
                        element.parent().addClass(clazz);
                    } else {
                        element.parent().removeClass(clazz);
                    }
                });
            }
        };
    }])
    .directive('filteredlink', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    if (element.hasClass("active")) {
                        element.removeClass("active")
                    } else {
                        element.addClass("active")
                    }
                });
            }
        };
    })
    .service('apiCall', ['$http', '$q', function ($http, $q) {
        var res;
        this.postFata = function (controller, method, data) {
            var deferred = $q.defer();
            res = $http.post('api/' + controller + '/' + method, data)
              .success(function (result, status) {
                  deferred.resolve(result);
              })
              .error(function (msg, status) {
                  deferred.reject(msg);
                  // handle error
              });
            return deferred.promise;
        }
    }]);