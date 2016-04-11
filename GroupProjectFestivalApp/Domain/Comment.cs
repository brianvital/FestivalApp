using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain {
    public class Comment : IDbEntity, IActivatable {

        public int Id { get; set; }

        public Event Event { get; set; }

        public ApplicationUser User { get; set; }

        public string Message { get; set; }

        public string PictureUrl { get; set; }

        public bool Active { get; set; } = true;
    }
}
