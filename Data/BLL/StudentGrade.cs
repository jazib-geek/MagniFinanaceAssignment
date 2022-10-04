using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;

namespace Data.BLL
{
    public class StudentGrade
    {
        public static List<v_StudentGrade> GetStudentGradeList()
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return db.v_StudentGrade.ToList();
            }
        }

        public static List<v_StudentGrade> GetStudentGradeList(int? StudentID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                return db.v_StudentGrade.Where(x => x.StudentID == StudentID).ToList();
            }
        }
        public static void AddStudentGrade(int? StudentID, int? SubjectID, int? GradeID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var row = db.tblStudentGrades.Where(x => x.StudentID == StudentID && x.SubjectID == SubjectID).FirstOrDefault();
                // If Grade already exist then Update existing Grade otherwise insert new row
                if (row == null)
                {
                    db.tblStudentGrades.Add(new tblStudentGrade()
                    {
                        StudentID = StudentID,
                        SubjectID = SubjectID,
                        GradeID = GradeID,
                    });
                    db.SaveChanges();
                }
                else
                {
                    row.GradeID = GradeID;
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteGradeForThiStudent(int? ID)
        {
            using (dbCollegeEntities db = new dbCollegeEntities())
            {
                var row = db.tblStudentGrades.Find(ID);
                if (row != null)
                {
                    db.tblStudentGrades.Remove(row);
                    db.SaveChanges();
                }
            }
        }
    }
}
