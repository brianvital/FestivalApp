using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain {
    public class Tag {

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Attraction> Attractions { get; set; }

        public IList<Event> Events { get; set; }

        public bool Active { get; set; } = true;

    }
}