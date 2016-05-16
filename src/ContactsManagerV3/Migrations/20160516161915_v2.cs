using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ContactsManagerV3.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Contact",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Key", table: "Contact");
        }
    }
}
