using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            Property(a => a.CategoryName)
                .HasMaxLength(30)
                .IsRequired();

            Property(a => a.Description)
                .HasMaxLength(30)
                .IsRequired();

            

        }
    }
}
