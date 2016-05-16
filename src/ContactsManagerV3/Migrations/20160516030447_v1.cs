using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ContactsManagerV3.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Associate", table: "Contact");
            migrationBuilder.DropColumn(name: "Colleague", table: "Contact");
            migrationBuilder.DropColumn(name: "Family", table: "Contact");
            migrationBuilder.DropColumn(name: "Friend", table: "Contact");
            migrationBuilder.DropTable("Group");
            migrationBuilder.AddColumn<bool>(
                name: "isAssociate",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "isColleague",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "isFamily",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "isFriend",
                table: "Contact",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "isAssociate", table: "Contact");
            migrationBuilder.DropColumn(name: "isColleague", table: "Contact");
            migrationBuilder.DropColumn(name: "isFamily", table: "Contact");
            migrationBuilder.DropColumn(name: "isFriend", table: "Contact");
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<bool>(
                name: "Associate",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Colleague",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Family",
                table: "Contact",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Friend",
                table: "Contact",
                nullable: false,
                defaultValue: false);
        }
    }
}
