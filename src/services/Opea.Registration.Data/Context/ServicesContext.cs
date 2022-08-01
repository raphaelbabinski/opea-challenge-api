using Microsoft.EntityFrameworkCore;
using Opea.Core.Data;
using Opea.Registration.Business.Domain.Client;
using System.Linq;
using System.Threading.Tasks;

namespace Opea.Registration.Data.Context
{
    public class ServicesContext : DbContext, IUnitOfWork
    {
        public ServicesContext(DbContextOptions<ServicesContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<ValidationResult>();
            //modelBuilder.Ignore<Event>();

            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServicesContext).Assembly);
        }


        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }
}
