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
    
    public partial class tblSubject
    {
        public int Id { get; set; }
        public string SubjectFullName { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> TeacherID { get; set; }
    }
}
