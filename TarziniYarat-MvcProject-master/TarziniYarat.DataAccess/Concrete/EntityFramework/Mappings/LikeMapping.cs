using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class LikeMapping :EntityTypeConfiguration<Like>
    {
        public LikeMapping()
        {
            Property(a => a.LikeDate)
                .IsRequired();

            HasRequired(a => a.Person)
                .WithMany(a => a.Likes)
                .HasForeignKey(a => a.PersonID);

            HasRequired(a => a.Combine)
                .WithMany(a => a.Likes)
                .HasForeignKey(a => a.CombineID);

        }
    }
}
