using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_DiemHS.Migrations
{
    /// <inheritdoc />
    public partial class hs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HocSinh_MonHoc_MaMon",
                table: "HocSinh");

            migrationBuilder.DropIndex(
                name: "IX_HocSinh_MaMon",
                table: "HocSinh");

            migrationBuilder.DropColumn(
                name: "MaMon",
                table: "HocSinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaMon",
                table: "HocSinh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_MaMon",
                table: "HocSinh",
                column: "MaMon");

            migrationBuilder.AddForeignKey(
                name: "FK_HocSinh_MonHoc_MaMon",
                table: "HocSinh",
                column: "MaMon",
                principalTable: "MonHoc",
                principalColumn: "MaMon",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
