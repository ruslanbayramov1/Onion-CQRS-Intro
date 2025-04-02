using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductColumFromRemovedToDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemovedAt",
                table: "Products",
                newName: "DeletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Products",
                newName: "RemovedAt");
        }
    }
}
