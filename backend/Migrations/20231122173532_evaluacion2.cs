using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class evaluacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://tse4.mm.bing.net/th?id=OIP.U9nqgn1NvjMPLOQjDMjs2gHaG6&pid=Api&P=0&h=180", "Papas fritas", 10990 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://tse3.mm.bing.net/th?id=OIP.oGTTlgElx79g810lUhKESQHaE7&pid=Api&P=0&h=180", "Ensalada", 19990 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://tse4.mm.bing.net/th?id=OIP.0sKeEeaj45a1ppQqQh_kxQHaHa&pid=Api&P=0&h=180", "Mani salado", 29990 },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://picsum.photos/200/300", "Product 4", 39990 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
