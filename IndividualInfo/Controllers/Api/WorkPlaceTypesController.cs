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
    public class WorkPlaceTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public WorkPlaceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetWorkPlaceTypes()
        {
            var workPlaceTypes = _context.WorkPlaceTypes.ToList();

            var workPlaceTypeDto = workPlaceTypes.Select(wpt => new WorkPlaceTypeDto
            {
                Id = wpt.Id,
                Name = wpt.Name
            });

            return Ok(workPlaceTypeDto);
        }
    }
}
