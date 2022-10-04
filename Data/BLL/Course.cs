using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;
using Data.ViewModels;

namespace Data.BLL
{
    public class Course
    {
        public static List<CourseViewModel> GetCourseList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var lstData = db.tblCourses.ToList();
                var lst = new List<CourseViewModel>();

                foreach (var item in lstData)
                {
                    lst.Add(new CourseViewModel()
                    {
                        Id = item.Id,
                        CourseName = item.CourseName,
                        TotalCreditHours = item.TotalCreditHours,
                        IsActive = item.IsActive
                    });
                }

                return lst;
            }
        }

        public static CourseViewModel GetByID(int? Id)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return GetCourseList().Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static bool AddCourse(CourseViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    db.tblCourses.Add(new tblCourse()
                    {
                        CourseName = model.CourseName,
                        TotalCreditHours = model.TotalCreditHours,
                        IsActive = true
                    });
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool UpdateCourse(CourseViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblCourses.Find(model.Id);

                    if (row != null)
                    {
                        row.CourseName = model.CourseName;
                        row.TotalCreditHours = model.TotalCreditHours;
                        row.IsActive = model.IsActive;
                        db.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteCourse(int Id)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblCourses.Find(Id);

                    if (row != null)
                    {
                        db.tblCourses.Remove(row);
                        db.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
