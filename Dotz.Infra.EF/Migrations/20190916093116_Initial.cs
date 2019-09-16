using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotz.Infra.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<short>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<short>(nullable: false),
                    TwoFactorEnabled = table.Column<short>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<short>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    PointBalance = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    TotalPoints = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounttransactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    NewBalance = table.Column<int>(nullable: false),
                    AccountId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounttransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounttransactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    Address_ContactName = table.Column<string>(nullable: true),
                    Address_PostalCode = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Neighborhood = table.Column<string>(nullable: true),
                    Address_StreetName = table.Column<string>(nullable: true),
                    Address_StreetNumber = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(nullable: true),
                    Address_Phone = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deliveries_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnityPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa33380a-c427-4530-b2a8-bd45ae0e8cef", 0, "f70526fa-5575-478e-bd15-082a794da723", "gintoki@oddjobsgin.com", (short)0, (short)1, null, "Sakata Gintoki", "GINTOKI@ODDJOBSGIN.COM", "GINTOKI@ODDJOBSGIN.COM", "AQAAAAEAACcQAAAAEAzxCT/OEOsvhFl8SJwmgGTgL6gzZCKKpngoHwB5eHQnYyhMo13XYDyTY2+dVx32jQ==", null, (short)0, "B2BX54QK5XIGVSF5E2UIW756NRTFEY2R", (short)0, "gintoki@oddjobsgin.com" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Points", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(5002), null, 44992, 2, "DigiCam Binóculo com Câmera Digital" },
                    { 2L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6409), null, 14992, 13, "Polidor Automotivo" },
                    { 3L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6430), null, 3676, 1, "Forma Para Pizza 25cm - Alumínio Fortaleza" },
                    { 4L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6434), null, 14937, 21, "Panela de Vápor Elétrica Oster Gran Taste 700W" },
                    { 5L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(6438), null, 5811, 10, "Travesseiro Magico - Santista" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "PointBalance", "UserId" },
                values: new object[] { 1L, new DateTime(2019, 9, 16, 6, 31, 14, 934, DateTimeKind.Local).AddTicks(8268), null, 466000, "aa33380a-c427-4530-b2a8-bd45ae0e8cef" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "ContactName", "CreatedAt", "DeletedAt", "Neighborhood", "Phone", "PostalCode", "State", "StreetName", "StreetNumber", "UserId" },
                values: new object[] { 1L, "São Paulo", "Google Brasil", "Shimpachi", new DateTime(2019, 9, 16, 6, 31, 14, 932, DateTimeKind.Local).AddTicks(623), null, "Itaim Bibi", "(11) 2395-8400", "04538-133", "SP", "Av. Brg. Faria Lima", "3477", "aa33380a-c427-4530-b2a8-bd45ae0e8cef" });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "TotalPoints", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(6379), null, 89803, "aa33380a-c427-4530-b2a8-bd45ae0e8cef" },
                    { 2L, new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(7457), null, 59748, "aa33380a-c427-4530-b2a8-bd45ae0e8cef" },
                    { 3L, new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(7473), null, 14937, "aa33380a-c427-4530-b2a8-bd45ae0e8cef" }
                });

            migrationBuilder.InsertData(
                table: "accounttransactions",
                columns: new[] { "Id", "AccountId", "CreatedAt", "DeletedAt", "Description", "NewBalance", "Points", "Type" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2019, 9, 11, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(3202), null, "Amazon Credit", 492500, 1500, 0 },
                    { 2L, 1L, new DateTime(2019, 9, 12, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4281), null, "Purchase", 476600, 14400, 1 },
                    { 3L, 1L, new DateTime(2019, 9, 13, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4305), null, "Extra Credit", 512000, 21000, 0 },
                    { 4L, 1L, new DateTime(2019, 9, 14, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4318), null, "Purchase", 487880, 3120, 1 },
                    { 5L, 1L, new DateTime(2019, 9, 15, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(4330), null, "Purchase", 466000, 25000, 1 }
                });

            migrationBuilder.InsertData(
                table: "deliveries",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DueDate", "OrderId", "Status", "Address_City", "Address_Complement", "Address_ContactName", "Address_Neighborhood", "Address_Phone", "Address_PostalCode", "Address_State", "Address_StreetName", "Address_StreetNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(838), null, new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(2037), 1L, 0, "São Paulo", "Google Brasil", "Shimpachi", "Itaim Bibi", "(11) 2395-8400", "04538-133", "SP", "Av. Brg. Faria Lima", "3477" },
                    { 2L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4106), null, new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4119), 2L, 1, "São Paulo", "Google Brasil", "Shimpachi", "Itaim Bibi", "(11) 2395-8400", "04538-133", "SP", "Av. Brg. Faria Lima", "3477" },
                    { 3L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4134), null, new DateTime(2019, 9, 26, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(4137), 3L, 2, "São Paulo", "Google Brasil", "Shimpachi", "Itaim Bibi", "(11) 2395-8400", "04538-133", "SP", "Av. Brg. Faria Lima", "3477" }
                });

            migrationBuilder.InsertData(
                table: "orderItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "OrderId", "ProductId", "Quantity", "UnityPoints" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 9, 16, 6, 31, 14, 935, DateTimeKind.Local).AddTicks(8257), null, 1L, 1L, 1, 44992 },
                    { 2L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(12), null, 1L, 4L, 3, 14937 },
                    { 3L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(35), null, 2L, 4L, 4, 14937 },
                    { 4L, new DateTime(2019, 9, 16, 6, 31, 14, 936, DateTimeKind.Local).AddTicks(39), null, 3L, 4L, 1, 14937 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounttransactions_AccountId",
                table: "accounttransactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_OrderId",
                table: "deliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounttransactions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
