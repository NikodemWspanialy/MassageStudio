using MassageStudio.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MassageStudio.App.Services.Interaces;



namespace MassageStudio.Controllers
{
    [Authorize(Roles = "Masseur")]
    public class MasseurController : Controller
    {
        private readonly IDbService dbService;

        public MasseurController(IDbService dbService)
        {
            this.dbService = dbService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddTerm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTerm(Term term)
        {
            if (ModelState.IsValid)
            {
                return View(term);
            }
            if (0 == dbService.AddFreeTerm(term))
                return View(term);
            return RedirectToAction("AllTerms");
        }
        public IActionResult AllTerms()
        {
            var terms = dbService.GetAllTerms();
            return View(terms);
        }
        public IActionResult OldTerms()
        {
            var terms = dbService.GetAllTermsOld();
            return View(terms);
        }
        [HttpGet]
        public IActionResult MassageDetails(int id)
        {
            var massage = dbService.GetReservedByTermId(id);

            return View(massage);
        }
        [HttpGet]
        public IActionResult TermDetails(int id)
        {

            var term = dbService.GetTermById(id);

            return View(term);
        }
    }
}
