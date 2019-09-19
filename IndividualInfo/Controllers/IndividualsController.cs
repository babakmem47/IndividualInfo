using IndividualInfo.Models;
using IndividualInfo.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
                SelectListItems = new List<SelectListItem>(),
                TelDirect = individual.TelDirect,
                TelDakheli = individual.TelDakheli,
                Mobile = individual.Mobile,
                Description = individual.Description,
                SematId = individual.SematId ?? 0,
                Semats = _context.Semats.ToList()
                //, Deleted = individual.Deleted

            };

            individualViewModel.SelectListItems.Add(new SelectListItem() { Text = "", Value = "" });
            individualViewModel.SelectListItems.Add(new SelectListItem() { Text = "زن", Value = "true" });
            individualViewModel.SelectListItems.Add(new SelectListItem() { Text = "مرد", Value = "false" });
            
            return View("IndividualForm", individualViewModel);
        }
    }
}