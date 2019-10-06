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

        [HttpGet]
        [Route("api/workplacetypes")]
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

        [HttpGet]
        [Route("api/workplaces")]
        public IHttpActionResult GetWorkPlaces()
        {
            var wp = _context.WorkPlaces.ToList();
            return Ok(wp);
        }
        
        [HttpGet]
        [Route("api/workplacesIdAndName")]
        public IHttpActionResult WorkplacesIdAndName()
        {
            var wp = _context.WorkPlaces.ToList();
            return Ok(wp.Select(x => new WorkPlaceDto2()
            {
                Id = x.Id,
                Name = x.Name
            }));
        }

    }

    public class WorkPlaceDto2
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
