using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KetNoi.Migrations
{
    /// <inheritdoc />
    public partial class InitFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SquareMeters = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelNumbers",
                columns: table => new
                {
                    Hotel_Number = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelNumbers", x => x.Hotel_Number);
                    table.ForeignKey(
                        name: "FK_HotelNumbers_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "SquareMeters", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "TP. Hồ Chí Minh, Việt Nam", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/464640824.jpg?k=2ce1467d833309a6d9e4f1e5d35ba87454a50bcf620cc5926b410aca8148c219&o=&hp=1", "La Vela Saigon Hotel", 2, 100.0, 20, null },
                    { 2, null, "TP. Hồ Chí Minh, Việt Nam", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/325222137.jpg?k=56c624212a1b3f9257f34cc3980bc256becdc6bd4483079fac54b5d42e1c7147&o=&hp=1", "La Vela Saigon Hotel", 2, 100.0, 20, null },
                    { 3, null, "TP. Hồ Chí Minh, Việt Nam", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/257933259.jpg?k=ce22ef5c93a25d9c1667f09f8c4caf2fea5c7d094433788b71a37dbb16d96c15&o=&hp=1", "La Vela Saigon Hotel", 2, 100.0, 20, null },
                    { 4, null, "TP. Hồ Chí Minh, Việt Nam", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/388865161.jpg?k=02afa7769a3ec4fb788fdcefac0ad814a36e43d2022b92b5e5e3114cb98040c7&o=&hp=1", "La Vela Saigon Hotel", 2, 100.0, 20, null }
                });

            migrationBuilder.InsertData(
                table: "HotelNumbers",
                columns: new[] { "Hotel_Number", "HotelId", "SpecialDetails" },
                values: new object[,]
                {
                    { 101, 1, null },
                    { 102, 1, null },
                    { 103, 1, null },
                    { 104, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_HotelId",
                table: "HotelNumbers",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelNumbers");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
