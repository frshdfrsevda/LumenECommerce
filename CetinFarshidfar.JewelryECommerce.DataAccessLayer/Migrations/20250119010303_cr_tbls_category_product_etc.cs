using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cr_tbls_category_product_etc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2c10b5da-da38-40bf-acad-0f51ac207828"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c9393b4a-ffee-4d6e-95ce-009e5c9ecd9b"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentTagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Tags_ParentTagId",
                        column: x => x.ParentTagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialProduction = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: true),
                    EstimatedShippingTime = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDescriptions_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Queue = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "0b36102a-1312-4b3a-a525-9b924ee0ec2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46c31bb2-9d7c-4424-9cc2-84892b055c43"),
                column: "ConcurrencyStamp",
                value: "6fa1a0fe-c5a6-42d1-8cb1-986eb2de2ca4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "123cd6a4-9681-42a1-bfcd-b9e2aafd5708");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "8b3440ab-3364-4e91-aa90-453c85fcacab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b41a16e-2dcc-4378-b8fb-2823c1a6bcdf", new DateTime(2025, 1, 19, 4, 3, 2, 530, DateTimeKind.Local).AddTicks(8405), "AQAAAAIAAYagAAAAEAR31PfPicLTroeoufn7WBcU4B9ewirEePuQbHrFuoGH9UPzVTmsQ6sGKQbECLBkaQ==", "0ac03dae-0e62-4303-ad4e-c0dd697034f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11569eb3-085d-454f-a0b3-a94aca283fcb", new DateTime(2025, 1, 19, 4, 3, 2, 621, DateTimeKind.Local).AddTicks(1453), "AQAAAAIAAYagAAAAEOvQN/nIejSLZ+TjTpRk0zbaIADrKaJ09yK9I69fqL2PXDRuwZYSi+MwgiuC2rvwkw==", "00cf1244-0c89-4f7a-b3d2-c8e8bc356925" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38c85a1d-5bac-4932-8ba7-9334ea6f268c", new DateTime(2025, 1, 19, 4, 3, 2, 716, DateTimeKind.Local).AddTicks(9467), "AQAAAAIAAYagAAAAEHy3GZCZ38GlMh6NgXZF8evSrEFTnXLv5F2xhpjW76w2QLlWjY/Be2vK28uT/hbxfg==", "4458d106-9994-4acf-9c35-2527f6c35540" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811053d6-5f5e-4374-9b35-0914269fa539", new DateTime(2025, 1, 19, 4, 3, 2, 450, DateTimeKind.Local).AddTicks(3098), "AQAAAAIAAYagAAAAEJCaTFlhT+l9RPay6Is1EbKfbj+Cgi4ejk5KT98qXTulHDGigYzBbr+a9IJB6LGIpQ==", "ed666b4e-fee5-43d6-ade3-c202eaa8a7cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6def87b-c734-4a10-a0be-ced4a542d54c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f610f8f-635b-41cf-ae58-2987d26bbf01", new DateTime(2025, 1, 19, 4, 3, 2, 821, DateTimeKind.Local).AddTicks(8023), "AQAAAAIAAYagAAAAEMDBElPo9ARULubXKjBQPndlYvqEo6hUQZKlwh28lnz6+ERXrpgrxVGNne7zmf134Q==", "2b691dc4-ea7b-4b26-9fc6-6144df91009b" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6989), null, null, false, null, null, "Kolyeler", null },
                    { new Guid("c12817dd-6b83-46e0-8020-54095e11ed5b"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6943), null, null, false, null, null, "Bileklikler", null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "CoFounderId", "Country", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "Email", "FoundedDate", "Industry", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "NumberOfEmployees", "Phone", "PostalCode", "State", "Website" },
                values: new object[,]
                {
                    { new Guid("0b5253c9-4495-4948-946d-c2fdbce74476"), "Davutpaşa mh. 62.sk No:67", "İstanbul", new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"), "Türkiye", "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 443, DateTimeKind.Local).AddTicks(1335), null, null, "Şirketimiz, zarafet ve zamansız güzelliği temsil eden muhteşem mücevherler yaratmaya adanmıştır. Koleksiyonumuz, her anınızı parlatmak için özenle tasarlanmış mücevherlerden oluşmaktadır. Klasik tasarımlardan modern başyapıtlara kadar her parça, kalite ve işçilik konusundaki bağlılığımızın bir kanıtıdır.\r\n", "altinkafa@mucevherat.com", new DateTime(1901, 4, 21, 9, 23, 47, 0, DateTimeKind.Unspecified), "Mücevherat", false, null, null, "AltınKafa Mücevherat", 735, "212-202-3030", "34230", "Esenler", null },
                    { new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"), "1920 DR MARTIN L KING JR BLVD", "New York", new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"), "USA", "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 443, DateTimeKind.Local).AddTicks(1204), null, null, "We are a premier jewelry company dedicated to creating exquisite pieces that embody elegance and timeless beauty. Our collection features meticulously crafted jewelry designed to make every moment sparkle. From classic designs to contemporary masterpieces, each piece is a testament to our commitment to quality and craftsmanship.", "sarraf@jewelry.com", new DateTime(1994, 7, 10, 17, 17, 35, 0, DateTimeKind.Unspecified), "Jewelry", false, null, null, "Sarraf Jewelry", 489, "555-5971-3152", "10453-4416", "BRONX", null }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "ParentTagId" },
                values: new object[,]
                {
                    { 1, "Malzeme", null },
                    { 6, "Renk", null },
                    { 10, "Tarz", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("03ce06ea-9051-4e0a-b444-2d19cdebd94b"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6979), null, null, false, null, null, "Altın Bileklikler", new Guid("c12817dd-6b83-46e0-8020-54095e11ed5b") },
                    { new Guid("64f6d36f-8f31-4850-b8ad-9f36f1e730ac"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(7011), null, null, false, null, null, "Pırlanta Kolyeler", new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c") },
                    { new Guid("91904860-0d46-479b-b423-e80e4d11207b"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(7006), null, null, false, null, null, "Altın Kolyeler", new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c") },
                    { new Guid("d78bf8de-9d79-4ba0-9b62-7252c9738fdb"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6991), null, null, false, null, null, "İnci Kolyeler", new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c") },
                    { new Guid("f0cbfc44-2fa5-4e8c-a6cc-e508b9f57842"), "wm_cetin@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6985), null, null, false, null, null, "Taşlı Bileklikler", new Guid("c12817dd-6b83-46e0-8020-54095e11ed5b") }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "ParentTagId" },
                values: new object[,]
                {
                    { 2, "Altın", 1 },
                    { 3, "Gümüş", 1 },
                    { 4, "Elmas", 1 },
                    { 5, "Zümrüt", 1 },
                    { 7, "Sarı Altın", 6 },
                    { 8, "Beyaz Altın", 6 },
                    { 9, "Rose Altın", 6 },
                    { 11, "Modern", 10 },
                    { 12, "Klasik", 10 },
                    { 13, "Vintage", 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CompanyId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DiscountPercentage", "EstimatedShippingTime", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "ProductCode", "SpecialProduction", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), new Guid("03ce06ea-9051-4e0a-b444-2d19cdebd94b"), new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"), "com_rizasarraf@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 445, DateTimeKind.Local).AddTicks(1082), null, null, null, 3, false, null, null, "Altın Kelepçe, 24 Ayar 25 Gr Altın", 80000.00m, "P001", false, 100 },
                    { new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"), new Guid("64f6d36f-8f31-4850-b8ad-9f36f1e730ac"), new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"), "com_rizasarraf@lumen.com", new DateTime(2025, 1, 19, 4, 3, 2, 445, DateTimeKind.Local).AddTicks(1106), null, null, 4, 3, false, null, null, "Pırlanta Kolye, 0.33 Karat Özel Tasarım", 20000.00m, "P002", true, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductDescriptions",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), "wm_cetin@lumen.com" },
                    { new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"), "wm_cetin@lumen.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Path", "ProductId", "Queue" },
                values: new object[,]
                {
                    { 1, "img/products/P001/EBE9E0F2-49E4-4D8B-B7C5-5A06AC25C220.jpg", new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), 1 },
                    { 2, "images/products/P001/7FB73879-9575-4B34-AC4B-550FE2A7A212.jpg", new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), 2 },
                    { 3, "images/products/P002/2C2B225A-B9FC-411B-99E5-AB6088EAF2F4.jpg", new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "Id", "ProductId", "TagId" },
                values: new object[,]
                {
                    { 1, new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), 2 },
                    { 2, new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"), 7 },
                    { 3, new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"), 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentTagId",
                table: "Tags",
                column: "ParentTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDescriptions");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0b5253c9-4495-4948-946d-c2fdbce74476"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"));

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
    }
}
