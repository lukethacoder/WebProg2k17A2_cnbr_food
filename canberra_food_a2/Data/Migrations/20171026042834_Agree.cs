using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace canberra_food_a2.Data.Migrations
{
    public partial class Agree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agree",
                table: "Rest_reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disagree",
                table: "Rest_reviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agree",
                table: "Rest_reviews");

            migrationBuilder.DropColumn(
                name: "Disagree",
                table: "Rest_reviews");
        }
    }
}
