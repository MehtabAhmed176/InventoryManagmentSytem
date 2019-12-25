using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Models
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemBranch>().HasKey(sc => new { sc.ItemId, sc.BranchId });

            //1 to Many from Item to Branches with Forigen Key
            modelBuilder.Entity<ItemBranch>().HasOne(x => x.Items).WithMany(c => c.AllBranches).HasForeignKey(p => p.ItemId);
            //1 to Many from Branches to Items with Foreign Key                                                                                                             
            modelBuilder.Entity<ItemBranch>().HasOne(x => x.Branches).WithMany(c => c.AllItems).HasForeignKey(p => p.BranchId);

            //Primary Key for Identity Table
            // modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(sc => new { sc.UserId});
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ItemBranch> ItemesBranches { get; set; }

    }
}
