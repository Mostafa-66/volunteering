using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Volunteering.Data;
using Volunteering.Models;
using Volunteering.Repository.Base;

namespace Volunteering.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(IRepository<Opportunity> OppRepo, IRepository<Sector> SectorRepo)
        {
            _OppRepo = OppRepo;
            _SectorRepo = SectorRepo;
        }

        protected IRepository<Opportunity> _OppRepo;
        protected IRepository<Sector> _SectorRepo;
        public IActionResult Index()
        {
            return View(_OppRepo.FindAllOpp());
        }

        public void createSectorList(int selectId = 0)
        {
            List<Sector> sectors = (List<Sector>)_SectorRepo.FindAll();
            SelectList listSectors = new SelectList(sectors, "Sec_ID", "Sec_Name", selectId);
            ViewBag.SectorList = listSectors;
        }

        public IActionResult New()
        {
            createSectorList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Opportunity opportunity)
        {
            if (opportunity.Opp_Name == "" || opportunity.Opp_Name == null)
            {
                ModelState.AddModelError("Opp_Name", "لا يمكن ان يكون هذا الحقل فارغ");
            }
            if(opportunity.Opp_Description == "" || opportunity.Opp_Description == null)
            {
                ModelState.AddModelError("Opp_Description", "لا يمكن ان يكون هذا الحقل فارغ");
            }
            if (opportunity.Opp_Brief == "" || opportunity.Opp_Brief == null)
            {
                ModelState.AddModelError("Opp_Brief", "لا يمكن ان يكون هذا الحقل فارغ");
            }
            if(opportunity.Opp_Start > opportunity.Opp_End ||
                opportunity.Opp_Start < opportunity.Opp_RegisterStart ||
                opportunity.Opp_Start < opportunity.Opp_RegisterEnd)
            {
                ModelState.AddModelError("Opp_Start", "برجاء ادخال تاريخ مناسب");
            }
            if (opportunity.Opp_End < opportunity.Opp_RegisterStart ||
                opportunity.Opp_End < opportunity.Opp_RegisterEnd)
            {
                ModelState.AddModelError("Opp_End", "برجاء ادخال تاريخ مناسب");
            }
            if (opportunity.Opp_RegisterStart > opportunity.Opp_RegisterEnd)
            {
                ModelState.AddModelError("Opp_RegisterStart", "برجاء ادخال تاريخ مناسب");
            }
            if (ModelState.IsValid)
            {
                _OppRepo.AddOne(opportunity);
                return RedirectToAction("Index");

            }
            else
            {
                createSectorList();
                return View(opportunity);
            }
        }

        public IActionResult Edit(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var opportunity = _OppRepo.FindById(Id);
            createSectorList(opportunity.Sector_ID);
            return View(opportunity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Opportunity opportunity, int Id)
        {
            if (opportunity.Opp_Name == "" || opportunity.Opp_Name == null)
            {
                ModelState.AddModelError("Name", "لا يمكن ان يكون هذا الحقل فارغ");
            }
            if (ModelState.IsValid)
            {
                if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    _OppRepo.EditOne(opportunity);
                    return RedirectToAction("Index");
                }

            }
            else
            {
                createSectorList(opportunity.Sector_ID);
                return View(opportunity);
            }
        }

        public IActionResult Delete(int Id)
        {
            if (Id != null)
            {
                var oppotunity = _OppRepo.FindById(Id);
                createSectorList(oppotunity.Sector_ID);
                return View(oppotunity);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int Id)
        {
            var oppotunity = _OppRepo.FindById(Id);
            if (oppotunity == null)
            {
                return NotFound();
            }
            _OppRepo.DeleteOne(oppotunity);
            return RedirectToAction("Index");
        }

    }
}
