using System;
using IndividualInfo.Dtos;
using IndividualInfo.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace IndividualInfo.Controllers.Api
{
    public class IndividualsController : ApiController
    {
        private ApplicationDbContext _context;

        public IndividualsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get   /api/individuals/
        public IHttpActionResult GetIndividuals()
        {
            var individuals = _context.Individuals
                .Where(i => i.Deleted != true)
                .Include(i => i.Semat)
                .ToList();

            var resultDto = individuals.Select(x => new IndividualDto()
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                TelDirect = x.TelDirect,
                TelDakheli = x.TelDakheli,
                Mobile = x.Mobile,
                Description = x.Description,
                SematDto = new SematDto
                {
                    Id = x.SematId ?? 0,
                    Name = (x.SematId != null) ? x.Semat.Name : String.Empty
                },
                Deleted = x.Deleted
            });

            return Ok(resultDto);
        }


        // Logical Delete  /api/individuals/id
        [HttpDelete]
        public IHttpActionResult DeleteIndividuals(int id)
        {
            var individual = _context.Individuals.SingleOrDefault(i => i.Id == id);

            if (individual == null)
                return NotFound();

            individual.Deleted = true;
            _context.SaveChanges();

            return Ok("Individual: " + individual.Name + " deleted logically");
        }

    }
}
