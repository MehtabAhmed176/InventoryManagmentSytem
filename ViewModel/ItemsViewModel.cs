using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.ViewModel
{
    public class ItemsViewModel
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public IFormFile Photo { get; set; }

        public IList<ItemBranch> AllBranches { get; set; }
    }
}
