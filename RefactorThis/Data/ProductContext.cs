using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using refactor_me.Models.DbModel;

namespace refactor_me.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }


        /// <summary>
        /// Use this method to save the changes
        /// that passed down from other services / api
        /// </summary>
        /// <returns></returns>


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}