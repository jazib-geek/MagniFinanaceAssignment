using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;
using Data.ViewModels;

namespace Data.BLL
{
    public class Subject
    {
        public static List<SubjectViewModel> GetSubjectList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var lstData = db.v_Subject.ToList();
                var lst = new List<SubjectViewModel>();

                foreach (var item in lstData)
                {
                    lst.Add(new SubjectViewModel()
                    {
                        Id = item.Id,
                        SubjectFullName = item.SubjectFullName,
                        ShortName = item.ShortName,
                        TeacherID = item.TeacherID,
                        TeacherName = item.TeacherName,
                        IsActive = item.IsActive
                    });
                }

                return lst;
            }
        }

        public static SubjectViewModel GetByID(int? Id)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return GetSubjectList().Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static bool AddSubject(SubjectViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    db.tblSubjects.Add(new tblSubject()
                    {
                        SubjectFullName = model.SubjectFullName,
                        TeacherID = model.TeacherID,
                        ShortName = model.ShortName,
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
        public static bool UpdateSubject(SubjectViewModel model)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblSubjects.Find(model.Id);

                    if (row != null)
                    {
                        row.SubjectFullName = model.SubjectFullName;
                        row.ShortName = model.ShortName;
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
        public static bool DeleteSubject(int Id)
        {
            try
            {
                using (dbCollegeEntities db = new dbCollegeEntities())
                {
                    var row = db.tblSubjects.Find(Id);

                    if (row != null)
                    {
                        db.tblSubjects.Remove(row);
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
