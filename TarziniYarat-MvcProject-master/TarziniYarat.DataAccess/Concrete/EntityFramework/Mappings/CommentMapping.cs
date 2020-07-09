using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            Property(a => a.Content)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.CommentDate)
                .IsRequired();


            HasOptional(a => a.Combine)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.CombineID);


            HasOptional(a => a.Product)
              .WithMany(a => a.Comments)
              .HasForeignKey(a => a.ProductID);

        }
    }
}
