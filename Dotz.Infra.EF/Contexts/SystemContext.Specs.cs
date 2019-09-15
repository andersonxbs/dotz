using Dotz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Dotz.Infra.EF.Contexts
{
    public partial class SystemContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(e => e.Address)
                .WithOne(e => e.User)
                .HasForeignKey<Address>(e => e.UserId)
                .IsRequired();

            builder.Entity<User>()
                .HasOne(e => e.Account)
                .WithOne(e => e.User)
                .HasForeignKey<Account>(e => e.UserId)
                .IsRequired();

            ConfigureBoolToZeroOneConvertion(builder);
        }

        private static void ConfigureBoolToZeroOneConvertion(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToZeroOneConverter<Int16>());
                    }
                }
            }
        }
    }
}
