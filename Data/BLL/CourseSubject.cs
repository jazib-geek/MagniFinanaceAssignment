using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;

namespace Data.BLL
{
    public class CourseSubject
    {
        public static List<v_CourseSubject> GetSubjectsByCourse()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return db.v_CourseSubject.ToList();
            }
        }
        public static List<v_CourseSubject> GetSubjectsByCourse(int? CourseID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return db.v_CourseSubject.Where(x => x.CourseID == CourseID).ToList();
            }
        }
        public static void AddSubjectToCourse(int? CourseID, int? SubjectID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                // check if subject already exist for this course
                var chk = db.tblCourseSubjects.Where(x => x.CourseID == CourseID && x.SubjectID == SubjectID).FirstOrDefault();
                // if does not exist, enter new row otherwise skip
                if (chk == null)
                {
                    db.tblCourseSubjects.Add(new tblCourseSubject()
                    {
                        CourseID = CourseID,
                        SubjectID = SubjectID
                    }
                    );
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteSubjectFromCourse(int? ID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var row = db.tblCourseSubjects.Find(ID);
                if (row != null)
                {
                    db.tblCourseSubjects.Remove(row);
                    db.SaveChanges();
                }
            }
        }
    }
}
