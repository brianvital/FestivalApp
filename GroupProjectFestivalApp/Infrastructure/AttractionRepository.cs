using GroupProjectFestivalApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Infrastructure {
    public class AttractionRepository : GenericRepository<Attraction> {
        public AttractionRepository(DbContext db) : base(db) { }
    }
}