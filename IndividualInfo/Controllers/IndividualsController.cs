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
            return View();
        }

        public ActionResult IndexRazorRendered()
        {
            var individuals = _context.Individuals.Include(i => i.Semat).ToList();
            return View(individuals);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var individual = _context.Individuals.SingleOrDefault(i => i.Id == id);
            if (individual == null)
                return HttpNotFound();

            var individualViewModel = new IndividualViewModel
            {
                Id = individual.Id,
                Name = individual.Name,
                Gender = individual.Gender,
                TelDirect = individual.TelDirect,
                TelDakheli = individual.TelDakheli,
                Mobile = individual.Mobile,
                Description = individual.Description,
                SematId = individual.SematId ?? 0,
                Semats = _context.Semats.ToList(),
                SelectListItems = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "", Value = ""},
                    new SelectListItem() {Text = "زن", Value = "true"},
                    new SelectListItem() {Text = "مرد", Value = "false"}
                }
                //, Deleted = individual.Deleted
            };

            return View("IndividualForm", individualViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(IndividualViewModel individualViewModel)
        {
            if (!ModelState.IsValid)
            {
                individualViewModel.Semats = _context.Semats.ToList();
                individualViewModel.SelectListItems = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "", Value = ""},
                    new SelectListItem() {Text = "زن", Value = "true"},
                    new SelectListItem() {Text = "مرد", Value = "false"}
                };
                return View("IndividualForm", individualViewModel);
            }

            if (individualViewModel.Id == 0)
            {
                var individual = new Individual()
                {
                    Id = individualViewModel.Id,
                    Name = individualViewModel.Name,
                    SematId = individualViewModel.SematId,
                    Gender = individualViewModel.Gender,
                    TelDirect = individualViewModel.TelDirect,
                    TelDakheli = individualViewModel.TelDakheli,
                    Mobile = individualViewModel.Mobile,
                    Description = individualViewModel.Description
                };

                _context.Individuals.Add(individual);
            }
            else
            {
                var individualInDb = _context.Individuals.SingleOrDefault(i => i.Id == individualViewModel.Id);
                if (individualInDb == null)
                    return HttpNotFound();

                individualInDb.Name = individualViewModel.Name;
                individualInDb.SematId = individualViewModel.SematId;
                individualInDb.Gender = individualViewModel.Gender;
                individualInDb.TelDirect = individualViewModel.TelDirect;
                individualInDb.TelDakheli = individualViewModel.TelDakheli;
                individualInDb.Mobile = individualViewModel.Mobile;
                individualInDb.Description = individualViewModel.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Individuals");
        }

        public ActionResult New()
        {
            var individualViewModel = new IndividualViewModel
            {
                Semats = _context.Semats.ToList(),
                SelectListItems = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "", Value = ""},
                    new SelectListItem() {Text = "زن", Value = "true"},
                    new SelectListItem() {Text = "مرد", Value = "false"}
                }
            };

            return View("IndividualForm", individualViewModel);
        }
    }
}