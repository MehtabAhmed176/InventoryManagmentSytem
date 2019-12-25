using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Models
{
    public class ItemBranch
    {
        public int ItemId { get; set; }


        public int BranchId { get; set; }

        public virtual Branch Branches { get; set; }

        public virtual Item Items { get; set; }
    }
}
