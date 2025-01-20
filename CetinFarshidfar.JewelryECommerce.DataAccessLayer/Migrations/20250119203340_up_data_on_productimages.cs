using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class up_data_on_productimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "0a804f8f-fdb0-4797-8fa2-a2ffc5dfadfb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46c31bb2-9d7c-4424-9cc2-84892b055c43"),
                column: "ConcurrencyStamp",
                value: "d9a92ba9-af7a-48b2-a59d-9f284ff487c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "43ee203b-b338-44d4-a6a9-8e7a529ccdfd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "e9804891-d688-4ae2-a136-7fe5315da1f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdeff58f-7f39-410f-8234-6dbbc7d712ed", new DateTime(2025, 1, 19, 23, 33, 38, 808, DateTimeKind.Local).AddTicks(9674), "AQAAAAIAAYagAAAAECyOEaKNZmUKX9lgtxl1esr1tcxcRCDkXBp1L9fW3kFHJvPb1NCYhH3Ri93IWtZpZQ==", "64df194d-68c8-41c0-bee4-6e9677615c25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f3ed54b-6c06-4a22-b2e1-badd8e0d285b"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf14d602-7f65-475f-963f-5d50c33e95db", new DateTime(2025, 1, 19, 23, 33, 38, 990, DateTimeKind.Local).AddTicks(1630), "AQAAAAIAAYagAAAAEMDRTBTWKFyIne4Ere7sFwaB4mLRv6ariUHEBJfovTamtiQNcDbeV/0IIV1CGIaIBQ==", "b90bde60-16bd-41f6-b32a-950e3d53a1e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18dc8f2-defd-4233-9a37-8d12564e00bc"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90884f9a-22e9-4d98-be52-0bebc8b24b9e", new DateTime(2025, 1, 19, 23, 33, 39, 106, DateTimeKind.Local).AddTicks(2425), "AQAAAAIAAYagAAAAECt9O4D62aqx+yJMoO+j27c7GNR/7iJmte9Z9YRSMX4gS3lGAvB2PnVPPhOTWsleOw==", "22e897a1-0182-44b9-9b41-cd8d36e0685a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ead3165d-0386-43a9-9ef9-06b41b49afed", new DateTime(2025, 1, 19, 23, 33, 38, 586, DateTimeKind.Local).AddTicks(740), "AQAAAAIAAYagAAAAEPe6fuPcpO2P77+m0ug102Ecq4KwOMUhh+Bzg7bC+NuSCRDQNXAhpGKdaSDvTOJ2uA==", "ca5cd1a1-14bb-4714-b852-5be2deb49d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6def87b-c734-4a10-a0be-ced4a542d54c"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7b2bb80-aa23-45bd-81a0-10ff077e6b4e", new DateTime(2025, 1, 19, 23, 33, 39, 222, DateTimeKind.Local).AddTicks(5196), "AQAAAAIAAYagAAAAEC3P251J3qJa9ka9zK6KpcudHKsDATlSXvNJ6S1RnHwCam3DU392sd41MIpNTY2/eQ==", "42b32583-6c29-4d57-9cd8-9fed79e43037" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03ce06ea-9051-4e0a-b444-2d19cdebd94b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("64f6d36f-8f31-4850-b8ad-9f36f1e730ac"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91904860-0d46-479b-b423-e80e4d11207b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c12817dd-6b83-46e0-8020-54095e11ed5b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d78bf8de-9d79-4ba0-9b62-7252c9738fdb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0cbfc44-2fa5-4e8c-a6cc-e508b9f57842"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 570, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0b5253c9-4495-4948-946d-c2fdbce74476"),
                columns: new[] { "CreatedDate", "FoundedDate", "NumberOfEmployees" },
                values: new object[] { new DateTime(2025, 1, 19, 23, 33, 38, 571, DateTimeKind.Local).AddTicks(6556), new DateTime(2021, 10, 24, 11, 42, 21, 0, DateTimeKind.Unspecified), 574 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"),
                columns: new[] { "CreatedDate", "FoundedDate", "NumberOfEmployees" },
                values: new object[] { new DateTime(2025, 1, 19, 23, 33, 38, 571, DateTimeKind.Local).AddTicks(6440), new DateTime(1985, 4, 10, 0, 51, 29, 0, DateTimeKind.Unspecified), 622 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "/img/products/842614F7-D402-4324-9A58-40166F4D9BB7/EBE9E0F2-49E4-4D8B-B7C5-5A06AC25C220.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "/img/products/842614F7-D402-4324-9A58-40166F4D9BB7/7FB73879-9575-4B34-AC4B-550FE2A7A212.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "/img/products/C04595E2-2967-41EC-B7AB-D84D10C11CA0/2C2B225A-B9FC-411B-99E5-AB6088EAF2F4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 574, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 23, 33, 38, 574, DateTimeKind.Local).AddTicks(3049));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03ce06ea-9051-4e0a-b444-2d19cdebd94b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("64f6d36f-8f31-4850-b8ad-9f36f1e730ac"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91904860-0d46-479b-b423-e80e4d11207b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc969756-0930-4ee7-be16-a5ae1a83213c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c12817dd-6b83-46e0-8020-54095e11ed5b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d78bf8de-9d79-4ba0-9b62-7252c9738fdb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0cbfc44-2fa5-4e8c-a6cc-e508b9f57842"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 442, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0b5253c9-4495-4948-946d-c2fdbce74476"),
                columns: new[] { "CreatedDate", "FoundedDate", "NumberOfEmployees" },
                values: new object[] { new DateTime(2025, 1, 19, 4, 3, 2, 443, DateTimeKind.Local).AddTicks(1335), new DateTime(1901, 4, 21, 9, 23, 47, 0, DateTimeKind.Unspecified), 735 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("130ab18e-e4b8-4769-ac84-4bb8c4153f4c"),
                columns: new[] { "CreatedDate", "FoundedDate", "NumberOfEmployees" },
                values: new object[] { new DateTime(2025, 1, 19, 4, 3, 2, 443, DateTimeKind.Local).AddTicks(1204), new DateTime(1994, 7, 10, 17, 17, 35, 0, DateTimeKind.Unspecified), 489 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "img/products/P001/EBE9E0F2-49E4-4D8B-B7C5-5A06AC25C220.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "images/products/P001/7FB73879-9575-4B34-AC4B-550FE2A7A212.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "images/products/P002/2C2B225A-B9FC-411B-99E5-AB6088EAF2F4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("842614f7-d402-4324-9a58-40166f4d9bb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 445, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c04595e2-2967-41ec-b7ab-d84d10c11ca0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 4, 3, 2, 445, DateTimeKind.Local).AddTicks(1106));
        }
    }
}
