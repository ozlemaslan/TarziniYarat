using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class CombineMapping :EntityTypeConfiguration<Combine>
    {
        public CombineMapping()
        {
            Property(a => a.NumberOfLikes)
                .IsRequired();

            Property(a => a.NumberOfComments)
                .IsRequired();



        }
    }
}
