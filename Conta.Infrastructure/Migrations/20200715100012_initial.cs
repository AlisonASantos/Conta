using Microsoft.EntityFrameworkCore.Migrations;

namespace Conta.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "varchar(100)", nullable: false),
                    TitularConta = table.Column<string>(type: "varchar(100)", nullable: false),
                    SaldoConta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 400, nullable: false),
                    ContaCorrenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContaCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LancamentosPorConta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaCorrenteId = table.Column<int>(nullable: false),
                    ValorOperacao = table.Column<double>(nullable: false),
                    TipoLancamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosPorConta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosPorConta_ContaCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Lancamentos",
                columns: new[] { "Id", "ContaCorrenteId", "Descricao", "Nome" },
                values: new object[] { 1, null, "Débito em conta", "Débito" });

            migrationBuilder.InsertData(
                table: "Lancamentos",
                columns: new[] { "Id", "ContaCorrenteId", "Descricao", "Nome" },
                values: new object[] { 2, null, "Crédito em conta", "Crédito" });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosPorConta_ContaCorrenteId",
                table: "LancamentosPorConta",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "LancamentosPorConta");

            migrationBuilder.DropTable(
                name: "ContaCorrentes");
        }
    }
}
