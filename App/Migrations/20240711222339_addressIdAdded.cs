﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class addressIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
              name: "AddressId",
              table: "AspNetUsers",
              type: "int",
              nullable: true);


            migrationBuilder.CreateIndex(
               name: "IX_AspNetUsers_AddressId",
               table: "AspNetUsers",
               column: "AddressId");

            migrationBuilder.AddForeignKey(
    name: "FK_AspNetUsers_Addresses_AddressId",
    table: "AspNetUsers",
    column: "AddressId",
    principalTable: "Addresses",
    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
  name: "IX_AspNetUsers_AddressId",
  table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
    name: "FK_AspNetUsers_Addresses_AddressId",
    table: "AspNetUsers");

            migrationBuilder.DropColumn(
             name: "AddressId",
             table: "AspNetUsers");

        }
    }
}
