using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string Photo { get; set; }

        public IList<ItemBranch> AllBranches { get; set; }

        public virtual ICollection<Tag> AllTag { get; set; }

      

        //Searching String for just searching
        //[BindProperty(SupportsGet = true)]
        // public string SearchString { get; set; }

    }
}
