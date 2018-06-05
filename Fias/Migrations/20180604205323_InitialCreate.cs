using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fias.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressObjects",
                columns: table => new
                {
                    AOID = table.Column<Guid>(nullable: false),
                    AOGUID = table.Column<string>(nullable: true),
                    FORMALNAME = table.Column<string>(nullable: true),
                    REGIONCODE = table.Column<string>(nullable: true),
                    AUTOCODE = table.Column<string>(nullable: true),
                    AREACODE = table.Column<string>(nullable: true),
                    CITYCODE = table.Column<string>(nullable: true),
                    CTARCODE = table.Column<string>(nullable: true),
                    PLACECODE = table.Column<string>(nullable: true),
                    PLANCODE = table.Column<string>(nullable: true),
                    STREETCODE = table.Column<string>(nullable: true),
                    OFFNAME = table.Column<string>(nullable: true),
                    POSTALCODE = table.Column<string>(nullable: true),
                    IFNSFL = table.Column<string>(nullable: true),
                    TERRIFNSFL = table.Column<string>(nullable: true),
                    IFNSUL = table.Column<string>(nullable: true),
                    TERRIFNSUL = table.Column<string>(nullable: true),
                    OKATO = table.Column<string>(nullable: true),
                    OKTMO = table.Column<string>(nullable: true),
                    UPDATEDATE = table.Column<DateTime>(nullable: true),
                    SHORTNAME = table.Column<string>(nullable: true),
                    AOLEVEL = table.Column<int>(nullable: true),
                    PARENTGUID = table.Column<string>(nullable: true),
                    CODE = table.Column<string>(nullable: true),
                    PLAINCODE = table.Column<string>(nullable: true),
                    ACTSTATUS = table.Column<int>(nullable: true),
                    CENTSTATUS = table.Column<int>(nullable: true),
                    OPERSTATUS = table.Column<int>(nullable: true),
                    CURRSTATUS = table.Column<int>(nullable: true),
                    STARTDATE = table.Column<DateTime>(nullable: true),
                    ENDDATE = table.Column<DateTime>(nullable: true),
                    LIVESTATUS = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressObjects", x => x.AOID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressObjects");
        }
    }
}
