using MassageStudio.App.Models;
using MassageStudio.App.Services.Interaces;
using MassageStudio.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace MassageStudio.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDbService dbService;
        private readonly UserManager<User> userManager;

        public UserController(IDbService dbService, UserManager<User> userManager)
        {
            this.dbService = dbService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var terms = dbService.GetAllFreeTerms();
            return View(terms);
        }
        public IActionResult MyTerms()
        {
            var massages = dbService.GetReservedByUserId(userManager.GetUserId(User));
            return View(massages);
        }
        public IActionResult Details(int id)
        {
            var term = dbService.GetTermById(id);
            var massage = new Massage { Date = term.Date,termId = term.Id};
            return View(massage);
        }
        [HttpPost]
        public IActionResult Details(Massage massage)
        {
            
            dbService.ChangeTermStatus(massage.termId);
            massage.UserId = userManager.GetUserId(User);
            dbService.ReserveTerm(massage);
            return RedirectToAction("MyTerms");
        }
    }
}
