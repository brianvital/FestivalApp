namespace GroupProjectFestivalApp.Controllers {

    export class InfoController {

        public info;

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/info/${$routeParams.id}`)
                .then((response) => {
                    this.info = response.data;
                });

        }

    }
}