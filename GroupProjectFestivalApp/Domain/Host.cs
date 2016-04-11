using GroupProjectFestivalApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain {
    public class Host : IDbEntity, IActivatable {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IList<Pushpin> Pushpins { get; set; }

        public IList<Event> Events { get; set; }

        public IList<Attraction> Attractions { get; set; }

        public ApplicationUser User { get; set; }

        public bool Active { get; set; } = true;
    }
}