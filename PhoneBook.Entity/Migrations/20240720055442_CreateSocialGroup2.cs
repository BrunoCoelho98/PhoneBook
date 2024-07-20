using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Entity.Migrations
{
    /// <inheritdoc />
    public partial class CreateSocialGroup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SocialGroup_SocialGroupId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialGroup",
                table: "SocialGroup");

            migrationBuilder.RenameTable(
                name: "SocialGroup",
                newName: "SocialGroups");

            migrationBuilder.RenameIndex(
                name: "IX_SocialGroup_Name",
                table: "SocialGroups",
                newName: "IX_SocialGroups_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialGroups",
                table: "SocialGroups",
                column: "SocialGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SocialGroups_SocialGroupId",
                table: "Contacts",
                column: "SocialGroupId",
                principalTable: "SocialGroups",
                principalColumn: "SocialGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SocialGroups_SocialGroupId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialGroups",
                table: "SocialGroups");

            migrationBuilder.RenameTable(
                name: "SocialGroups",
                newName: "SocialGroup");

            migrationBuilder.RenameIndex(
                name: "IX_SocialGroups_Name",
                table: "SocialGroup",
                newName: "IX_SocialGroup_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialGroup",
                table: "SocialGroup",
                column: "SocialGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SocialGroup_SocialGroupId",
                table: "Contacts",
                column: "SocialGroupId",
                principalTable: "SocialGroup",
                principalColumn: "SocialGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
