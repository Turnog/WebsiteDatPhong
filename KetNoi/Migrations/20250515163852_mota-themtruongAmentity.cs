using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KetNoi.Migrations
{
    /// <inheritdoc />
    public partial class motathemtruongAmentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amentities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amentities",
                columns: new[] { "Id", "Description", "HotelId", "Name" },
                values: new object[,]
                {
                    { 1, "Bể bơi ngoài trời", 1, "Bể bơi" },
                    { 2, "Bể bơi trong nhà", 1, "Bể bơi" },
                    { 3, "Wifi 5G", 2, "Wifi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amentities_HotelId",
                table: "Amentities",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amentities");
        }
    }
}
