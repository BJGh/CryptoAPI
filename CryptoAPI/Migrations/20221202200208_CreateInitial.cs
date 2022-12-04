using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cryptos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cryptoAmount = table.Column<double>(type: "float", nullable: false),
                    currencyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    client = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cryptos");
        }
    }
}
