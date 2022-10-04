using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class SubjectByCourseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Index(int? CourseID)
        {
            var lst = Data.BLL.CourseSubject.GetSubjectsByCourse(CourseID);
            ViewBag.CourseID = CourseID;

            return PartialView(lst);
        }
        [HttpPost]
        public JsonResult AddSubject(int? CourseID, int? SubjectID)
        {
            var chk = Data.BLL.CourseSubject.GetSubjectsByCourse(CourseID).Where(x => x.SubjectID == SubjectID).FirstOrDefault();
            if (chk != null)
            {
                return Json(new { msg = "error" , desc = "Subject already exist for this course" , SubjectID = SubjectID });
            }

            Data.BLL.CourseSubject.AddSubjectToCourse(CourseID, SubjectID);

            return Json(new { msg = "success" });
        }
        [HttpPost]
        public JsonResult DeleteSubject(int? ID)
        {
            Data.BLL.CourseSubject.DeleteSubjectFromCourse(ID);

            return Json(new { msg = "success" });
        }
    }
}