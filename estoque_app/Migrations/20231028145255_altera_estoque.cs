using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque_app.Migrations
{
    /// <inheritdoc />
    public partial class altera_estoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoProduto",
                table: "Estoques");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoProduto",
                table: "Estoques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
