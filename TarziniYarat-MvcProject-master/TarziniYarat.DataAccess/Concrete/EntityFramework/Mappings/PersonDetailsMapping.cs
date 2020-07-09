using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class PersonDetailsMapping :EntityTypeConfiguration<PersonDetails>
    {
        public PersonDetailsMapping()
        {
           

            Property(a => a.Country)
                .HasMaxLength(30)
                .IsRequired();

            Property(a => a.City)
                .HasMaxLength(30)
                .IsRequired();

            Property(a => a.Address)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            HasRequired(a => a.Person)
                 .WithMany(a => a.PersonDetails)
                 .HasForeignKey(a => a.PersonID)
                 .WillCascadeOnDelete(false);
        }
    }
}
