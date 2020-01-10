using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class ApplicationUser: IdentityUser
    {
       
        public string Name { get; set; }

        [ForeignKey("BranchId")]
        public int UserBranchId { get; set; }
        public virtual Branch UserBranchName { get; set; }
    }
}
