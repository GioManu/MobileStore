using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufaturerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufaturerID);
                });

            migrationBuilder.CreateTable(
                name: "MobileProduct",
                columns: table => new
                {
                    MobileProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RAM = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    ManufacturerManufaturerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileProduct", x => x.MobileProductID);
                    table.ForeignKey(
                        name: "FK_MobileProduct_Manufacturer_ManufacturerManufaturerID",
                        column: x => x.ManufacturerManufaturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufaturerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_MobileProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "MobileProduct",
                        principalColumn: "MobileProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductID",
                table: "Image",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_MobileProduct_ManufacturerManufaturerID",
                table: "MobileProduct",
                column: "ManufacturerManufaturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "MobileProduct");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
