using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boncu_Nicole_Beatrice_Proiect.Migrations
{
    public partial class FoodOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkID",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oferta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodOffer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    OfferID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOffer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodOffer_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOffer_Offer_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_DrinkID",
                table: "Food",
                column: "DrinkID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOffer_FoodID",
                table: "FoodOffer",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOffer_OfferID",
                table: "FoodOffer",
                column: "OfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Drink_DrinkID",
                table: "Food",
                column: "DrinkID",
                principalTable: "Drink",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Drink_DrinkID",
                table: "Food");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "FoodOffer");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Food_DrinkID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "DrinkID",
                table: "Food");
        }
    }
}
