using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Banking.Data.Context.Migrations
{
    public partial class AddUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Accounts");
        }
    }
}
