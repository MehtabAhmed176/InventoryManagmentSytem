using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
        public virtual Item ItemName { get; set; }
    }
}
