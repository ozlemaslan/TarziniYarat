namespace TarziniYarat.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TarziniYarat.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TarziniYarat.DataAccess.Concrete.EntityFramework.TarziniYaratDbContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TarziniYarat.DataAccess.Concrete.EntityFramework.TarziniYaratDbContext context)
        {

            //List<Role> roles = new List<Role>()
            //{
            //    new Role(){RoleName="Admin"},
            //    new Role(){RoleName="Uye"},
            //    new Role(){RoleName="Modelist"},
            //    new Role(){RoleName="Ziyaretci"},

            //};
            //context.Roles.AddRange(roles);

            Person admin = new Person()
            {
                Name = "Admin",
                Surname = "Admin",
                Username = "thelastdance@mail.com",
                Password = "123456",
                CreatedDate = DateTime.Now,
                IsActive = true,
                RoleID = 1,
                TCKN = "12345678978",
                BirthDate = DateTime.Now,

            };
            context.Persons.Add(admin);
            context.SaveChanges();
        }
    }
}
