using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGear.Data
{
    public class Depts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department ID")]
        public int DeptID { get; set; }

        [Display(Name = "Department Name")]
        public string Dname { get; set; }

        [Display(Name = "Department Owner")]
        public string Downer { get; set; }

        public string Location { get; set; }
    }
}
