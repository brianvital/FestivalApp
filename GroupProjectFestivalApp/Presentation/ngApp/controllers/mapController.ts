namespace GroupProjectFestivalApp.Controllers {

    export class MapController {

        public categories: any = {};
        public map;

        constructor(private $http, private $routeParams) {
            this.$http.get(`/api/pins/${$routeParams.id}`)
                .then((response) => {
                    this.map = response.data;
                });
        }

        public togglePin(category: string) {
            for (let key in this.categories) {
                this.categories[key] = false;
        
            }
            this.categories[category] = true;            
        }
    }
}