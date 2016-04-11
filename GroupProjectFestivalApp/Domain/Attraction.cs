using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Domain
{
    public class Attraction : IDbEntity, IActivatable
    {

        public int Id { get; set; }

        public string Sound { get; set; }

        public string PictureUrl { get; set; }

        public IList<Event> Events { get; set; }

        public string Name { get; set; }

        public IList<Tag> Tags { get; set; }

        public string Description { get; set; }

        public Host Host { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public bool Active { get; set; } = true;
    }
}