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
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            var lst = Course.GetCourseList();

            return View(lst);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Course.GetByID(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: tblCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course.AddCourse(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: tblCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Course.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course.UpdateCourse(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: tblCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Course.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: tblCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
