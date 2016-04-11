using GroupProjectFestivalApp.Infrastructure;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectFestivalApp.Services {
    public class CommentService {
        private CommentRepository _commentRepo;
        private EventRepository _eventRepo;
        private AttractionRepository _attractionRepo;

        public CommentService(CommentRepository commentRepo, EventRepository eventRepo, AttractionRepository attractionRepo) {
            _commentRepo = commentRepo;
            _eventRepo = eventRepo;
            _attractionRepo = attractionRepo;

        }
        public IList<CommentDTO> GetComments() {

            return (from c in _commentRepo.List()                   
                    select new CommentDTO() {
                        Id = c.Id,
                        Message = c.Message,
                        AttractionName = c.Event.Attraction.Name,
                        Rating = (int)c.Event.Rating,
                        User = new ApplicationUserDTO() {
                            UserName = c.User.UserName
                        }
                    }).ToList();
        }
    }
}
