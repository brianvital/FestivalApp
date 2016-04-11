using GroupProjectFestivalApp.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public IDbSet<Host> Hosts { get; set; }
        public IDbSet<Attraction> Attractions { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<Pushpin> Pushpins { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<Comment> Comments { get; set; }
    }
}