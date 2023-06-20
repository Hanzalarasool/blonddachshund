using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deaneverhart.Data.Migrations
{
    public partial class CreateResumeExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeExperience",
                columns: table => new
                {
                    ResumeExperienceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: false),
                    ExperienceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperience", x => x.ResumeExperienceID);
                    table.ForeignKey(
                        name: "FK_ResumeExperience_Experience_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeExperience_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperience_ExperienceID",
                table: "ResumeExperience",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperience_ResumeID",
                table: "ResumeExperience",
                column: "ResumeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeExperience");
        }
    }
}
