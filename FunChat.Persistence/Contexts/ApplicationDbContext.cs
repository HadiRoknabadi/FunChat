using FunChat.Application.Services.Interfaces.Context;
using FunChat.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FunChat.Application.Utils;

namespace FunChat.Persistence.Contexts
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,int>,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            var persistenceAssembly = typeof(ApplicationDbContext).Assembly;

            builder.AddRestrictDeleteBehaviorConvention();

            builder.RegisterEntityTypeConfiguration(persistenceAssembly);

            builder.AddAuditProperties();

            base.OnModelCreating(builder);

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted);

            foreach (var entity in modifiedEntries)
            {
                var entityType = entity.Context.Model.FindEntityType(entity.Entity.GetType());

                var inserted = entityType.FindProperty("InsertTime");
                var updateTime = entityType.FindProperty("UpdateTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                var RemovedTime = entityType.FindProperty("RemovedTime");


                if (entity.State == EntityState.Added && inserted != null)
                {
                    entity.Property("InsertTime").CurrentValue = DateTime.Now;
                }

                if (entity.State == EntityState.Modified && updateTime != null)
                {
                    entity.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (entity.State == EntityState.Deleted && RemovedTime != null && IsRemoved != null)
                {
                    entity.Property("RemovedTime").CurrentValue = DateTime.Now;
                    entity.Property("IsRemoved").CurrentValue = true;
                    entity.State = EntityState.Modified;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
