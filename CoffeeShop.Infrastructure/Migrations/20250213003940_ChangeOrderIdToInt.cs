using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_Orders", "Orders");
            migrationBuilder.DropColumn("Id", "Orders");
            migrationBuilder
                .AddColumn<int>(name: "Id", table: "Orders", type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_Orders", "Orders", "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .AlterColumn<Guid>(
                    name: "Id",
                    table: "Orders",
                    type: "uniqueidentifier",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "int"
                )
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
