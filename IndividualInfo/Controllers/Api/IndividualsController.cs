﻿using IndividualInfo.Dtos;
using IndividualInfo.Models;
using System;
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
                .Include(i => i.WorkPlace.WorkPlaceType)
                .ToList();

            var resultDto = individuals.Select(x => new IndividualDto()
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                TelDirect = x.TelDirect,
                TelDakheli = x.TelDakheli,
                Mobile = x.Mobile,
                Email = x.Email,
                Description = x.Description,
                SematDto = new SematDto
                {
                    Id = x.SematId ?? 0,
                    Name = (x.SematId != null) ? x.Semat.Name : String.Empty
                },
                Deleted = x.Deleted,
                WorkPlaceDto = new WorkPlaceDto
                {
                    Id = x.WorkPlaceId ?? 0,
                    Name = (x.WorkPlaceId != null) ? x.WorkPlace.Name : String.Empty,
                    WorkPlaceTypeDto = new WorkPlaceTypeDto
                    {
                        Id = (x.WorkPlaceId != null) ? x.WorkPlace.WorkPlaceTypeId : 0,
                        Name = (x.WorkPlaceId != null) ? x.WorkPlace.WorkPlaceType.Name : String.Empty
                    }
                }
            });

            return Ok(resultDto);
            //return Ok(individuals);
        }

        // Get /api/individuals/id
        public IHttpActionResult GetIndividual(int id)
        {
            var individual = _context.Individuals
                .Include(i => i.Semat)
                .Include(i => i.WorkPlace.WorkPlaceType)
                .SingleOrDefault(i => i.Id == id);

            if (individual == null || individual.Deleted == true)
                return NotFound();

            var individualDto = new IndividualDto()
            {
                Id = individual.Id,
                Name = individual.Name,
                Gender = individual.Gender,
                TelDirect = individual.TelDirect,
                TelDakheli = individual.TelDakheli,
                Mobile = individual.Mobile,
                Email = individual.Email,
                Description = individual.Description,
                SematDto = new SematDto()
                {
                    Id = individual.SematId ?? 0,
                    Name = (individual.SematId != null) ? individual.Semat.Name : String.Empty
                },
                WorkPlaceDto = new WorkPlaceDto
                {
                    Id = individual.WorkPlaceId ?? 0,
                    Name = (individual.WorkPlaceId != null) ? individual.WorkPlace.Name : String.Empty,
                    WorkPlaceTypeDto = new WorkPlaceTypeDto
                    {
                        Id = (individual.WorkPlaceId != null) ? individual.WorkPlace.WorkPlaceTypeId : 0,
                        Name = (individual.WorkPlaceId != null) ? individual.WorkPlace.WorkPlaceType.Name : String.Empty
                    }
                }
            };

            return Ok(individualDto);
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

        [HttpPost]
        public IHttpActionResult CreateIndividual(IndividualDto individualDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var individual = new Individual()
            {
                Id = individualDto.Id,
                Gender = individualDto.Gender,
                TelDirect = individualDto.TelDirect,
                TelDakheli = individualDto.TelDakheli,
                Mobile = individualDto.Mobile,
                Description = individualDto.Description,
                SematId = individualDto.SematDto.Id,
                Name = individualDto.Name,
                Email = individualDto.Email,
                WorkPlaceId = individualDto.WorkPlaceDto.Id
            };

            return Created()
        }

    }
}
