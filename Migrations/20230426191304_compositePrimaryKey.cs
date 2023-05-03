using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class compositePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment");

            migrationBuilder.DropIndex(
                name: "IX_enrollment_StudentId",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "enrollment");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "enrollment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "enrollment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment",
                columns: new[] { "StudentId", "SubjectId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "enrollment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "enrollment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_StudentId",
                table: "enrollment",
                column: "StudentId");
        }
    }
}
