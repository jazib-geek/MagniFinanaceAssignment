using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;

namespace Data.BLL
{
   public class StudentSubject
    {
        public static List<v_StudentSubject> GetSubjectsByCourse()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return db.v_StudentSubject.ToList();
            }
        }
        public static void AddSubjectToCourse(int? StudentID, int? SubjectID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                // check if student already exist for this subject
                var chk = db.tblStudentSubjects.Where(x => x.StudentID == StudentID && x.SubjectID == SubjectID).FirstOrDefault();
                // if does not exist, enter new row otherwise skip
                if (chk == null)
                {
                    db.tblStudentSubjects.Add(new tblStudentSubject()
                    {
                        StudentID = StudentID,
                        SubjectID = SubjectID
                    }
                    );
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteSubjectForStudent(int? ID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var row = db.tblStudentSubjects.Find(ID);
                if (row != null)
                {
                    db.tblStudentSubjects.Remove(row);
                    db.SaveChanges();
                }
            }
        }
    }
}
