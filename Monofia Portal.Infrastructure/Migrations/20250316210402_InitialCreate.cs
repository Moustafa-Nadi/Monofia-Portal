using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monofia_Portal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prtl_News",
                columns: table => new
                {
                    News_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    News_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    News_img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prtl_News", x => x.News_Id);
                });

            migrationBuilder.CreateTable(
                name: "prtl_News_Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    News_Head = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News_Abbr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News_Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News_Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lang_Id = table.Column<int>(type: "int", nullable: false),
                    Img_alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prtl_News_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prtl_News_Translations_prtl_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "prtl_News",
                        principalColumn: "News_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prtl_News_Translations_NewsId",
                table: "prtl_News_Translations",
                column: "NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prtl_News_Translations");

            migrationBuilder.DropTable(
                name: "prtl_News");
        }
    }
}
