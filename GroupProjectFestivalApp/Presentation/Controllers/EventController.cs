using GroupProjectFestivalApp.Presentation.Models;
using GroupProjectFestivalApp.Services;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;  
using System.Web.Http;

namespace GroupProjectFestivalApp.Presentation.Controllers {
    public class EventController : ApiController {

        private EventService _eventService;
        private CommentService _commentService;

        public EventController(EventService eventService, CommentService commentService) {
            _eventService = eventService;
            _commentService = commentService;
        }


        [HttpGet]
        [Route("api/events/{id}")]
        public EventDTO Get(int id) {
            return _eventService.GetEvent(id);
        }



        [HttpPost]
        [Authorize]
        [Route("api/events/{id}")]
        public IHttpActionResult AddComment(int id, CommentBindingModel comment) {
            if (ModelState.IsValid) {
                return Ok(_eventService.AddComment(id, User.Identity.Name, comment));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/comments")]
        public IList<CommentDTO> GetComments()
        {
            return _commentService.GetComments();
             
        }
    }
}
