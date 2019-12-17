using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronico.Data.Migrations
{
    public partial class AddRegistroPonto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroPonto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraEntrada = table.Column<DateTime>(nullable: false),
                    HoraSaida = table.Column<DateTime>(nullable: false),
                    CargaHoraria = table.Column<TimeSpan>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroPonto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroPonto_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_EmpresaId",
                table: "RegistroPonto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_FuncionarioId",
                table: "RegistroPonto",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroPonto");
        }
    }
}
