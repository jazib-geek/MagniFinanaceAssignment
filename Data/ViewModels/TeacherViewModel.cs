using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Data.ViewModels
{
   public class TeacherViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "*Required")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [Required(ErrorMessage = "*Required")]
        public Nullable<decimal> Salary { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
