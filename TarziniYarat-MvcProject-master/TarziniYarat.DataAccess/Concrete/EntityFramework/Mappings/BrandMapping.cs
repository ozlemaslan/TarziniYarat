using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class BrandMapping :EntityTypeConfiguration<Brand>
    {
        public BrandMapping()
        {
            Property(a => a.CompanyName)
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}
