using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volunteering.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_SSN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Sec_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sec_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Sec_ID);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Opp_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opp_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opp_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opp_Form_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opp_Img_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opp_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opp_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sector_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Opp_ID);
                    table.ForeignKey(
                        name: "FK_Opportunities_Sectors_Sector_ID",
                        column: x => x.Sector_ID,
                        principalTable: "Sectors",
                        principalColumn: "Sec_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Volun_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volun_First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volun_Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volun_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volun_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oppor_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Volun_ID);
                    table.ForeignKey(
                        name: "FK_Volunteers_Opportunities_Oppor_ID",
                        column: x => x.Oppor_ID,
                        principalTable: "Opportunities",
                        principalColumn: "Opp_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Sector_ID",
                table: "Opportunities",
                column: "Sector_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_Oppor_ID",
                table: "Volunteers",
                column: "Oppor_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
