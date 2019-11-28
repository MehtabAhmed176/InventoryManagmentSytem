using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.ViewModel
{
    public class RegistorViewModel
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]

        public string Confirmedpassword { get; set; }
    }
}
