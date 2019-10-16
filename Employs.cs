using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGear.Data
{
    public class Employs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EID { get; set; }

        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Date Created")]
        public DateTime Dsubmitted { get; set; }

        [Display(Name = "Approved Positions")]
        public int Aprroved { get; set; }

        [Display(Name = "User Role ID")]
        public int URID { get; set; }
        [ForeignKey("URID")]
        public UserRoles UserRolesId { get; set; }

        [Display(Name = "Department ID")]
        public int DID { get; set; }
        [ForeignKey("DID")]
        public Depts Departments { get; set; }
    }
}
