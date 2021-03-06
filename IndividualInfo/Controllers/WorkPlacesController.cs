﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using IndividualInfo.Dtos;
using IndividualInfo.Models;

namespace IndividualInfo.Controllers
{
    public class WorkPlacesController : ApiController
    {
        private ApplicationDbContext _context;

        public WorkPlacesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAllWorkPlaces()
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
                FieldOfActivity = workPlaceDto.FieldOfActivity,
                Created = DateTime.Now
            };

            _context.WorkPlaces.Add(workPlace);
            _context.SaveChanges();

            workPlaceDto.Id = workPlace.Id;

            return Created(new Uri(Request.RequestUri + "/" + workPlace.Id), workPlaceDto);
        }
    }
}
