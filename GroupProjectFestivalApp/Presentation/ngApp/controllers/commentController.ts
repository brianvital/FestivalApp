namespace GroupProjectFestivalApp.Controllers {
    export class CommentController {
        
        public comments;        

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/comments`)
                .then((response) => {
                    this.comments = response.data;
                });
        }
    }
}
