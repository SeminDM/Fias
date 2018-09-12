using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fias.Migrations
{
    public partial class ParentGuidAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ParentGUID",
                table: "AddressObjects",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ParentGUID",
                table: "AddressObjects",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
