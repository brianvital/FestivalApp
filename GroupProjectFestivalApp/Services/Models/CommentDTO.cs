using GroupProjectFestivalApp.Domain;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services {
    public class CommentDTO {
        public int Id { get; set; }

        public string Message { get; set; }

        public string AttractionName { get; set; }

        public EventDTO Event { get; set; }

        public ApplicationUserDTO User { get; set; }     

        public int Rating { get; set; }
    }
}
