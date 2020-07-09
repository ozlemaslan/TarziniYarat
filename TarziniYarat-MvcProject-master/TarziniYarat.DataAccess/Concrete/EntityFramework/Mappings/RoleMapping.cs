using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class RoleMapping: EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            HasKey(a => a.RoleID);
            Property(a => a.RoleName)
                .HasMaxLength(50)
                .IsRequired();            
        }
    }
}
