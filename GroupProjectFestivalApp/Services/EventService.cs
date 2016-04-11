using GroupProjectFestivalApp.Domain;
using GroupProjectFestivalApp.Infrastructure;
using GroupProjectFestivalApp.Presentation.Models;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services {
    public class EventService {
        private EventRepository _eventRepo;
        private AttractionRepository _attractionRepo;
        private UserRepository _userRepo;
        private CommentRepository _commentRepo;

        public EventService(EventRepository eventRepo, AttractionRepository attractionRepo, UserRepository userRepo, CommentRepository commentRepo) {
            _eventRepo = eventRepo;
            _attractionRepo = attractionRepo;
            _userRepo = userRepo;
            _commentRepo = commentRepo;
        }
        public EventDTO GetEvent(int id) {

            return (from e in _eventRepo.List()
                    where e.Id == id
                    select new EventDTO() {
                        Id = e.Id,
                        StartTime = e.StartTime,
                        EndTime = e.EndTime,
                        AttendanceCount = e.Users.Count(),
                        Pushpin = new PushpinDTO() {
                            Name = e.Pushpin.Name,
                        },
                        Attraction = new AttractionDTO() {
                            Name = e.Attraction.Name,
                            Description = e.Attraction.Description,
                            Rating = (int)e.Attraction.Rating,
                            SoundUrl = e.Attraction.Sound,
                            PictureUrl = e.Attraction.PictureUrl
                        },
                        Tags = (from t in e.Tags
                                select t.Name).ToList(),
                        Host = e.Host.Name,
                        Rating = (int)e.Rating,
                    }).FirstOrDefault();
        }
        public EventDTO AddComment(int eventId, string userName, CommentBindingModel newComment) {
            var eve = _eventRepo.Get(eventId)
                .Include(e => e.Attraction.Events)
                .Include(e => e.Comments)
                .FirstOrDefault();

            var user = _userRepo.FindByUsername(userName).FirstOrDefault();

            var oldRating = eve.Rating;
            int numComments = eve.Comments.Count;
            eve.Rating = (eve.Rating * numComments + newComment.Rating) / (numComments + 1);

            int numEvents = eve.Attraction.Events.Count;

            eve.Attraction.Rating = (eve.Attraction.Rating * numEvents - oldRating + eve.Rating) / numEvents;

            var comment = new Comment() {
                Message = newComment.Message,
                Event = eve,
                User = user
            };
            _commentRepo.Add(comment);
            _commentRepo.SaveChanges();

            return new EventDTO() {
                Rating = (int)eve.Rating,
                Attraction = new AttractionDTO() {
                    Rating = (int)eve.Attraction.Rating
                }
            };

        }





    }
}
