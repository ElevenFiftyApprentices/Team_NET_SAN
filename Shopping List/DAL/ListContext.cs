//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using Shopping_List.Models;
//using System.Linq;
//using System.Web;

//namespace Shopping_List.DAL
//{
//    public class ListContext : DbContext
//    {
//        public ListContext() : base("ListContext")
//        {
//        }

//        public DbSet<ShoppingList> Lists { get; set; }
//        public DbSet<ShoppingListItem> Items { get; set; }
//        public DbSet<Note> Notes { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        }
//    }

//}