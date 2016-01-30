namespace TradeOffProject {

    angular.module('TradeOffProject', ['ngRoute', 'ui.bootstrap']);

    angular.module('TradeOffProject').factory('authInterceptor',
        ($q: ng.IQService, $window: ng.IWindowService, $location: ng.ILocationService) => {
            return {
                request: (config) => {
                    config.headers = config.headers || {};
                    let token = $window.localStorage.getItem('token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                },
                responseError: (response) => {
                    if (response.status === 401) {
                        $location.path('/login');
                    }
                    return $q.reject(response);
                }
            };
        });

    angular.module('TradeOffProject')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');

            $routeProvider
                .when('/', {
                    templateUrl: '/Presentation/ngApp/views/home.html',
                    controller: TradeOffProject.Controllers.AuthController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/register', {
                    templateUrl: '/Presentation/ngApp/views/register.html',
                    controller: TradeOffProject.Controllers.AuthController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/gallery', {
                    templateUrl: '/Presentation/ngApp/views/tradePostGallery.html',
                    controller: TradeOffProject.Controllers.TradePostGalleryController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/addpost', {
                    templateUrl: '/Presentation/ngApp/views/addTradePost.html',
                    controller: TradeOffProject.Controllers.AddPostsController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/about', {
                    templateUrl: '/Presentation/ngApp/views/about.html'
                });
        });
}