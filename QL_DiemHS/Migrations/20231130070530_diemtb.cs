using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_DiemHS.Migrations
{
    /// <inheritdoc />
    public partial class diemtb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiemTrungBinh",
                table: "DiemSo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiemTrungBinh",
                table: "DiemSo");
        }
    }
}
