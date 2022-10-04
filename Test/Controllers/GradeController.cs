using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.BLL;
using Data.ViewModels;

namespace Test.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            var lst = Grade.GetGradeList();

            return View(lst);
        }

        // GET: Grades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Grade.GetByID(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: tblGrades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeViewModel model)
        {
            var chk = Grade.GetGradeList().Where(x => x.GradeTitle.ToLower() == model.GradeTitle.ToLower()).FirstOrDefault();
            if (chk != null)
            {
                TempData["error"] = "Grade already exist";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                Grade.AddGrade(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: tblGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Grade.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Grades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Grade.UpdateGrade(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: tblGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Grade.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: tblGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade.DeleteGrade(id);
            return RedirectToAction("Index");
        }
    }
}
