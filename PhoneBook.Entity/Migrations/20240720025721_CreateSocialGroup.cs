using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Entity.Migrations
{
    /// <inheritdoc />
    public partial class CreateSocialGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocialGroupId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SocialGroup",
                columns: table => new
                {
                    SocialGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialGroup", x => x.SocialGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhoneNumber",
                table: "Contacts",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SocialGroupId",
                table: "Contacts",
                column: "SocialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialGroup_Name",
                table: "SocialGroup",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SocialGroup_SocialGroupId",
                table: "Contacts",
                column: "SocialGroupId",
                principalTable: "SocialGroup",
                principalColumn: "SocialGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SocialGroup_SocialGroupId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "SocialGroup");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PhoneNumber",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SocialGroupId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SocialGroupId",
                table: "Contacts");
        }
    }
}
