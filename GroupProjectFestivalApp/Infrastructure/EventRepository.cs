using GroupProjectFestivalApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Infrastructure {
    public class EventRepository : GenericRepository<Event> {
        public EventRepository(DbContext db) : base(db) { }
    }

}