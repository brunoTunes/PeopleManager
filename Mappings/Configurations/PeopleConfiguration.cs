using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Mappings.Configurations
{
    internal class PeopleConfiguration : EntityTypeConfiguration<Person>
    {
        public PeopleConfiguration()
        {
            ToTable("Person");
            HasKey(p => p.Id);
            HasMany<Vacation>(p => p.Vacations);
        }
    }
}
 