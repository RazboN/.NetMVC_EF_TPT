using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetMVC_EF_TPT.Migrations
{
    public partial class TPT_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    orderId = table.Column<Guid>(nullable: false),
                    orderDate = table.Column<DateTime>(nullable: false),
                    orderedItem = table.Column<string>(nullable: true),
                    destAdress = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.orderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");
        }
    }
}
