using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BizCore.Migrations
{
    /// <inheritdoc />
    public partial class addedPropToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderTypes_OrderTypesOrderTypeId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderTypesOrderTypeId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderTypesOrderTypeId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "PictureUrl");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Fk_OrderType",
                table: "OrderItems",
                column: "Fk_OrderType");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderTypes_Fk_OrderType",
                table: "OrderItems",
                column: "Fk_OrderType",
                principalTable: "OrderTypes",
                principalColumn: "OrderTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderTypes_Fk_OrderType",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Fk_OrderType",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Products",
                newName: "Picture");

            migrationBuilder.AddColumn<int>(
                name: "OrderTypesOrderTypeId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderTypesOrderTypeId",
                table: "OrderItems",
                column: "OrderTypesOrderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderTypes_OrderTypesOrderTypeId",
                table: "OrderItems",
                column: "OrderTypesOrderTypeId",
                principalTable: "OrderTypes",
                principalColumn: "OrderTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
