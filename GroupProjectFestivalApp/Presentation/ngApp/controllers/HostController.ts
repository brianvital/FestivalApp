namespace GroupProjectFestivalApp.Controllers {

    export class HostController {

        public hosts;
        
        constructor(private $http: ng.IHttpService) {
            $http.get('/api/hosts')
                .then((response) => {
                    this.hosts = response.data;
                });
        }

    }
}
