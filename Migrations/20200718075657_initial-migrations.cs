using Microsoft.EntityFrameworkCore.Migrations;

namespace OliveShop.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "CategoritoProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoritoProducts", x => new { x.CategoryId, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CategoritoProducts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoritoProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    QuantitiInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_items_Products_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Description", "ItemId", "ProductName" },
                values: new object[,]
                {
                    { 1, "mahsol", 1, "محصول شماره 1" },
                    { 2, "mahsol2", 2, "محصول شماره 2" },
                    { 3, "mahsol3", 3, "محصول شماره 3 " }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "گروه لباسهای ورزشی", "لباسهاس ورزشی" },
                    { 2, "گروه لوازم خانگی", "لوازم خانگی" }
                });

            migrationBuilder.InsertData(
                table: "CategoritoProducts",
                columns: new[] { "CategoryId", "ProductID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "Price", "QuantitiInStock" },
                values: new object[,]
                {
                    { 1, 5000m, 100 },
                    { 2, 3000m, 60 },
                    { 3, 4000m, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoritoProducts_ProductID",
                table: "CategoritoProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoritoProducts");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
