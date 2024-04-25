using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoModalWeb.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoNumeroUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    FuncId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FuncDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FuncDataIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.FuncId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Functions");
        }
    }
}
