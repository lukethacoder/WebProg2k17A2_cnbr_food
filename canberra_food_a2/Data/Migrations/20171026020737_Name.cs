using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace canberra_food_a2.Data.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Rest_reviews",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rest_reviews",
                newName: "UserName");
        }
    }
}
