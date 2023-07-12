using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Australia" });

            migrationBuilder.InsertData(
                table: "DistributionCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Roger's Printing Services" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "The Viz" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "CustomerId", "Nickname", "PostCode", "State", "StreetAddress" },
                values: new object[] { 1, "Belgrave", 1, null, "Home", "3160", "VIC", "19 Red Herring Place" });

            migrationBuilder.InsertData(
                table: "Distributions",
                columns: new[] { "Id", "CompanyId", "CountryId", "PublicationId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DefaultAddressId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "dan.richardson.gs@gmail.com", "Dan", "Richardson" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AddressId", "CustomerId", "EndDate", "PublicationId", "StartDate" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Distributions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DistributionCompanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
