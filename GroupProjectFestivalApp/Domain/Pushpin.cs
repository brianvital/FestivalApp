using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain {
    public class Pushpin {

        public int Id { get; set; }
        
        public Host Host { get; set; }

        public string Name { get; set; }

        public IList<Event> Events { get; set; }

        public bool Active { get; set; } = true;

        public int Left { get; set; }
        
        public int Top { get; set; }

        public string Category { get; set; }
    }
}