using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;
using Data.ViewModels;

namespace Data.BLL
{
    public class Student
    {
        public static List<StudentViewModel> GetStudentList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var lstData = db.tblStudents.ToList();
                var lst = new List<StudentViewModel>();

                foreach (var item in lstData)
                {
                    lst.Add(new StudentViewModel()
                    {
                        Id = item.Id,
                        RegNo = item.RegNo,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DateOfBirth = item.DateOfBirth,
                        IsActive = item.IsActive
                    });
                }

                return lst;
            }
        }

        public static StudentViewModel GetByID(int? Id)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return GetStudentList().Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static bool AddStudent(StudentViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    db.tblStudents.Add(new tblStudent()
                    {
                        RegNo = model.RegNo,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
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
        public static bool UpdateStudent(StudentViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblStudents.Find(model.Id);

                    if (row != null)
                    {
                        row.RegNo = model.RegNo;
                        row.FirstName = model.FirstName;
                        row.LastName = model.LastName;
                        row.DateOfBirth = model.DateOfBirth;
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
        public static bool DeleteStudent(int Id)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblStudents.Find(Id);

                    if (row != null)
                    {
                        db.tblStudents.Remove(row);
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
