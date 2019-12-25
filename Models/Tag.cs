using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public List<Item> ItemId { get; set; }
    }
}
