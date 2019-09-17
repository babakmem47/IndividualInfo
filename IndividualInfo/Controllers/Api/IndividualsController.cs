using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IndividualInfo.Models;
using System.Data.Entity;
using IndividualInfo.Dtos;

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
                SematDto = new SematDto()
                {
                    Id = x.Semat.Id,
                    Name = x.Semat.Name
                }
            });

            return Ok(resultDto);
        }
    }
}
