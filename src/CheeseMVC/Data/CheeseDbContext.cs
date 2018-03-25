﻿using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<CheeseMenu> CheeseMenus { get; set; }

      public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options)
        { }


        /*
         This method will set the primary key of the CheeseMenu class and table to be a composite key, consisting of both CheeseID and MenuID.
         (Many-to-Many relationship between cheesees and menus)
             
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
            
        }

       
    }
}
