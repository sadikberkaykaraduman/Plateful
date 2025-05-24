using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE TRIGGER UpdateCashRegisters
ON Orders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalAmountToAdd DECIMAL(18,2);

    SELECT @TotalAmountToAdd = SUM(I.OrderTotalPrice)
    FROM inserted I
    INNER JOIN deleted D ON I.OrderId = D.OrderId
    WHERE I.OrderStatus = 0 AND D.OrderStatus <> I.OrderStatus;

    IF @TotalAmountToAdd IS NOT NULL
    BEGIN
        UPDATE CashRegisters
        SET CashRegisterAmount = CashRegisterAmount + @TotalAmountToAdd;
    END
END
");

            migrationBuilder.Sql(@"
CREATE TRIGGER IncreaseOrderTotalPrice
ON OrderDetails
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderId INT;
    DECLARE @OrderPrice DECIMAL;

    SELECT @OrderId = OrderDetailOrderId FROM inserted;
    SELECT @OrderPrice = OrderDetailTotalPrice FROM inserted;

    UPDATE Orders
    SET OrderTotalPrice = OrderTotalPrice + @OrderPrice
    WHERE OrderId = @OrderId;
END
");

            migrationBuilder.Sql(@"
CREATE TRIGGER DecreaseOrderTotalPrice
ON OrderDetails
AFTER DELETE, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderId INT;
    DECLARE @OrderPrice DECIMAL;

    SELECT @OrderId = OrderDetailOrderId FROM deleted;
    SELECT @OrderPrice = OrderDetailTotalPrice FROM deleted;

    UPDATE Orders
    SET OrderTotalPrice = OrderTotalPrice - @OrderPrice
    WHERE OrderId = @OrderId;
END
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
