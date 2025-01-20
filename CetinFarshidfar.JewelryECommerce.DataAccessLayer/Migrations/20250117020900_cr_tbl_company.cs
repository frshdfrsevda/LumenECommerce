using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cr_tbl_company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoFounderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CoFounderId",
                        column: x => x.CoFounderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "632ba13a-f166-4366-9623-d34b742af03c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46c31bb2-9d7c-4424-9cc2-84892b055c43"),
                column: "ConcurrencyStamp",
                value: "382f9a70-280c-4894-89e5-c97a198eecb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "9a1e142f-e27a-4a7f-a829-ce832992a0bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "f1b8823d-4263-483e-8b8d-e0a8ad9482df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49d7caf8-5a67-473c-aa91-883629c93923", "AQAAAAIAAYagAAAAEMGYcJz0aBMEDar9AQWsOXWJqFMbmCJgjgkcUKfagq84rTvNt+AuUaAPnrNfskbvzw==", "c648b4bc-4887-4b9d-aac3-47e1d2254cce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e155d37-95cb-41dc-a173-b5dc83e9fb07", "AQAAAAIAAYagAAAAEAG3MnQnSLVLbkHJR4c6Cce0ttQNz1CG6BzTd06qfSM7zPvmmXBCL+GF4pA20Q7BcA==", "01c2d19f-7b03-4dc0-8ec8-aa9bc95257a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc5fe4e5-3b82-40b2-90d2-3c8d49811382", "AQAAAAIAAYagAAAAEEeEjvI9KRW9ch3PFDPX1qfWWpehYuC5eFtXYluCoR8IPG2G+lQuMtCJfcvEOjfSUw==", "f285b29a-18ca-44ef-bba9-948835c83c8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caf45102-f3a9-4226-8677-894d837d6548", "AQAAAAIAAYagAAAAECIjU4X5SNUuY9A4E9FxqMcJqp8ytfy040R/zsmAxFnjM60EyIT+cVpOqK3oruEyPg==", "072060c8-1e69-4e9b-b487-04a89bdfb7a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6def87b-c734-4a10-a0be-ced4a542d54c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64c4a8e5-fba2-4d2d-a86a-672411c2b483", "AQAAAAIAAYagAAAAEJ87WOu1fujAYMjroNZVxFwCETza6u/OlDbQFn6XHsN6S+Gh9mffE/iQVKF6x3yKiA==", "b7c1c376-1935-4db4-aa27-f30331cf4f8b" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "CoFounderId", "Country", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "Email", "FoundedDate", "Industry", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "NumberOfEmployees", "Phone", "PostalCode", "State", "Website" },
                values: new object[,]
                {
                    { new Guid("e446aeda-8ede-4afd-9dd1-702835ae4d4f"), "Davutpaşa mh. 62.sk No:67", "İstanbul", new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"), "Türkiye", "wm_cetin@lumen.com", new DateTime(2025, 1, 17, 5, 8, 59, 357, DateTimeKind.Local).AddTicks(1972), null, null, "Şirketimiz, zarafet ve zamansız güzelliği temsil eden muhteşem mücevherler yaratmaya adanmıştır. Koleksiyonumuz, her anınızı parlatmak için özenle tasarlanmış mücevherlerden oluşmaktadır. Klasik tasarımlardan modern başyapıtlara kadar her parça, kalite ve işçilik konusundaki bağlılığımızın bir kanıtıdır.\r\n", "altinkafa@mucevherat.com", new DateTime(1942, 3, 21, 23, 45, 29, 0, DateTimeKind.Unspecified), "Mücevherat", false, null, null, "AltınKafa Mücevherat", 405, "212-202-3030", "34230", "Esenler", null },
                    { new Guid("f25ad1d3-ffe5-46fd-b6be-ca329c91782f"), "1920 DR MARTIN L KING JR BLVD", "New York", new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"), "USA", "wm_cetin@lumen.com", new DateTime(2025, 1, 17, 5, 8, 59, 357, DateTimeKind.Local).AddTicks(1863), null, null, "We are a premier jewelry company dedicated to creating exquisite pieces that embody elegance and timeless beauty. Our collection features meticulously crafted jewelry designed to make every moment sparkle. From classic designs to contemporary masterpieces, each piece is a testament to our commitment to quality and craftsmanship.", "sarraf@jewelry.com", new DateTime(1997, 6, 21, 2, 26, 28, 0, DateTimeKind.Unspecified), "Jewelry", false, null, null, "Sarraf Jewelry", 591, "555-5971-3152", "10453-4416", "BRONX", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CoFounderId",
                table: "Companies",
                column: "CoFounderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "1f380abf-06d0-476c-9892-87aa3cd0fda5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46c31bb2-9d7c-4424-9cc2-84892b055c43"),
                column: "ConcurrencyStamp",
                value: "31d94694-9af3-487e-8a2f-c6ec8a41bcfa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "f05f8102-afa8-47fc-a29f-60a8c35f4b01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "7ca357a1-bdd2-439e-92bb-411de832bec3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54d025cd-5015-4148-9430-aec779fff938", "AQAAAAIAAYagAAAAEHjJZk0g+bGlhisDsqB7lg+qKdKXehZJW+AKiAx/Oe86rkwKlQDazyofT4e5QjiSXQ==", "2a8075c0-17b5-4ee0-b436-bd7e254253b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "731bf447-1a25-4283-9533-ac16fade4746", "AQAAAAIAAYagAAAAEP6RPi0H/ku/IPxx1/PaV4v50IuX+7U5k3+hEFLMzw4prbE1maZa9fG22pe/dVH12A==", "c10c81f8-81c2-415c-92ae-a5261f3dc93b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22b827dd-52fd-43f8-837c-02841c8cc410", "AQAAAAIAAYagAAAAEFASQxSfSS7IqhHnby2wsZ1og6hUE1HOH8mOjk3QhMLC4LO94ZI9HOxnnaePYU3fFg==", "2606b4ca-a0d0-4889-a391-311f874f1202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33436cf3-e755-4b8c-85a1-75b4ac91c5c6", "AQAAAAIAAYagAAAAEM7f06/PCwgmC9L65wSOX2oDy/dYxwQNzPN/npkiOOAvhbdzGQyOtf9zC5Uj/HkRCw==", "44c9da22-912b-451e-ae66-cccf749b5160" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6def87b-c734-4a10-a0be-ced4a542d54c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b1f0bbb-1217-4401-9df7-dea9ea114316", "AQAAAAIAAYagAAAAEPubfuJdXlyYY3MKOMMOnoR2yGU95rVf778oEoU3xKTpfepD4bcCof6/1BLRM50UEQ==", "90bd0d73-f9bb-480c-a4e9-a4cc64bcf26f" });
        }
    }
}
