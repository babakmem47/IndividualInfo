using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndividualInfo.Models;
using System.Data.Entity;
using IndividualInfo.ViewModels;

namespace IndividualInfo.Controllers
{
    public class IndividualsController : Controller
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

        // GET: Individuals
        public ActionResult Index()
        {
            var individuals = _context.Individuals.Include(i => i.Semat).ToList();
            return View(individuals);
        }

        public ActionResult Edit(int id)
        {
            var individual = _context.Individuals.SingleOrDefault(i => i.Id == id);
            if (individual == null)
                return HttpNotFound();

            var individualViewModel = new IndividualViewModel()
            {
                Id = individual.Id,
                Name = individual.Name,
                Gender = individual.Gender,
                TelDirect = individual.TelDirect,
                TelDakheli = individual.TelDakheli,
                Mobile = individual.Mobile,
                Description = individual.Description,
                SematId = individual.SematId ?? 0,
                Semats = _context.Semats.ToList()
                //, Deleted = individual.Deleted

            };

            return View("IndividualForm", individualViewModel);
        }
    }
}