using GroupProjectFestivalApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Infrastructure {
    public class CommentRepository : GenericRepository<Comment> {
        public CommentRepository(DbContext db) : base(db) { }
    }
}
