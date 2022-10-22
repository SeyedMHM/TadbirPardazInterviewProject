using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TadbirPardazProject.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountPercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CustomerName", "Description", "IssuedDate" },
                values: new object[] { 1, "سید محمد حسین موسوی", "لطفا صبح تحویل داده شود", new DateTime(2022, 10, 18, 17, 21, 5, 894, DateTimeKind.Local).AddTicks(3614) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, false, 15000000m, "جارو برقی" },
                    { 2, false, 100000m, "پفک نمکی" },
                    { 3, false, 3000000m, "کیبورد" },
                    { 4, false, 200000m, "شیر پرچرب" },
                    { 5, false, 85000000m, "گوشی شائومی redmi note 7" },
                    { 6, false, 50000000m, "هارد اکسترنال 1 گیگ Samsung" },
                    { 7, false, 4000000m, "هندزفری بلوتوثی" },
                    { 8, false, 1200000m, "برنچ هاشمی" },
                    { 9, false, 300000m, "جوراب" },
                    { 10, false, 5000000m, "شلوار لی" },
                    { 11, false, 3000000m, "ماگ حرارتی" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DiscountPercent", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 1, (byte)10, 1, 1, (byte)1 });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DiscountPercent", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 2, (byte)0, 1, 2, (byte)5 });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DiscountPercent", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 3, (byte)5, 1, 3, (byte)2 });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
