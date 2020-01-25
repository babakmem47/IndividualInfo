using IndividualInfo.Dtos;
using IndividualInfo.Models;
using System.Linq;
using System.Web.Http;

namespace IndividualInfo.Controllers
{
    public class SematsController : ApiController
    {
        private ApplicationDbContext _context;

        public SematsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        // /api/semats/getallsemats
        public IHttpActionResult GetAllSemats()
        {
            var semats = _context.Semats.ToList();

            var sematDto = semats.Select(s => new SematDto()
            {
                Id = s.Id,
                Name = s.Name
            });

            return Ok(sematDto);
        }
    }
}
