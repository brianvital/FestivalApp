namespace GroupProjectFestivalApp.Controllers {

    export class EventController {

        public event;
        public comments;

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/events/${$routeParams.id}`)
                .then((response) => {
                    this.event = response.data;
                });
        }

        public addComment(comment): void {
            if (comment) {
                this.$http.post(`api/events/${this.event.id}`, comment)

                    .then((response) => {
                        let eventDto: any = response.data; // eventdto
                        this.event.rating = eventDto.rating;
                        this.event.attraction.rating = eventDto.attraction.rating;

                        alert('Thank you for your feedback!');
                    })
                    .catch((response) => {
                        alert('There was an error. Sorry :(');
                    });
            }
        }



    }
}
