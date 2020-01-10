using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite primary key in the ItemBranch -Many To Many Relation Between Item and Branch
            modelBuilder.Entity<ItemBranch>().HasKey(sc => new { sc.ItemId, sc.BranchId });

            //1 to Many from Item to Branches with Forigen Key
            modelBuilder.Entity<ItemBranch>().HasOne(x => x.Items).WithMany(c => c.AllBranches).HasForeignKey(p => p.ItemId);
            //1 to Many from Branches to Items with Foreign Key                                                                                                             
            modelBuilder.Entity<ItemBranch>().HasOne(x => x.Branches).WithMany(c => c.AllItems).HasForeignKey(p => p.BranchId);

            //Primary Key for Identity Table
            // modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(sc => new { sc.UserId});
            base.OnModelCreating(modelBuilder);

            // Configuring one-to-many relationship between Branch And Application Users
          

          /*  modelBuilder.Entity<ApplicationUser>()
            .HasOne<Branch>(s => s.OneBranch)
            .WithMany(g => g.ManyUsers)
            .HasForeignKey(s => s.CurrentBranch);
*/
        }

        //  public DbSet<User> CustomUsers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ItemBranch> ItemesBranches { get; set; }
        // public DbSet<InventoryManagement.Models.ApplicationRoles> ApplicationRoles { get; set; }

       
    


    }
}
