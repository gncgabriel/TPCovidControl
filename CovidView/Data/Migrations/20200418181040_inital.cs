using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidView.Data.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covid_Infos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Casos_Confirmados = table.Column<int>(nullable: true),
                    Mortes = table.Column<int>(nullable: true),
                    Recuperados = table.Column<int>(nullable: true),
                    pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid_Infos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Nome = table.Column<string>(nullable: false),
                    covid_info = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Nome);
                    table.ForeignKey(
                        name: "FK_Paises_Covid_Infos_covid_info",
                        column: x => x.covid_info,
                        principalTable: "Covid_Infos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paises_covid_info",
                table: "Paises",
                column: "covid_info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Covid_Infos");
        }
    }
}
