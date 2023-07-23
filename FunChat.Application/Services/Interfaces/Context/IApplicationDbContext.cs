using FunChat.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace FunChat.Application.Services.Interfaces.Context
{
    public interface IApplicationDbContext
    {

        #region Account

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        #endregion

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
