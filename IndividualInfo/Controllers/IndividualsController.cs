using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndividualInfo.Models;
using System.Data.Entity;

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
    }
}