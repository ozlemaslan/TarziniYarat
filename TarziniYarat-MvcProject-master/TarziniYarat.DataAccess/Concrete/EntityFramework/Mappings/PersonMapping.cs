using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Mappings
{
    class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            Property(a => a.Name)
                .HasMaxLength(25)
                .IsRequired();

            Property(a => a.Surname)
               .HasMaxLength(25)
               .IsRequired();

            Property(a => a.TCKN)
               .HasMaxLength(11)
               .IsRequired();

            Property(a => a.Username)
               .HasMaxLength(25)
               .IsRequired();

            Property(a => a.Password)
               .HasMaxLength(25)
               .IsRequired();

            Property(a => a.BirthDate)
               .IsRequired();

            HasRequired(a => a.Role)
                .WithMany(a => a.Persons)
                .HasForeignKey(a => a.RoleID);

            HasMany(a => a.Likes)
                .WithRequired(a => a.Person)
                .HasForeignKey(a => a.PersonID)
                 .WillCascadeOnDelete(false);

            HasMany(a => a.Orders)
                .WithRequired(a => a.Person)
                .HasForeignKey(a => a.PersonID)
                .WillCascadeOnDelete(false);

           



        }
    }
}
