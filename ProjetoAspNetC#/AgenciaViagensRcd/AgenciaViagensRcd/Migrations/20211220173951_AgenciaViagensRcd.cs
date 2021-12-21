using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaViagensRcd.Migrations
{
    public partial class AgenciaViagensRcd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    IdDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlImagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.IdDestino);
                });

            migrationBuilder.CreateTable(
                name: "DestinoPromo",
                columns: table => new
                {
                    IdDestinoPromo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDestinoPromo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoUnitarioPromo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlImagemPromo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoPromo", x => x.IdDestinoPromo);
                });

            migrationBuilder.CreateTable(
                name: "Suporte",
                columns: table => new
                {
                    IdSuporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suporte", x => x.IdSuporte);
                    table.ForeignKey(
                        name: "FK_Suporte_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    DestinoIdDestino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Destino_DestinoIdDestino",
                        column: x => x.DestinoIdDestino,
                        principalTable: "Destino",
                        principalColumn: "IdDestino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPromo",
                columns: table => new
                {
                    IdPedidoPromo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    DestinoPromoIdDestinoPromo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPromo", x => x.IdPedidoPromo);
                    table.ForeignKey(
                        name: "FK_PedidoPromo_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoPromo_DestinoPromo_DestinoPromoIdDestinoPromo",
                        column: x => x.DestinoPromoIdDestinoPromo,
                        principalTable: "DestinoPromo",
                        principalColumn: "IdDestinoPromo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteIdCliente",
                table: "Pedido",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DestinoIdDestino",
                table: "Pedido",
                column: "DestinoIdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPromo_ClienteIdCliente",
                table: "PedidoPromo",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPromo_DestinoPromoIdDestinoPromo",
                table: "PedidoPromo",
                column: "DestinoPromoIdDestinoPromo");

            migrationBuilder.CreateIndex(
                name: "IX_Suporte_ClienteIdCliente",
                table: "Suporte",
                column: "ClienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PedidoPromo");

            migrationBuilder.DropTable(
                name: "Suporte");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "DestinoPromo");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
