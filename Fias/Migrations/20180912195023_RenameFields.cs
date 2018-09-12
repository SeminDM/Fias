using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fias.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AOGUID",
                table: "AddressObjects");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "AddressObjects",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "STREETCODE",
                table: "AddressObjects",
                newName: "StreetCode");

            migrationBuilder.RenameColumn(
                name: "STARTDATE",
                table: "AddressObjects",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "SHORTNAME",
                table: "AddressObjects",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "REGIONCODE",
                table: "AddressObjects",
                newName: "RegionCode");

            migrationBuilder.RenameColumn(
                name: "POSTALCODE",
                table: "AddressObjects",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "PLANCODE",
                table: "AddressObjects",
                newName: "PlanCode");

            migrationBuilder.RenameColumn(
                name: "PLAINCODE",
                table: "AddressObjects",
                newName: "PlainCode");

            migrationBuilder.RenameColumn(
                name: "PLACECODE",
                table: "AddressObjects",
                newName: "PlaceCode");

            migrationBuilder.RenameColumn(
                name: "PARENTGUID",
                table: "AddressObjects",
                newName: "ParentGUID");

            migrationBuilder.RenameColumn(
                name: "OPERSTATUS",
                table: "AddressObjects",
                newName: "OperStatus");

            migrationBuilder.RenameColumn(
                name: "LIVESTATUS",
                table: "AddressObjects",
                newName: "LiveStatus");

            migrationBuilder.RenameColumn(
                name: "FORMALNAME",
                table: "AddressObjects",
                newName: "FormalName");

            migrationBuilder.RenameColumn(
                name: "ENDDATE",
                table: "AddressObjects",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "CURRSTATUS",
                table: "AddressObjects",
                newName: "CurrStatus");

            migrationBuilder.RenameColumn(
                name: "CTARCODE",
                table: "AddressObjects",
                newName: "CtarCode");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "AddressObjects",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "CITYCODE",
                table: "AddressObjects",
                newName: "CityCode");

            migrationBuilder.RenameColumn(
                name: "CENTSTATUS",
                table: "AddressObjects",
                newName: "CentStatus");

            migrationBuilder.RenameColumn(
                name: "AUTOCODE",
                table: "AddressObjects",
                newName: "AutoCode");

            migrationBuilder.RenameColumn(
                name: "AREACODE",
                table: "AddressObjects",
                newName: "AreaCode");

            migrationBuilder.RenameColumn(
                name: "OFFNAME",
                table: "AddressObjects",
                newName: "OfficialName");

            migrationBuilder.RenameColumn(
                name: "AOLEVEL",
                table: "AddressObjects",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "ACTSTATUS",
                table: "AddressObjects",
                newName: "ActualStatus");

            migrationBuilder.RenameColumn(
                name: "AOID",
                table: "AddressObjects",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentGUID",
                table: "AddressObjects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GUID",
                table: "AddressObjects",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GUID",
                table: "AddressObjects");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "AddressObjects",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "StreetCode",
                table: "AddressObjects",
                newName: "STREETCODE");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "AddressObjects",
                newName: "STARTDATE");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "AddressObjects",
                newName: "SHORTNAME");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "AddressObjects",
                newName: "REGIONCODE");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AddressObjects",
                newName: "POSTALCODE");

            migrationBuilder.RenameColumn(
                name: "PlanCode",
                table: "AddressObjects",
                newName: "PLANCODE");

            migrationBuilder.RenameColumn(
                name: "PlainCode",
                table: "AddressObjects",
                newName: "PLAINCODE");

            migrationBuilder.RenameColumn(
                name: "PlaceCode",
                table: "AddressObjects",
                newName: "PLACECODE");

            migrationBuilder.RenameColumn(
                name: "ParentGUID",
                table: "AddressObjects",
                newName: "PARENTGUID");

            migrationBuilder.RenameColumn(
                name: "OperStatus",
                table: "AddressObjects",
                newName: "OPERSTATUS");

            migrationBuilder.RenameColumn(
                name: "LiveStatus",
                table: "AddressObjects",
                newName: "LIVESTATUS");

            migrationBuilder.RenameColumn(
                name: "FormalName",
                table: "AddressObjects",
                newName: "FORMALNAME");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "AddressObjects",
                newName: "ENDDATE");

            migrationBuilder.RenameColumn(
                name: "CurrStatus",
                table: "AddressObjects",
                newName: "CURRSTATUS");

            migrationBuilder.RenameColumn(
                name: "CtarCode",
                table: "AddressObjects",
                newName: "CTARCODE");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AddressObjects",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "AddressObjects",
                newName: "CITYCODE");

            migrationBuilder.RenameColumn(
                name: "CentStatus",
                table: "AddressObjects",
                newName: "CENTSTATUS");

            migrationBuilder.RenameColumn(
                name: "AutoCode",
                table: "AddressObjects",
                newName: "AUTOCODE");

            migrationBuilder.RenameColumn(
                name: "AreaCode",
                table: "AddressObjects",
                newName: "AREACODE");

            migrationBuilder.RenameColumn(
                name: "OfficialName",
                table: "AddressObjects",
                newName: "OFFNAME");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "AddressObjects",
                newName: "AOLEVEL");

            migrationBuilder.RenameColumn(
                name: "ActualStatus",
                table: "AddressObjects",
                newName: "ACTSTATUS");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AddressObjects",
                newName: "AOID");

            migrationBuilder.AlterColumn<string>(
                name: "PARENTGUID",
                table: "AddressObjects",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "AOGUID",
                table: "AddressObjects",
                nullable: true);
        }
    }
}
