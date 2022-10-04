using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;
using Data.ViewModels;

namespace Data.BLL
{
    public class Grade
    {
        public static List<GradeViewModel> GetGradeList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var lstData = db.tblGrades.ToList();
                var lst = new List<GradeViewModel>();

                foreach (var item in lstData)
                {
                    lst.Add(new GradeViewModel()
                    {
                        Id = item.Id,
                        GradeTitle = item.GradeTitle,
                    });
                }

                return lst;
            }
        }

        public static GradeViewModel GetByID(int? Id)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return GetGradeList().Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static bool AddGrade(GradeViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    db.tblGrades.Add(new tblGrade()
                    {
                        GradeTitle = model.GradeTitle,
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
        public static bool UpdateGrade(GradeViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblGrades.Find(model.Id);

                    if (row != null)
                    {
                        row.GradeTitle = model.GradeTitle;
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
        public static bool DeleteGrade(int Id)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblGrades.Find(Id);

                    if (row != null)
                    {
                        db.tblGrades.Remove(row);
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
