using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGear.Data
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User ID")]
        public int UID { get; set; }

        public string Uname { get; set; }

        [Display(Name ="User Role ID")]
        public int URID { get; set; }
        [ForeignKey("URID")]
        public UserRoles UsersRolesID { get; set; }
    }
}
