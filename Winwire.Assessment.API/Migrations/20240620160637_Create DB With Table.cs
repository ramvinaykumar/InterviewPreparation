using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Winwire.Assessment.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDBWithTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    ProjectVersion = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
