using GroupProjectFestivalApp.Services;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProjectFestivalApp.Presentation.Controllers {

    public class AttractionController : ApiController {

        private AttractionService _attractionService;

        public AttractionController(AttractionService attractionService) {

            _attractionService = attractionService;
        }
        

        [HttpGet]
        [Route("api/attractions")]
        public IList<AttractionDTO> GetAttractions( ) {
            return _attractionService.GetAttractions();
        }
    }
}
