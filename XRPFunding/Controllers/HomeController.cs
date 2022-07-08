using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XRPFunding.Data;
using XRPFunding.Models;
using Microsoft.EntityFrameworkCore;

namespace XRPFunding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListCauses()
        {
            ListCausesViewModel model = new ListCausesViewModel(_db);
            return View(model);
        }

        public ActionResult ViewCause(int id) //acá se debería donar
        {
            ViewCauseViewModel model = new ViewCauseViewModel(_db, id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Donate(DonateFormModel Form)
        {
            Donation donation = new Donation
            {
                 Amount = Form.Amount, CauseId = Form.Id, CreatedAt = DateTime.UtcNow,
                  UserId = Form.XRPLAddress, XRPLAddress = Form.XRPLAddress
            };
            _db.Donations.Add(donation);
            _db.SaveChanges();
            return RedirectToAction("ViewCause", new { id = Form.Id });
        }

        [Authorize]
        public ActionResult CreateCause()
        {
            CreateCauseViewModel model = new CreateCauseViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateCause(CreateCauseFormModel Form)
        {
            if (!ModelState.IsValid)
            {
                CreateCauseViewModel model = new CreateCauseViewModel();
                model.Form = Form;
                return View(model);
            }
            Cause cause = new Cause
            {
                FundsNow = 0,
                Website = Form.Website,
                XRPLAddress = Form.XRPLAddress,
                FundGoal = Form.FundGoal,
                CreatedAt = DateTime.UtcNow,
                Name = Form.Name,
                Description = Form.Description,
                Deadline = Form.Deadline.Value,
                UrlPhoto = Form.UrlPhoto, 
                UserId = User.Identity.Name
            };
            _db.Causes.Add(cause);
            _db.SaveChanges();
            return RedirectToAction("ViewCause", new { id = cause.Id });
        }

        public ActionResult CauseCreated(int id)
        {
            return View();
        }

        public ActionResult CreateXRPLAddress()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}