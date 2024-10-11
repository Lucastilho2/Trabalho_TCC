using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCTrabalho3.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosItems_Carrinhos_CarrinhoId",
                table: "CarrinhosItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosItems_Cursos_CursosId",
                table: "CarrinhosItems");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhosItems",
                table: "CarrinhosItems");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhosItems_CarrinhoId",
                table: "CarrinhosItems");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhosItems_CursosId",
                table: "CarrinhosItems");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "CarrinhosItems");

            migrationBuilder.DropColumn(
                name: "CursosId",
                table: "CarrinhosItems");

            migrationBuilder.RenameTable(
                name: "CarrinhosItems",
                newName: "CarrinhoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoItems",
                table: "CarrinhoItems",
                column: "CarrinhoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_CursoId",
                table: "CarrinhoItems",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItems_Cursos_CursoId",
                table: "CarrinhoItems",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItems_Cursos_CursoId",
                table: "CarrinhoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoItems",
                table: "CarrinhoItems");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoItems_CursoId",
                table: "CarrinhoItems");

            migrationBuilder.RenameTable(
                name: "CarrinhoItems",
                newName: "CarrinhosItems");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "CarrinhosItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursosId",
                table: "CarrinhosItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhosItems",
                table: "CarrinhosItems",
                column: "CarrinhoItemId");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCustomizado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidosId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.CarrinhoId);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosItems_CarrinhoId",
                table: "CarrinhosItems",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosItems_CursosId",
                table: "CarrinhosItems",
                column: "CursosId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_PedidosId",
                table: "Carrinhos",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosItems_Carrinhos_CarrinhoId",
                table: "CarrinhosItems",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "CarrinhoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosItems_Cursos_CursosId",
                table: "CarrinhosItems",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
