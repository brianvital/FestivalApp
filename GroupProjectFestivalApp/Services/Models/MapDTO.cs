using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services.Models {
    public class MapDTO {

        public string ImageUrl { get; set; }

        public IList<PushpinDTO> Pins { get; set; }
    }
}