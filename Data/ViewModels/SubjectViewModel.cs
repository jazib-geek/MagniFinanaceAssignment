﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int? TeacherID { get; set; }

        public string TeacherName { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string SubjectFullName { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
