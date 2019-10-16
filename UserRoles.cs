using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGear.Data
{
    public class UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Role ID")]
        public int URID { get; set; }

        [Display(Name = "Role ID")]
        public int RID { get; set; }
        [ForeignKey("RID")]
        public Roles RoleID { get; set; }
    }
}
