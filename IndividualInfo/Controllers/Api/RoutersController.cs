using IndividualInfo.Models;
using System.Web.Http;
using System.Data.Entity;
using System.Linq;
using IndividualInfo.Dtos;

namespace IndividualInfo.Controllers.Api
{
    public class RoutersController : ApiController
    {
        private ApplicationDbContext _context;

        public RoutersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetRouters()
        {
            var routers = _context.Routers
                //.Where(r => r.Deleted != true)
                .Include(r => r.IpAddress)
                .Include(r => r.WorkPlace.WorkPlaceType)
                .ToList();

            return Ok(routers.Select(r => new RouterDto()
            {
                Id = r.Id,
                Name = r.Name,
                Model = r.Model,
                IpAddress = r.IpAddress.Ipv4,
                WorkPlace = r.WorkPlace.WorkPlaceType.Name + " " + r.WorkPlace.Name,
                HostName = r.HostName,
                InfoDate = r.InfoDate,
                Ssh = r.Ssh,
                Ise = r.Ise,
                IosVersion = r.IosVersion,
                TunnelNumber = r.TunnelNumber,
                DefaultRouteNumber = r.DefaultRouteNumber,
                IpRouteNumber = r.IpRouteNumber,
                DownInterfacesNumber = r.DownInterfacesNumber,
                Uptime = r.Uptime,
                DualPower = r.DualPower
            }));
        }
    }
}
