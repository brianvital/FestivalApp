namespace GroupProjectFestivalApp.Controllers {

    export class AttractionController {

        public attractions;

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/attractions`)
                .then((response) => {
                    this.attractions = response.data;
                });
        }
    }
}