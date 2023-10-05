using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class bancovainafe : Migration
    {//teste
        /// <inheritdoc /> 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEventos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorIngresso = table.Column<float>(type: "real", nullable: false),
                    LocalEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdLimiteIngresso = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEventos);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RA = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CompradorEventos",
                columns: table => new
                {
                    CompradoresUserId = table.Column<int>(type: "int", nullable: false),
                    EventosIdEventos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompradorEventos", x => new { x.CompradoresUserId, x.EventosIdEventos });
                    table.ForeignKey(
                        name: "FK_CompradorEventos_Eventos_EventosIdEventos",
                        column: x => x.EventosIdEventos,
                        principalTable: "Eventos",
                        principalColumn: "IdEventos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompradorEventos_Users_CompradoresUserId",
                        column: x => x.CompradoresUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompradorUserId = table.Column<int>(type: "int", nullable: false),
                    EventosIdEventos = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdIngresso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Venda_Eventos_EventosIdEventos",
                        column: x => x.EventosIdEventos,
                        principalTable: "Eventos",
                        principalColumn: "IdEventos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Users_CompradorUserId",
                        column: x => x.CompradorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompradorEventos_EventosIdEventos",
                table: "CompradorEventos",
                column: "EventosIdEventos");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CompradorUserId",
                table: "Venda",
                column: "CompradorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_EventosIdEventos",
                table: "Venda",
                column: "EventosIdEventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompradorEventos");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
