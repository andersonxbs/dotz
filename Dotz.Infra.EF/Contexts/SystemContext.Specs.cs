using Dotz.Domain.Entities;
using Dotz.Domain.Enumerators;
using Dotz.Domain.Services;
using Dotz.Domain.ValueObjects;
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

            builder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.User)
                .IsRequired();

            builder.Entity<Account>()
                .HasMany(e => e.Transactions)
                .WithOne(e => e.Account)
                .IsRequired();

            builder.Entity<AccountTransaction>()
                .ToTable("accounttransactions");

            builder.Entity<Delivery>()
                .ToTable("deliveries");

            builder.Entity<Delivery>()
                .OwnsOne(e => e.Address);

            builder.Entity<Order>()
                .ToTable("orders");

            builder.Entity<Order>()
                .HasOne(e => e.Delivery)
                .WithOne(e => e.Order)
                .HasForeignKey<Delivery>(e => e.OrderId)
                .IsRequired();

            builder.Entity<Order>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Order)
                .IsRequired();

            builder.Entity<OrderItem>()
                .ToTable("orderItems");

            builder.Entity<Product>()
                .ToTable("products");

            ConfigureBoolToZeroOneConvertion(builder);

            Seed(builder);
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
        private void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = "aa33380a-c427-4530-b2a8-bd45ae0e8cef",
                    UserName = "gintoki@oddjobsgin.com",
                    NormalizedUserName = "GINTOKI@ODDJOBSGIN.COM",
                    Email = "gintoki@oddjobsgin.com",
                    NormalizedEmail = "GINTOKI@ODDJOBSGIN.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEAzxCT/OEOsvhFl8SJwmgGTgL6gzZCKKpngoHwB5eHQnYyhMo13XYDyTY2+dVx32jQ==",
                    SecurityStamp = "B2BX54QK5XIGVSF5E2UIW756NRTFEY2R",
                    ConcurrencyStamp = "f70526fa-5575-478e-bd15-082a794da723",
                    LockoutEnabled = true,
                    Name = "Sakata Gintoki",
                    Account = null
                }
            );

            var address = new Address
            {
                Id = 1,
                ContactName = "Shimpachi",
                PostalCode = "04538-133",
                State = "SP",
                City = "São Paulo",
                Neighborhood = "Itaim Bibi",
                StreetName = "Av. Brg. Faria Lima",
                StreetNumber = "3477",
                Complement = "Google Brasil",
                Phone = "(11) 2395-8400",
                UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
            };

            builder.Entity<Address>().HasData(
                address
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "DigiCam Binóculo com Câmera Digital", Points = 44992, Quantity = 2 },
                new Product { Id = 2, Title = "Polidor Automotivo", Points = 14992, Quantity = 13 },
                new Product { Id = 3, Title = "Forma Para Pizza 25cm - Alumínio Fortaleza", Points = 3676, Quantity = 1 },
                new Product { Id = 4, Title = "Panela de Vápor Elétrica Oster Gran Taste 700W", Points = 14937, Quantity = 21 },
                new Product { Id = 5, Title = "Travesseiro Magico - Santista", Points = 5811, Quantity = 10 }
            );

            builder.Entity<Account>().HasData(
                new Account { Id = 1, PointBalance = 466000, UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef" }
            );

            var basePointBalance = 491000;
            builder.Entity<AccountTransaction>().HasData(
                new AccountTransaction { Id = 1, Type = TransactionType.Credit, Description = "Amazon Credit", Points = 1500, NewBalance = (basePointBalance + 1500), AccountId = 1, CreatedAt = DateTime.Now.AddDays(-5) },
                new AccountTransaction { Id = 2, Type = TransactionType.Debit, Description = "Purchase", Points = 14400, NewBalance = (basePointBalance - 14400), AccountId = 1, CreatedAt = DateTime.Now.AddDays(-4) },
                new AccountTransaction { Id = 3, Type = TransactionType.Credit, Description = "Extra Credit", Points = 21000, NewBalance = (basePointBalance + 21000), AccountId = 1, CreatedAt = DateTime.Now.AddDays(-3) },
                new AccountTransaction { Id = 4, Type = TransactionType.Debit, Description = "Purchase", Points = 3120, NewBalance = (basePointBalance - 3120), AccountId = 1, CreatedAt = DateTime.Now.AddDays(-2) },
                new AccountTransaction { Id = 5, Type = TransactionType.Debit, Description = "Purchase", Points = 25000, NewBalance = (basePointBalance - 25000), AccountId = 1, CreatedAt = DateTime.Now.AddDays(-1) }
            );

            builder.Entity<Order>().HasData(
                new Order { Id = 1, TotalPoints = 89803, UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef" },
                new Order { Id = 2, TotalPoints = 59748, UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef" },
                new Order { Id = 3, TotalPoints = 14937, UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef" }
            );

            builder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, ProductId = 1, UnityPoints = 44992, Quantity = 1, OrderId = 1 },
                new OrderItem { Id = 2, ProductId = 4, UnityPoints = 14937, Quantity = 3, OrderId = 1 },
                new OrderItem { Id = 3, ProductId = 4, UnityPoints = 14937, Quantity = 4, OrderId = 2 },
                new OrderItem { Id = 4, ProductId = 4, UnityPoints = 14937, Quantity = 1, OrderId = 3 }
            );

            builder.Entity<Delivery>().HasData(
                new Delivery { Id = 1, DueDate = DeliveryServices.EstimateDueDateForAddress(address), Status = DeliveryStatus.Processing, Address = null, OrderId = 1 },
                new Delivery { Id = 2, DueDate = DeliveryServices.EstimateDueDateForAddress(address), Status = DeliveryStatus.Dispatched, Address = null, OrderId = 2 },
                new Delivery { Id = 3, DueDate = DeliveryServices.EstimateDueDateForAddress(address), Status = DeliveryStatus.Delivered, Address = null, OrderId = 3 }
            );

            builder.Entity<DeliveryAddress>().HasData(
                new DeliveryAddress
                {
                    DeliveryId = 1,
                    ContactName = "Shimpachi",
                    PostalCode = "04538-133",
                    State = "SP",
                    City = "São Paulo",
                    Neighborhood = "Itaim Bibi",
                    StreetName = "Av. Brg. Faria Lima",
                    StreetNumber = "3477",
                    Complement = "Google Brasil",
                    Phone = "(11) 2395-8400"
                },
                new DeliveryAddress
                {
                    DeliveryId = 2,
                    ContactName = "Shimpachi",
                    PostalCode = "04538-133",
                    State = "SP",
                    City = "São Paulo",
                    Neighborhood = "Itaim Bibi",
                    StreetName = "Av. Brg. Faria Lima",
                    StreetNumber = "3477",
                    Complement = "Google Brasil",
                    Phone = "(11) 2395-8400"
                },
                new DeliveryAddress
                {
                    DeliveryId = 3,
                    ContactName = "Shimpachi",
                    PostalCode = "04538-133",
                    State = "SP",
                    City = "São Paulo",
                    Neighborhood = "Itaim Bibi",
                    StreetName = "Av. Brg. Faria Lima",
                    StreetNumber = "3477",
                    Complement = "Google Brasil",
                    Phone = "(11) 2395-8400"
                }
            );
        }
    }
}
