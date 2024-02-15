using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Doctors_DoctorId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Patients_PatientId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_DoctorId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_PatientId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "PatienID",
                table: "Consults",
                newName: "PatientIDId");

            migrationBuilder.RenameColumn(
                name: "DocterID",
                table: "Consults",
                newName: "DocterIDId");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Consults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_DocterIDId",
                table: "Consults",
                column: "DocterIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_PatientIDId",
                table: "Consults",
                column: "PatientIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Doctors_DocterIDId",
                table: "Consults",
                column: "DocterIDId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Patients_PatientIDId",
                table: "Consults",
                column: "PatientIDId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Doctors_DocterIDId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Patients_PatientIDId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_DocterIDId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_PatientIDId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "PatientIDId",
                table: "Consults",
                newName: "PatienID");

            migrationBuilder.RenameColumn(
                name: "DocterIDId",
                table: "Consults",
                newName: "DocterID");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Consults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Consults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consults_DoctorId",
                table: "Consults",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_PatientId",
                table: "Consults",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Doctors_DoctorId",
                table: "Consults",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Patients_PatientId",
                table: "Consults",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
