using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain {

    public class Event : IDbEntity, IActivatable {

        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IList<ApplicationUser> Users { get; set; }

        public Pushpin Pushpin { get; set; }

        public Attraction Attraction { get; set; }

        public IList<Tag> Tags { get; set; }

        public Host Host { get; set; }

        public IList<Comment> Comments { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public bool Active { get; set; } = true;

    }
}