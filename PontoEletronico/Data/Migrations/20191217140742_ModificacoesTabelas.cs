using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronico.Data.Migrations
{
    public partial class ModificacoesTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Empresa_EmpresaId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPonto_Empresa_EmpresaId",
                table: "RegistroPonto");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPonto_Funcionario_FuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPonto_EmpresaId",
                table: "RegistroPonto");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPonto_FuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_EmpresaId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "CargaHoraria",
                table: "RegistroPonto");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "RegistroPonto");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Funcionario");

            migrationBuilder.AddColumn<int>(
                name: "DadosContratacaoFuncionarioId",
                table: "RegistroPonto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DadosContratacaoFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    CargaHoraria = table.Column<TimeSpan>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosContratacaoFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosContratacaoFuncionarios_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DadosContratacaoFuncionarios_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_DadosContratacaoFuncionarioId",
                table: "RegistroPonto",
                column: "DadosContratacaoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosContratacaoFuncionarios_EmpresaId",
                table: "DadosContratacaoFuncionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosContratacaoFuncionarios_FuncionarioId",
                table: "DadosContratacaoFuncionarios",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPonto_DadosContratacaoFuncionarios_DadosContratacaoFuncionarioId",
                table: "RegistroPonto",
                column: "DadosContratacaoFuncionarioId",
                principalTable: "DadosContratacaoFuncionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPonto_DadosContratacaoFuncionarios_DadosContratacaoFuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.DropTable(
                name: "DadosContratacaoFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPonto_DadosContratacaoFuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.DropColumn(
                name: "DadosContratacaoFuncionarioId",
                table: "RegistroPonto");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CargaHoraria",
                table: "RegistroPonto",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "RegistroPonto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "RegistroPonto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_EmpresaId",
                table: "RegistroPonto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_FuncionarioId",
                table: "RegistroPonto",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EmpresaId",
                table: "Funcionario",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Empresa_EmpresaId",
                table: "Funcionario",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPonto_Empresa_EmpresaId",
                table: "RegistroPonto",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPonto_Funcionario_FuncionarioId",
                table: "RegistroPonto",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
