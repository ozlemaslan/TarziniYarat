using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class OrdersMapping : EntityTypeConfiguration<Order>
    {
        public OrdersMapping()
        {
            Property(a => a.TotalPrice)
                .IsRequired();

            HasRequired(a => a.Person)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.PersonID)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Shipper)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.ShipperID)
                .WillCascadeOnDelete(false);
        }
    }
}
