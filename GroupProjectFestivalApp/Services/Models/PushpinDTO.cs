using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services.Models {
    public class PushpinDTO {

        public int Id { get; set; }

        public HostDTO Host { get; set; }

        public string Name { get; set; }

        public IList<string> Events { get; set; }
        
        public string Category { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }
    }
}