namespace GroupProjectFestivalApp {

    angular.module('GroupProjectFestivalApp', ['ngRoute']);

    angular.module('GroupProjectFestivalApp').factory('authInterceptor',
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
                    return response || $q.when(response);
                }
            };
        });

    angular.module('GroupProjectFestivalApp')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');

            $routeProvider.when('/', {
                templateUrl: '/Presentation/ngApp/views/homeView.html',
                controller: GroupProjectFestivalApp.Controllers.HostController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/login', {
                templateUrl: '/Presentation/ngApp/views/login.html',
                controller: GroupProjectFestivalApp.Controllers.AuthController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/register', {
                templateUrl: '/Presentation/ngApp/views/register.html',
                controller: GroupProjectFestivalApp.Controllers.AuthController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/home', {
                templateUrl: '/Presentation/ngApp/views/homeView.html',
                controller: GroupProjectFestivalApp.Controllers.HostController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/events/:id', {
                templateUrl: '/Presentation/ngApp/views/event.html',
                controller: GroupProjectFestivalApp.Controllers.EventController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/attractions', {
                templateUrl: '/Presentation/ngApp/views/attractionList.html',
                controller: GroupProjectFestivalApp.Controllers.AttractionController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/info/:id', {
                templateUrl: '/Presentation/ngApp/views/attractionInfo.html',
                controller: GroupProjectFestivalApp.Controllers.InfoController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/comments', {
                templateUrl: '/Presentation/ngApp/views/comment.html',
                controller: GroupProjectFestivalApp.Controllers.CommentController,
                controllerAs: 'controller'
            });
            $routeProvider.when('/map/:id', {
                templateUrl: '/Presentation/ngApp/views/map.html',
                controller: GroupProjectFestivalApp.Controllers.MapController,
                controllerAs:'controller'
                
            });
        });


}
