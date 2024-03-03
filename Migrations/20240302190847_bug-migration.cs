using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastDesafio.Migrations
{
    /// <inheritdoc />
    public partial class bugmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CollaboratorsId",
                table: "DbRecord",
                newName: "CollaboratorIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CollaboratorIds",
                table: "DbRecord",
                newName: "CollaboratorsId");
        }
    }
}
