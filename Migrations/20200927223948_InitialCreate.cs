using Microsoft.EntityFrameworkCore.Migrations;

namespace JBPOS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RegularPrice = table.Column<float>(nullable: false),
                    SalePrice = table.Column<float>(nullable: false),
                    NoSold = table.Column<double>(nullable: false),
                    ValueSold = table.Column<float>(nullable: false),
                    Inventory = table.Column<double>(nullable: false),
                    Cost = table.Column<float>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    Pack = table.Column<int>(nullable: false),
                    VendorStockNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
