using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IndividualInfo.Dtos;
using IndividualInfo.Models;
using System.Data.Entity;

namespace IndividualInfo.Controllers.Api
{
    public class WorkPlacesController : ApiController
    {
        private ApplicationDbContext _context;

        public WorkPlacesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetWorkPlaces()
        {
            var workplaces = _context.WorkPlaces.Include(wp => wp.WorkPlaceType).ToList();

            return Ok(workplaces.Select(wp => new WorkPlaceDto()
            {
                Id = wp.Id,
                Name = wp.Name,
                WorkPlaceTypeDtoId = wp.WorkPlaceTypeId,
                Tel = wp.Tel,
                Address = wp.Address,
                FieldOfActivity = wp.FieldOfActivity,
                WorkPlaceTypeDto = new WorkPlaceTypeDto()
                {
                    Id = wp.WorkPlaceType.Id,
                    Name = wp.WorkPlaceType.Name
                }
            }));
        }
        
        [HttpGet]
        [Route("api/workplacesIdAndName")]
        public IHttpActionResult WorkplacesIdAndName()
        {
            var wp = _context.WorkPlaces.ToList();
            return Ok(wp.Select(x => new WorkPlaceDto2()
            {
                Id = x.Id,
                Name = x.Name,
                WorkPlaceTypeId = x.WorkPlaceTypeId
            }));
        }

        [HttpGet]
        [Route("api/workplacesOnlyName")]
        public IHttpActionResult WorkplacesOnlyName()
        {
            var workplaceNames = _context.WorkPlaces.ToList().Select(wp => wp.Name);
            return Ok(workplaceNames);
        }

        [HttpPost]
        public IHttpActionResult CreateWorkPlace(WorkPlaceDto workPlaceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workPlace = new WorkPlace()
            {
                Id = workPlaceDto.Id,
                Name = workPlaceDto.Name,
                WorkPlaceTypeId = workPlaceDto.WorkPlaceTypeDtoId,
                Tel = workPlaceDto.Tel,
                Address = workPlaceDto.Address,
                FieldOfActivity = workPlaceDto.FieldOfActivity
            };

            _context.WorkPlaces.Add(workPlace);
            _context.SaveChanges();

            workPlaceDto.Id = workPlace.Id;

            return Created(new Uri(Request.RequestUri + "/" + workPlace.Id), workPlaceDto);
        }
    }
}
