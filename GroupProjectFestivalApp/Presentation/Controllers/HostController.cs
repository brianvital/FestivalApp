using GroupProjectFestivalApp.Services;
using GroupProjectFestivalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroupProjectFestivalApp.Presentation.Controllers {
    public class HostController : ApiController {


        private HostService _hostService;

        public HostController(HostService hostService) {
            _hostService = hostService;
        }

        [HttpGet]
        [Route("api/hosts")]
        public IList<HostDTO> Get() {
            return _hostService.GetHosts();
        }

        [HttpGet]
        [Route("api/pins/{id}")]
        public MapDTO GetPins(int id) {
            return _hostService.GetMap(id);
        }
    }
}
