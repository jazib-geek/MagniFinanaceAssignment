using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
   public class GradeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string GradeTitle { get; set; }
    }
}
