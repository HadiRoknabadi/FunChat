using FunChat.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunChat.Persistence.Configs.Account
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(350);
            builder.Property(u=>u.Email).IsRequired().HasMaxLength(256);
            builder.Property(u=>u.UserAvatar).IsRequired().HasMaxLength(256);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.NormalizedEmail).IsRequired();
            builder.Property(u => u.EmailActiveCode).IsRequired().HasMaxLength(256);

            
        }
    }
}
