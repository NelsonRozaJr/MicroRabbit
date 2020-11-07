using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Transfer.Data.Context.Migrations
{
    public partial class AddCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransferLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransferLogs");
        }
    }
}
