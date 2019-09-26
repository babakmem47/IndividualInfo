using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IndividualInfo.Dtos;
using IndividualInfo.Models;

namespace IndividualInfo.Controllers.Api
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

        public IHttpActionResult GetSemats()
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
