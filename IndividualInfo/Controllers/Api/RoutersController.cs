using IndividualInfo.Models;
using System.Web.Http;

namespace IndividualInfo.Controllers.Api
{
    public class RoutersController : ApiController
    {
        private ApplicationDbContext _context;

        public RoutersController()
        {
            _context = new ApplicationDbContext();
        }

    }
}
