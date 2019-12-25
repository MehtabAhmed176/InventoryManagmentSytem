using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // [Compare("Password",ErrorMessage ="Password dont match")]
        // [DataType(DataType.Password)]
        // [Required(ErrorMessage = "Password is Required")]
        //  public string ConfirmPassword { get; set; }

        public string Role { get; set; }
        [ForeignKey("BranchId")]
        public int? BranchId { get; set; }
        public Branch UsersBranches { get; set; }
    }
}
