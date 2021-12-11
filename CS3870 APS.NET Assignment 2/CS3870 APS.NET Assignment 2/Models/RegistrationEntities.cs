using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CS3870_APS.NET_Assignment_2.Models
{
    public partial class RegistrationEntities : DbContext
    {
        public RegistrationEntities()
            : base("name=RegistrationEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public DbSet<Registration> Registrations { get; set; }

    }
}
