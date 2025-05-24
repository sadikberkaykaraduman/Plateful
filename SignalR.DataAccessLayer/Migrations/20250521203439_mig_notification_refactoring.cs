using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_notification_refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NatificationType",
                table: "Notifications",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "NatificationStatus",
                table: "Notifications",
                newName: "NotificationStatus");

            migrationBuilder.RenameColumn(
                name: "NatificationDescription",
                table: "Notifications",
                newName: "NotificationDescription");

            migrationBuilder.RenameColumn(
                name: "NatificationDate",
                table: "Notifications",
                newName: "NotificationDate");

            migrationBuilder.RenameColumn(
                name: "NatificationId",
                table: "Notifications",
                newName: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "Notifications",
                newName: "NatificationType");

            migrationBuilder.RenameColumn(
                name: "NotificationStatus",
                table: "Notifications",
                newName: "NatificationStatus");

            migrationBuilder.RenameColumn(
                name: "NotificationDescription",
                table: "Notifications",
                newName: "NatificationDescription");

            migrationBuilder.RenameColumn(
                name: "NotificationDate",
                table: "Notifications",
                newName: "NatificationDate");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "NatificationId");
        }
    }
}
