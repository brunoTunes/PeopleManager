using Mappings.Configurations;
using System.Data.Entity;

namespace Mappings
{
    public class PeopleManagerContext : DbContext
    {
        public PeopleManagerContext() : base()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeopleConfiguration());
        }
    }
}
