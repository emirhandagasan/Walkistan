using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walkistan.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationwithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthInKm = table.Column<int>(type: "int", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { 1103, "Adalar", "https://images.unsplash.com/photo-1518352753950-d0c7da80e7a8" },
                    { 1183, "Besiktas", "https://images.unsplash.com/photo-1589906528014-454c84ebaa5b" },
                    { 1185, "Beykoz", "https://images.unsplash.com/photo-1709458915635-4ba2e6076d6e" },
                    { 1186, "Beyoglu", "https://images.unsplash.com/photo-1635357558138-df7ae85a3f61" },
                    { 1421, "Kadikoy", "https://images.unsplash.com/photo-1689410763484-d7fd8c775e25" },
                    { 1708, "Uskudar", "https://images.unsplash.com/photo-1719954270201-4afb0efe559e" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { 1, "This coastal walk takes you along the unique Maiden's Tower", 1, 3, "Uskudar Coast Walk", 1708, "https://images.unsplash.com/photo-1709940748754-eb59888100af" },
                    { 2, "Explore the beautiful Caddebostan Shore of Kadikoy on this leisurely walk", 2, 5, "Caddebostan Walk", 1421, "https://images.unsplash.com/photo-1607856339700-5520108d5f7c" },
                    { 3, "A walk from Taksim to Besiktas. This walk includes many historical places like Galata Tower, Dolmabahce and more", 2, 8, "Istiklal Street", 1186, "https://images.unsplash.com/photo-1607856339700-5520108d5f7c" },
                    { 4, "We start this route, which is 7 kilometers and takes approximately 2 hours in total, excluding rest time, from Heybeliada Ferry Port. The route offers us a unique natural landscape track where blue and green mix. Heybeliada is such a beautiful place that when you complete this route, you are not only satisfied in terms of sports. The route also brings you many points of interest that you can visit.", 2, 7, "Heybeliada", 1103, "https://images.unsplash.com/photo-1721229902006-ab891d8dae87" },
                    { 5, "A 10 km walk from the Ferry Port of Besiktas to Bebek.", 2, 10, "Besiktas to Bebek", 1183, "https://images.unsplash.com/photo-1717150982298-1df8a5c0f342" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
