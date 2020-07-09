using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class OrderDetailsMapping : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsMapping()
        {
            
            Property(a => a.Quantity)
                .IsRequired();

            HasRequired(a => a.Order)
               .WithMany(a => a.OrderDetails)
               .HasForeignKey(a => a.OrderID)
                  .WillCascadeOnDelete(false);

            HasRequired(a => a.Product)
               .WithMany(a => a.OrderDetails)
               .HasForeignKey(a => a.ProductID)
               .WillCascadeOnDelete(false);
        }
    }
}
