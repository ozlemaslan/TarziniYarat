using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework
{
   public class TarziniYaratDbContext :DbContext
    {
        public TarziniYaratDbContext()
           : base("name=TarziniYaratConnStr")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Combine> Combines { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new PersonDetailsMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new OrdersMapping());
            modelBuilder.Configurations.Add(new OrderDetailsMapping());
            modelBuilder.Configurations.Add(new BrandMapping());
            modelBuilder.Configurations.Add(new CommentMapping());
            modelBuilder.Configurations.Add(new LikeMapping());
            modelBuilder.Configurations.Add(new CombineMapping());
            modelBuilder.Configurations.Add(new ShipperMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
