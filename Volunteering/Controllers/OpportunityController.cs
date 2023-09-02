using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volunteering.Data;
using Volunteering.Models;
using Volunteering.Repository.Base;

namespace Volunteering.Controllers
{
    public class OpportunityController : Controller
    {
        public OpportunityController(IRepository<Opportunity> repositry)
        {
            _repositry = repositry;
        }

        private IRepository<Opportunity> _repositry;

        public IActionResult Index()
        {
            return View(_repositry.FindAllOpp());
        }

        public IActionResult Details(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var opportunity = _repositry.FindById(Id);
            ViewBag.opp = opportunity;
            return View(opportunity);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)}
                );
            return LocalRedirect(returnUrl);
        }
    }
}
