using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Domain.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                },
                comment: "Типы документов");

            migrationBuilder.CreateTable(
                name: "FileEntities",
                columns: table => new
                {
                    FileEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LoadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntities", x => x.FileEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<short>(type: "smallint", nullable: false),
                    FileEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Child = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegnCode = table.Column<short>(type: "smallint", nullable: true),
                    DistCode = table.Column<short>(type: "smallint", nullable: true),
                    InsrNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_FileEntities_FileEntityId",
                        column: x => x.FileEntityId,
                        principalTable: "FileEntities",
                        principalColumn: "FileEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeId", "Name", "ShortName" },
                values: new object[,]
                {
                    { (short)1, "Акт о проведении проверки", "Акт" },
                    { (short)2, "Справка об оказании услуг", "Справка" },
                    { (short)3, "Документ о документе 1", "Документ 1" },
                    { (short)4, "Документ о документе 2", "Документ 2" },
                    { (short)5, "Документ о документе 3", "Документ 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileEntityId",
                table: "Documents",
                column: "FileEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayerDocument_RegNumber",
                table: "Documents",
                columns: new[] { "RegnCode", "DistCode", "InsrNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "FileEntities");
        }
    }
}
