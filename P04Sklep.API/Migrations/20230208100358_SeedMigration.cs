using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P04Sklep.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAdjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAdjectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premium = table.Column<bool>(type: "bit", nullable: false),
                    MaterialCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MaterialCategories_MaterialCategoryId",
                        column: x => x.MaterialCategoryId,
                        principalTable: "MaterialCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_ProductAdjectives",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAdjectiveId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductAdjectives", x => new { x.ProductId, x.ProductAdjectiveId });
                    table.ForeignKey(
                        name: "FK_Product_ProductAdjectives_ProductAdjectives_ProductAdjectiveId",
                        column: x => x.ProductAdjectiveId,
                        principalTable: "ProductAdjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductAdjectives_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaterialCategories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Steel", "Steel" },
                    { 2, "Steel", "Steel" },
                    { 3, "Wooden", "Wooden" },
                    { 4, "Steel", "Steel" },
                    { 5, "Plastic", "Plastic" }
                });

            migrationBuilder.InsertData(
                table: "ProductAdjectives",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intelligent" },
                    { 2, "Practical" },
                    { 3, "Refined" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "ImageUrl", "MaterialCategoryId", "Premium", "Title" },
                values: new object[,]
                {
                    { 1, "orange", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://loremflickr.com/320/240?lock=563010547", 4, false, "Tasty Fresh Chair" },
                    { 2, "red", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://loremflickr.com/320/240?lock=1809588757", 4, false, "Generic Cotton Chair" },
                    { 3, "fuchsia", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://loremflickr.com/320/240?lock=769361000", 4, false, "Awesome Cotton Soap" },
                    { 4, "sky blue", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://loremflickr.com/320/240?lock=2003116535", 1, true, "Awesome Granite Chicken" },
                    { 5, "lavender", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://loremflickr.com/320/240?lock=589837018", 3, false, "Awesome Cotton Pizza" },
                    { 6, "azure", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://loremflickr.com/320/240?lock=887835025", 5, true, "Ergonomic Fresh Table" },
                    { 7, "azure", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://loremflickr.com/320/240?lock=1505479811", 1, true, "Rustic Concrete Bike" },
                    { 8, "black", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://loremflickr.com/320/240?lock=1927398316", 2, false, "Awesome Frozen Pants" },
                    { 9, "indigo", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://loremflickr.com/320/240?lock=281839784", 3, false, "Awesome Granite Pizza" },
                    { 10, "cyan", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://loremflickr.com/320/240?lock=864803724", 5, false, "Refined Steel Sausages" },
                    { 11, "turquoise", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://loremflickr.com/320/240?lock=1016588364", 1, true, "Unbranded Metal Table" },
                    { 12, "red", "The Football Is Good For Training And Recreational Purposes", "https://loremflickr.com/320/240?lock=155275142", 1, false, "Sleek Cotton Soap" },
                    { 13, "gold", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://loremflickr.com/320/240?lock=399048781", 3, false, "Gorgeous Concrete Shirt" },
                    { 14, "maroon", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://loremflickr.com/320/240?lock=994885392", 5, true, "Fantastic Rubber Mouse" },
                    { 15, "maroon", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://loremflickr.com/320/240?lock=1186284245", 3, true, "Intelligent Wooden Cheese" },
                    { 16, "cyan", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://loremflickr.com/320/240?lock=1891470460", 2, false, "Handmade Rubber Towels" },
                    { 17, "black", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://loremflickr.com/320/240?lock=1801587928", 3, false, "Awesome Metal Bacon" },
                    { 18, "pink", "The Football Is Good For Training And Recreational Purposes", "https://loremflickr.com/320/240?lock=277508801", 4, false, "Intelligent Steel Keyboard" },
                    { 19, "grey", "The Football Is Good For Training And Recreational Purposes", "https://loremflickr.com/320/240?lock=1220573565", 2, false, "Handmade Cotton Gloves" },
                    { 20, "olive", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://loremflickr.com/320/240?lock=1145472902", 2, false, "Small Steel Hat" },
                    { 21, "orchid", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://loremflickr.com/320/240?lock=29403447", 4, false, "Incredible Cotton Towels" },
                    { 22, "orange", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://loremflickr.com/320/240?lock=516429187", 4, false, "Sleek Concrete Table" },
                    { 23, "olive", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://loremflickr.com/320/240?lock=1385658432", 2, true, "Practical Fresh Keyboard" },
                    { 24, "orchid", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://loremflickr.com/320/240?lock=221020649", 3, false, "Tasty Steel Pizza" },
                    { 25, "blue", "The Football Is Good For Training And Recreational Purposes", "https://loremflickr.com/320/240?lock=35308201", 1, false, "Incredible Frozen Computer" },
                    { 26, "gold", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://loremflickr.com/320/240?lock=1062899049", 1, false, "Generic Wooden Mouse" },
                    { 27, "silver", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://loremflickr.com/320/240?lock=2145371975", 2, true, "Refined Cotton Chair" },
                    { 28, "ivory", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://loremflickr.com/320/240?lock=1193987125", 5, false, "Refined Rubber Hat" },
                    { 29, "black", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://loremflickr.com/320/240?lock=2097256891", 1, true, "Small Metal Soap" },
                    { 30, "orange", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://loremflickr.com/320/240?lock=1803682168", 5, false, "Licensed Concrete Salad" }
                });

            migrationBuilder.InsertData(
                table: "Product_ProductAdjectives",
                columns: new[] { "ProductAdjectiveId", "ProductId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 835m },
                    { 2, 1, 704m },
                    { 1, 2, 611m },
                    { 2, 2, 934m },
                    { 3, 3, 326m },
                    { 2, 4, 657m },
                    { 1, 5, 122m },
                    { 1, 6, 620m },
                    { 3, 6, 594m },
                    { 1, 7, 408m },
                    { 2, 8, 812m },
                    { 3, 9, 513m },
                    { 1, 10, 661m },
                    { 1, 11, 677m },
                    { 2, 11, 76m },
                    { 2, 12, 633m },
                    { 1, 13, 60m },
                    { 1, 14, 48m },
                    { 3, 14, 768m },
                    { 1, 15, 981m },
                    { 3, 15, 500m },
                    { 1, 17, 250m },
                    { 3, 17, 395m },
                    { 2, 18, 677m },
                    { 3, 18, 132m },
                    { 2, 19, 591m },
                    { 3, 19, 913m },
                    { 1, 20, 711m },
                    { 2, 20, 615m },
                    { 3, 20, 8m },
                    { 1, 21, 480m },
                    { 2, 21, 181m },
                    { 1, 22, 72m },
                    { 3, 23, 671m },
                    { 2, 24, 518m },
                    { 3, 24, 771m },
                    { 2, 25, 676m },
                    { 3, 25, 85m },
                    { 2, 26, 370m },
                    { 1, 27, 935m },
                    { 3, 27, 304m },
                    { 1, 28, 464m },
                    { 3, 28, 661m },
                    { 3, 30, 133m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAdjectives_ProductAdjectiveId",
                table: "Product_ProductAdjectives",
                column: "ProductAdjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaterialCategoryId",
                table: "Products",
                column: "MaterialCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_ProductAdjectives");

            migrationBuilder.DropTable(
                name: "ProductAdjectives");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MaterialCategories");
        }
    }
}
