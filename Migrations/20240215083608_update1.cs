using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Doctors_DocterIDId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Patients_PatientIDId",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "PatientIDId",
                table: "Consults",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DocterIDId",
                table: "Consults",
                newName: "DocterId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_PatientIDId",
                table: "Consults",
                newName: "IX_Consults_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_DocterIDId",
                table: "Consults",
                newName: "IX_Consults_DocterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Doctors_DocterId",
                table: "Consults",
                column: "DocterId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Patients_PatientId",
                table: "Consults",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Doctors_DocterId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Patients_PatientId",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Consults",
                newName: "PatientIDId");

            migrationBuilder.RenameColumn(
                name: "DocterId",
                table: "Consults",
                newName: "DocterIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_PatientId",
                table: "Consults",
                newName: "IX_Consults_PatientIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_DocterId",
                table: "Consults",
                newName: "IX_Consults_DocterIDId");

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
    }
}
