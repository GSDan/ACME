using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class secondSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "United Kingdom" });

            migrationBuilder.UpdateData(
                table: "DistributionCompanies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImplementingClass", "Name" },
                values: new object[] { "AusPost", "AusPost" });

            migrationBuilder.InsertData(
                table: "DistributionCompanies",
                columns: new[] { "Id", "ImplementingClass", "Name" },
                values: new object[] { 2, "RoyalMail", "RoyalMail" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "CustomerId", "Nickname", "PostCode", "State", "StreetAddress" },
                values: new object[] { 2, "London", 2, null, "Away", "SW1A 1AA", "England", "Buckingham Palace" });

            migrationBuilder.InsertData(
                table: "Distributions",
                columns: new[] { "Id", "CompanyId", "CountryId", "PublicationId" },
                values: new object[] { 2, 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AddressId", "CustomerId", "EndDate", "PublicationId", "StartDate" },
                values: new object[] { 2, 2, 1, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Distributions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DistributionCompanies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "DistributionCompanies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImplementingClass", "Name" },
                values: new object[] { "RogerMail", "Roger's Printing Services" });
        }
    }
}
