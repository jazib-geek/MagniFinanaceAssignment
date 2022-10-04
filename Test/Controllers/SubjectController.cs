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
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            var lst = Subject.GetSubjectList();

            return View(lst);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Subject.GetByID(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: tblSubjects/Create
        public ActionResult Create()
        {
            ViewBag.TeacherList = Teacher.GetTeacherList();
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel model)
        {
            ViewBag.TeacherList = Teacher.GetTeacherList();
            var chk = Subject.GetSubjectList().Where(x => x.SubjectFullName.ToLower() == model.SubjectFullName.ToLower()).FirstOrDefault();
            if (chk != null)
            {
                TempData["error"] = "Subject already exist";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                Subject.AddSubject(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: tblSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.TeacherList = Teacher.GetTeacherList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Subject.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subject.UpdateSubject(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: tblSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Subject.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: tblSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject.DeleteSubject(id);
            return RedirectToAction("Index");
        }
    }
}
