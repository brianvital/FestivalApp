using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services.Models {
    public class AttractionDTO {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string PictureUrl { get; set; }

        public string SoundUrl { get; set; }

        public IList<EventDTO> Events { get; set; }
    }
}