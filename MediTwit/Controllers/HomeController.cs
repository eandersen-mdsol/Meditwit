using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MediTwit.Models;
using MediTwit.Services;
using MediTwit.ViewModel;

namespace MediTwit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITwitService twitService;

        public HomeController(ITwitService twitService)
        {
            this.twitService = twitService;
        }

        public HomeController()
        {
            var context = new ApplicationDbContext();
            this.twitService = new TwitService(context, new IdentityService(), new HubNotificationService());
        }

        public async Task<ActionResult> Index()
        {
            return View(new HomeIndexViewModel() { Twits = await this.twitService.GetAllTwitsOrderedByDate()});
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(HomeIndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await twitService.CreateTwitForCurrentUser(viewModel.TwitContent);
                return RedirectToAction("Index");
            }

            viewModel.Twits = await twitService.GetAllTwitsOrderedByDate();

            return View(viewModel);
        }

        public async Task<PartialViewResult> TwitPartial(Guid id)
        {
            return PartialView("_Twit", await twitService.GetSingleTwit(id));
        }



    }
}