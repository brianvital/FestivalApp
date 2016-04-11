using GroupProjectFestivalApp.Infrastructure;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProjectFestivalApp.Services {
    public class HostService {
        private HostRepository _hostRepo;

        public HostService(HostRepository hostRepo) {
            _hostRepo = hostRepo;
        }

        public IList<HostDTO> GetHosts() {
            return (from f in _hostRepo.List()
                    select new HostDTO() {

                        Id = f.Id,
                        Url = f.Url,
                        Name = f.Name,
                        Pushpins = f.Pushpins,
                        Events = f.Events,
                        Attractions = f.Attractions,
                        User = new ApplicationUserDTO() {
                            UserName = f.User.UserName
                        }
                    }).ToList();
        }

        public MapDTO GetMap(int hostId) {
            return (from h in _hostRepo.Get(hostId)
                    select new MapDTO() {
                        ImageUrl = "/Images/Festmap.png",
                        Pins = (from p in h.Pushpins
                                select new PushpinDTO() {
                                    Name = p.Name,
                                    Left = p.Left,
                                    Top = p.Top,
                                    Category = p.Category
                                }).ToList()
                    }).FirstOrDefault();
        }
    }
}