using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;
using Data.ViewModels;

namespace Data.BLL
{
    public class Teacher
    {
        public static List<TeacherViewModel> GetTeacherList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var lstData = db.tblTeachers.ToList();
                var lst = new List<TeacherViewModel>();

                foreach (var item in lstData)
                {
                    lst.Add(new TeacherViewModel()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DateOfBirth = item.DateOfBirth,
                        Salary = item.Salary,
                        IsActive = item.IsActive
                    });
                }

                return lst;
            }
        }

        public static TeacherViewModel GetByID(int? Id)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return GetTeacherList().Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static bool AddTeacher(TeacherViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    db.tblTeachers.Add(new tblTeacher()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Salary = model.Salary,
                        DateOfBirth = model.DateOfBirth,
                        IsActive = true,
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
        public static bool UpdateTeacher(TeacherViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblTeachers.Find(model.Id);

                    if (row != null)
                    {
                        row.FirstName = model.FirstName;
                        row.LastName = model.LastName;
                        row.DateOfBirth = model.DateOfBirth;
                        row.Salary = model.Salary;
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
        public static bool DeleteTeacher(int Id)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblTeachers.Find(Id);

                    if (row != null)
                    {
                        db.tblTeachers.Remove(row);
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
