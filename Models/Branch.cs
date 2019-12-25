using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        // public int? UserId { get; set; }
        // public IList<User> UsersinBranch { get; set; }
        public IList<User> Allusers { get; set; }
        public IList<ItemBranch> AllItems { get; set; }
    }
}
