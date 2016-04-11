using GroupProjectFestivalApp.Services;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProjectFestivalApp.Presentation.Controllers
{
    public class InfoController : ApiController
    {
        private AttractionService _attractionService;
        private EventService _eventService;

        public InfoController(AttractionService attractionService, EventService eventService)
        {

            _attractionService = attractionService;
            _eventService = eventService;
        }
        [HttpGet]
        [Route("api/info/{id}")]
        public AttractionDTO GetAttraction(int id)
        {

            return _attractionService.GetAttraction(id);
        }       
    }
}

