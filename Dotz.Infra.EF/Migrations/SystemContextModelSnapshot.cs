﻿// <auto-generated />
using System;
using Dotz.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotz.Infra.EF.Migrations
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Dotz.Domain.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("PointBalance");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(8268),
                            PointBalance = 466000,
                            UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.AccountTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int>("NewBalance");

                    b.Property<int>("Points");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("accounttransactions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccountId = 1L,
                            CreatedAt = new DateTime(2019, 9, 11, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(3202),
                            Description = "Amazon Credit",
                            NewBalance = 492500,
                            Points = 1500,
                            Type = 0
                        },
                        new
                        {
                            Id = 2L,
                            AccountId = 1L,
                            CreatedAt = new DateTime(2019, 9, 12, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4281),
                            Description = "Purchase",
                            NewBalance = 476600,
                            Points = 14400,
                            Type = 1
                        },
                        new
                        {
                            Id = 3L,
                            AccountId = 1L,
                            CreatedAt = new DateTime(2019, 9, 13, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4305),
                            Description = "Extra Credit",
                            NewBalance = 512000,
                            Points = 21000,
                            Type = 0
                        },
                        new
                        {
                            Id = 4L,
                            AccountId = 1L,
                            CreatedAt = new DateTime(2019, 9, 14, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4318),
                            Description = "Purchase",
                            NewBalance = 487880,
                            Points = 3120,
                            Type = 1
                        },
                        new
                        {
                            Id = 5L,
                            AccountId = 1L,
                            CreatedAt = new DateTime(2019, 9, 15, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4330),
                            Description = "Purchase",
                            NewBalance = 466000,
                            Points = 25000,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Complement");

                    b.Property<string>("ContactName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Neighborhood");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "São Paulo",
                            Complement = "Google Brasil",
                            ContactName = "Shimpachi",
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 932, DateTimeKind.Local).AddTicks(623),
                            Neighborhood = "Itaim Bibi",
                            Phone = "(11) 2395-8400",
                            PostalCode = "04538-133",
                            State = "SP",
                            StreetName = "Av. Brg. Faria Lima",
                            StreetNumber = "3477",
                            UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("DueDate");

                    b.Property<long>("OrderId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("deliveries");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(838),
                            DueDate = new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(2037),
                            OrderId = 1L,
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4106),
                            DueDate = new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4119),
                            OrderId = 2L,
                            Status = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4134),
                            DueDate = new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4137),
                            OrderId = 3L,
                            Status = 2
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("TotalPoints");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(6379),
                            TotalPoints = 89803,
                            UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(7457),
                            TotalPoints = 59748,
                            UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(7473),
                            TotalPoints = 14937,
                            UserId = "aa33380a-c427-4530-b2a8-bd45ae0e8cef"
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<long>("OrderId");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("UnityPoints");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("orderItems");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(8257),
                            OrderId = 1L,
                            ProductId = 1L,
                            Quantity = 1,
                            UnityPoints = 44992
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(12),
                            OrderId = 1L,
                            ProductId = 4L,
                            Quantity = 3,
                            UnityPoints = 14937
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(35),
                            OrderId = 2L,
                            ProductId = 4L,
                            Quantity = 4,
                            UnityPoints = 14937
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(39),
                            OrderId = 3L,
                            ProductId = 4L,
                            Quantity = 1,
                            UnityPoints = 14937
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("Points");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(5002),
                            Points = 44992,
                            Quantity = 2,
                            Title = "DigiCam Binóculo com Câmera Digital"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6409),
                            Points = 14992,
                            Quantity = 13,
                            Title = "Polidor Automotivo"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6430),
                            Points = 3676,
                            Quantity = 1,
                            Title = "Forma Para Pizza 25cm - Alumínio Fortaleza"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6434),
                            Points = 14937,
                            Quantity = 21,
                            Title = "Panela de Vápor Elétrica Oster Gran Taste 700W"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6438),
                            Points = 5811,
                            Quantity = 10,
                            Title = "Travesseiro Magico - Santista"
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<short>("EmailConfirmed");

                    b.Property<short>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<short>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<short>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "aa33380a-c427-4530-b2a8-bd45ae0e8cef",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f70526fa-5575-478e-bd15-082a794da723",
                            Email = "gintoki@oddjobsgin.com",
                            EmailConfirmed = (short)0,
                            LockoutEnabled = (short)1,
                            Name = "Sakata Gintoki",
                            NormalizedEmail = "GINTOKI@ODDJOBSGIN.COM",
                            NormalizedUserName = "GINTOKI@ODDJOBSGIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAzxCT/OEOsvhFl8SJwmgGTgL6gzZCKKpngoHwB5eHQnYyhMo13XYDyTY2+dVx32jQ==",
                            PhoneNumberConfirmed = (short)0,
                            SecurityStamp = "B2BX54QK5XIGVSF5E2UIW756NRTFEY2R",
                            TwoFactorEnabled = (short)0,
                            UserName = "gintoki@oddjobsgin.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Account", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Dotz.Domain.Entities.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dotz.Domain.Entities.AccountTransaction", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Address", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Dotz.Domain.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("Dotz.Domain.Entities.Delivery", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Dotz.Domain.ValueObjects.DeliveryAddress", "Address", b1 =>
                        {
                            b1.Property<long>("DeliveryId");

                            b1.Property<string>("City");

                            b1.Property<string>("Complement");

                            b1.Property<string>("ContactName");

                            b1.Property<string>("Neighborhood");

                            b1.Property<string>("Phone");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("State");

                            b1.Property<string>("StreetName");

                            b1.Property<string>("StreetNumber");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("deliveries");

                            b1.HasOne("Dotz.Domain.Entities.Delivery")
                                .WithOne("Address")
                                .HasForeignKey("Dotz.Domain.ValueObjects.DeliveryAddress", "DeliveryId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    DeliveryId = 1L,
                                    City = "São Paulo",
                                    Complement = "Google Brasil",
                                    ContactName = "Shimpachi",
                                    Neighborhood = "Itaim Bibi",
                                    Phone = "(11) 2395-8400",
                                    PostalCode = "04538-133",
                                    State = "SP",
                                    StreetName = "Av. Brg. Faria Lima",
                                    StreetNumber = "3477"
                                },
                                new
                                {
                                    DeliveryId = 2L,
                                    City = "São Paulo",
                                    Complement = "Google Brasil",
                                    ContactName = "Shimpachi",
                                    Neighborhood = "Itaim Bibi",
                                    Phone = "(11) 2395-8400",
                                    PostalCode = "04538-133",
                                    State = "SP",
                                    StreetName = "Av. Brg. Faria Lima",
                                    StreetNumber = "3477"
                                },
                                new
                                {
                                    DeliveryId = 3L,
                                    City = "São Paulo",
                                    Complement = "Google Brasil",
                                    ContactName = "Shimpachi",
                                    Neighborhood = "Itaim Bibi",
                                    Phone = "(11) 2395-8400",
                                    PostalCode = "04538-133",
                                    State = "SP",
                                    StreetName = "Av. Brg. Faria Lima",
                                    StreetNumber = "3477"
                                });
                        });
                });

            modelBuilder.Entity("Dotz.Domain.Entities.Order", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dotz.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dotz.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dotz.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dotz.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
