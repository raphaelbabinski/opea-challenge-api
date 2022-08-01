using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opea.Registration.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanySizes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<Guid>(nullable: false, defaultValue: new Guid("1d7c458c-37e2-4ab2-84b9-7d47cf132d38")),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<Guid>(nullable: false, defaultValue: new Guid("d1a16e3c-9216-4006-ae7a-69863bbed5d4")),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    CompanySizeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_CompanySizes_CompanySizeId",
                        column: x => x.CompanySizeId,
                        principalTable: "CompanySizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanySizeId",
                table: "Clients",
                column: "CompanySizeId");

            migrationBuilder.Sql(@"INSERT INTO CompanySizes(Identifier, Name) values (newid(), 'Pequena')
                                   INSERT INTO CompanySizes(Identifier, Name) values (newid(), 'Média')
                                   INSERT INTO CompanySizes(Identifier, Name) values (newid(), 'Grande')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CompanySizes");
        }
    }
}
