using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Banking.Data.Context.Migrations
{
    public partial class AddUpdateDateDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
