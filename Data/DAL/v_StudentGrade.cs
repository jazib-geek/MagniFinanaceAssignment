//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_StudentGrade
    {
        public int ID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<int> GradeID { get; set; }
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public string Grade { get; set; }
    }
}
