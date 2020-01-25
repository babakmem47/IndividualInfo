using System;
using System.Linq;
using System.Web.Http;
using IndividualInfo.Dtos;
using IndividualInfo.Models;

namespace IndividualInfo.Controllers
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
        //[Route("api/workplacetypes/getallworkplacetypes")]   // cause problem for httppost request
        public IHttpActionResult GetAllWorkPlaceTypes()
        {
            var workPlaceTypes = _context.WorkPlaceTypes.ToList();

            var workPlaceTypeDto = workPlaceTypes.Select(wpt => new WorkPlaceTypeDto
            {
                Id = wpt.Id,
                Name = wpt.Name
            });

            return Ok(workPlaceTypeDto);
        }

        [HttpPost]
        public IHttpActionResult CreateWorkPlaceType(WorkPlaceTypeDto workPlaceTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newWorkPlaceType = new WorkPlaceType()
            {
                Id = (byte)workPlaceTypeDto.Id,
                Name = workPlaceTypeDto.Name
            };

            _context.WorkPlaceTypes.Add(newWorkPlaceType);
            _context.SaveChanges();

            workPlaceTypeDto.Id = newWorkPlaceType.Id;
            return Created(new Uri(Request.RequestUri + "/" + newWorkPlaceType.Id), workPlaceTypeDto);
        }

        //[HttpGet]
        //[Route("api/workplaces")]
        //public IHttpActionResult GetAllWorkPlaces()
        //{
        //    var wp = _context.WorkPlaces.ToList();
        //    return Ok(wp);
        //}



    }
}
