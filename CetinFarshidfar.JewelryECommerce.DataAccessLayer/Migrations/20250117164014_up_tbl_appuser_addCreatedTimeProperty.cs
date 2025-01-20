using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class up_tbl_appuser_addCreatedTimeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e446aeda-8ede-4afd-9dd1-702835ae4d4f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f25ad1d3-ffe5-46fd-b6be-ca329c91782f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "2ba17a4f-c2b8-4b0c-861d-a7a014caea60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46c31bb2-9d7c-4424-9cc2-84892b055c43"),
                column: "ConcurrencyStamp",
                value: "f646c8f0-5f3e-403e-af7b-e6c0f04a1761");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "df7709e6-0165-4713-a097-fe378ada8d81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "3e01a50a-a0d7-4440-bbf0-9f1b3dcb52d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab09a5f0-539e-4eba-b649-bdcd6cd33419", new DateTime(2025, 1, 17, 19, 40, 13, 291, DateTimeKind.Local).AddTicks(6561), "AQAAAAIAAYagAAAAEBTc0knuAqqxpNxRo5n2Li5OzTybmNxVzipi2MEq5OEYYLPZRSyIz2lXqUGuMQLSAA==", "016c0061-c48f-4d74-9a56-61e8c2a96478" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a8ae674-99c1-4cdd-b728-6a19487d308d", new DateTime(2025, 1, 17, 19, 40, 13, 354, DateTimeKind.Local).AddTicks(2949), "AQAAAAIAAYagAAAAECQRs8wxrNPkYgkIMiLRLJ1MWhYhGYZNIDY+peM3chgJaHbd4HCT+BdtoCeu2EwS3Q==", "be9577ef-53a6-455a-8c92-6483ccf13934" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcdd0b97-de31-42ec-a9c8-934533863338", new DateTime(2025, 1, 17, 19, 40, 13, 421, DateTimeKind.Local).AddTicks(8478), "AQAAAAIAAYagAAAAEN7HH7r4jqZnKYXWH5RJPtwpIQ67v23ZQqmS3rhyLPzfHlubD6skgZjNw043UMzMIw==", "196396ee-ae6b-4558-a7a9-2f815be83206" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "735a97cc-77b1-46e4-b73d-3ecc63876dd4", new DateTime(2025, 1, 17, 19, 40, 13, 223, DateTimeKind.Local).AddTicks(9920), "AQAAAAIAAYagAAAAEDrrUNSt4AxGjbhHXWWRCTcBMlgb5rDuABQcVGTzF7jtlrZBOtvGCHK0WCqTb1g6HA==", "8ccd3c03-e62c-4741-9fbb-540e020890c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6def87b-c734-4a10-a0be-ced4a542d54c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828443e7-28d6-4c10-86b4-ca9fd2fb0ac2", new DateTime(2025, 1, 17, 19, 40, 13, 499, DateTimeKind.Local).AddTicks(1451), "AQAAAAIAAYagAAAAEDqKxf3oOSN+NfyZCpGCX3g7EgZpFAwft6j92BDoYlO5W+H/3OppvwMX8oe+vrHJEg==", "6300058b-1dcd-4433-a917-502a9e400bc8" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "CoFounderId", "Country", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "Email", "FoundedDate", "Industry", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "NumberOfEmployees", "Phone", "PostalCode", "State", "Website" },
                values: new object[,]
                {
                    { new Guid("2c10b5da-da38-40bf-acad-0f51ac207828"), "1920 DR MARTIN L KING JR BLVD", "New York", new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"), "USA", "wm_cetin@lumen.com", new DateTime(2025, 1, 17, 19, 40, 13, 220, DateTimeKind.Local).AddTicks(3989), null, null, "We are a premier jewelry company dedicated to creating exquisite pieces that embody elegance and timeless beauty. Our collection features meticulously crafted jewelry designed to make every moment sparkle. From classic designs to contemporary masterpieces, each piece is a testament to our commitment to quality and craftsmanship.", "sarraf@jewelry.com", new DateTime(1907, 11, 27, 0, 53, 11, 0, DateTimeKind.Unspecified), "Jewelry", false, null, null, "Sarraf Jewelry", 296, "555-5971-3152", "10453-4416", "BRONX", null },
                    { new Guid("c9393b4a-ffee-4d6e-95ce-009e5c9ecd9b"), "Davutpaşa mh. 62.sk No:67", "İstanbul", new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"), "Türkiye", "wm_cetin@lumen.com", new DateTime(2025, 1, 17, 19, 40, 13, 220, DateTimeKind.Local).AddTicks(4066), null, null, "Şirketimiz, zarafet ve zamansız güzelliği temsil eden muhteşem mücevherler yaratmaya adanmıştır. Koleksiyonumuz, her anınızı parlatmak için özenle tasarlanmış mücevherlerden oluşmaktadır. Klasik tasarımlardan modern başyapıtlara kadar her parça, kalite ve işçilik konusundaki bağlılığımızın bir kanıtıdır.\r\n", "altinkafa@mucevherat.com", new DateTime(1926, 4, 1, 4, 3, 36, 0, DateTimeKind.Unspecified), "Mücevherat", false, null, null, "AltınKafa Mücevherat", 81, "212-202-3030", "34230", "Esenler", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2c10b5da-da38-40bf-acad-0f51ac207828"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c9393b4a-ffee-4d6e-95ce-009e5c9ecd9b"));

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "AspNetUsers");

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
        }
    }
}
