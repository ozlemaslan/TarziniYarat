using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class ProductMapping :EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            Property(a => a.Description)
                .HasMaxLength(500)
                .IsRequired();

            Property(a => a.UnitsInStock)
                .IsRequired();

            Property(a => a.ProductTitle)
                .HasMaxLength(30)
                .IsRequired();

            Property(a => a.BodySize)
                .IsRequired();

            HasRequired(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.CategoryID);

            HasRequired(a => a.Brand)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.BrandID);

        }
    }
}
