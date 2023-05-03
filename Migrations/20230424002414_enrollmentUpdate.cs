using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class enrollmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_student_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_subject_SubjectId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_SubjectId",
                table: "enrollment",
                newName: "IX_enrollment_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId",
                table: "enrollment",
                newName: "IX_enrollment_StudentId");

            migrationBuilder.AddColumn<double>(
                name: "FinalExam",
                table: "enrollment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FinalGrade",
                table: "enrollment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MidtermExam",
                table: "enrollment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Practical",
                table: "enrollment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_student_StudentId",
                table: "enrollment",
                column: "StudentId",
                principalTable: "student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_subject_SubjectId",
                table: "enrollment",
                column: "SubjectId",
                principalTable: "subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_student_StudentId",
                table: "enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_subject_SubjectId",
                table: "enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "FinalExam",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "FinalGrade",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "MidtermExam",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Practical",
                table: "enrollment");

            migrationBuilder.RenameTable(
                name: "enrollment",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_SubjectId",
                table: "Enrollment",
                newName: "IX_Enrollment_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_StudentId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Enrollment",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_student_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_subject_SubjectId",
                table: "Enrollment",
                column: "SubjectId",
                principalTable: "subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
