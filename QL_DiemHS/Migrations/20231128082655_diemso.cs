using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_DiemHS.Migrations
{
    /// <inheritdoc />
    public partial class diemso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diem15p",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "Diem1t",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "DiemCk",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "DiemGk",
                table: "MonHoc");

            migrationBuilder.CreateTable(
                name: "DiemSo",
                columns: table => new
                {
                    MaMon = table.Column<int>(type: "int", nullable: false),
                    MaHS = table.Column<int>(type: "int", nullable: false),
                    Diem15p = table.Column<double>(type: "float", nullable: false),
                    Diem1t = table.Column<double>(type: "float", nullable: false),
                    DiemGk = table.Column<double>(type: "float", nullable: false),
                    DiemCk = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemSo", x => new { x.MaMon, x.MaHS });
                    table.ForeignKey(
                        name: "FK_DiemSo_HocSinh_MaHS",
                        column: x => x.MaHS,
                        principalTable: "HocSinh",
                        principalColumn: "MaHS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiemSo_MonHoc_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHoc",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiemSo_MaHS",
                table: "DiemSo",
                column: "MaHS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiemSo");

            migrationBuilder.AddColumn<double>(
                name: "Diem15p",
                table: "MonHoc",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Diem1t",
                table: "MonHoc",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiemCk",
                table: "MonHoc",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiemGk",
                table: "MonHoc",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
