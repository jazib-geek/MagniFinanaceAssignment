using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.BLL;

namespace Test.Controllers
{
    public class StudentGradeController : Controller
    {
        // GET: StudentGrade
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Index(int? StudentID)
        {
            var lst = StudentGrade.GetStudentGradeList();
            if (StudentID != null)
            {
                lst = StudentGrade.GetStudentGradeList(StudentID);
            }
            return PartialView(lst);
        }
        [HttpPost]
        public JsonResult AddGrade(int? StudentID, int? SubjectID, int? GradeID)
        {
            StudentGrade.AddStudentGrade(StudentID, SubjectID, GradeID);

            return Json(new { msg = "success"});
        }
        [HttpPost]
        public JsonResult DeleteGrade(int? ID)
        {
            StudentGrade.DeleteGradeForThiStudent(ID);

            return Json(new { msg = "success" });
        }
    }
}