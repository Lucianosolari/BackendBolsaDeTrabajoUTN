using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    public partial class probando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    CareerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.CareerId);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    KnowledgeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.KnowledgeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
                    NameAdmin = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyCUIT = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyLine = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyLocation = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPhone = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyWebPage = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPersonalName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPersonalSurname = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPersonalJob = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPersonalPhone = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyRelationContact = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPendingConfirmation = table.Column<bool>(type: "INTEGER", nullable: true),
                    File = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    AltEmail = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentType = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    CUIL_CUIT = table.Column<int>(type: "INTEGER", nullable: true),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    CivilStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfferTitle = table.Column<string>(type: "TEXT", nullable: false),
                    OfferSpecialty = table.Column<string>(type: "TEXT", nullable: false),
                    OfferDescription = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Users_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCareer",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CareerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCareer", x => new { x.StudentId, x.CareerId });
                    table.ForeignKey(
                        name: "FK_StudentCareer_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCareer_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentKnowledge",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    KnowledgeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentKnowledge", x => new { x.UserId, x.KnowledgeId });
                    table.ForeignKey(
                        name: "FK_StudentKnowledge_Knowledges_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "KnowledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentKnowledge_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentOffer",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOffer", x => new { x.OfferId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOffer_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Careers",
                column: "CareerId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Careers",
                column: "CareerId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Knowledges",
                columns: new[] { "KnowledgeId", "Level", "Type" },
                values: new object[] { 1, "Advanced", "Programming" });

            migrationBuilder.InsertData(
                table: "Knowledges",
                columns: new[] { "KnowledgeId", "Level", "Type" },
                values: new object[] { 2, "Intermediate", "Design" });

            migrationBuilder.InsertData(
                table: "Knowledges",
                columns: new[] { "KnowledgeId", "Level", "Type" },
                values: new object[] { 3, "Beginner", "Marketing" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "NameAdmin", "Password", "UserEmail", "UserName", "UserType" },
                values: new object[] { 6, "AdminPepe", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "luciano3924@gmail.com", "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyLine", "CompanyLocation", "CompanyName", "CompanyPendingConfirmation", "CompanyPersonalJob", "CompanyPersonalName", "CompanyPersonalPhone", "CompanyPersonalSurname", "CompanyPhone", "CompanyPostalCode", "CompanyRelationContact", "CompanyWebPage", "Password", "UserEmail", "UserName", "UserType" },
                values: new object[] { 1, "D 15", "20447575", "Textil", "Rosario", "SRL", true, "Gerente", "Juan Carlos", 22, "Peralta", 341367898, "2000", "Vacio", "web", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "mail1@gmai.com", "Company 1", "Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyLine", "CompanyLocation", "CompanyName", "CompanyPendingConfirmation", "CompanyPersonalJob", "CompanyPersonalName", "CompanyPersonalPhone", "CompanyPersonalSurname", "CompanyPhone", "CompanyPostalCode", "CompanyRelationContact", "CompanyWebPage", "Password", "UserEmail", "UserName", "UserType" },
                values: new object[] { 2, "E 18", "20445556661", "Textil", "Rosario", "SRL", true, "Gerente", "Juan Esteban", 25, "Peralta", 341334455, "2000", "Vacio", "web2", "7e2feac95dcd7d1df803345e197369af4b156e4e7a95fcb2955bdbbb3a11afd8bb9d35931bf15511370b18143e38b01b903f55c5ecbded4af99934602fcdf38c", "mail2@gmai.com", "Company 2", "Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AltEmail", "Birth", "CUIL_CUIT", "CivilStatus", "DocumentNumber", "DocumentType", "File", "Name", "Password", "Sex", "Surname", "UserEmail", "UserName", "UserType" },
                values: new object[] { 3, "manuelAlt@gmail.com", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 231332, "Casado", 44555666, "DNI", 12345, "Manuel", "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87", "Masculino", "Ibarbia", "manuel@gmail.com", "string", "Student" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AltEmail", "Birth", "CUIL_CUIT", "CivilStatus", "DocumentNumber", "DocumentType", "File", "Name", "Password", "Sex", "Surname", "UserEmail", "UserName", "UserType" },
                values: new object[] { 4, "lucianoAlt@gmail.com", new DateTime(1800, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2313321, "Soltero", 33444555, "DNI", 12346, "Luciano", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Masculino", "Solari", "luciano@gmail.com", "lucianoS", "Student" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AltEmail", "Birth", "CUIL_CUIT", "CivilStatus", "DocumentNumber", "DocumentType", "File", "Name", "Password", "Sex", "Surname", "UserEmail", "UserName", "UserType" },
                values: new object[] { 5, "santiagoAlt@gmail.com", new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2313321, "Soltero", 55666777, "DNI", 12347, "Santiago", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Masculino", "Caso", "santiago@gmail.com", "santiagoC", "Student" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferSpecialty", "OfferTitle" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primera descripción", "hola", "Primera oferta" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferSpecialty", "OfferTitle" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segunda descripción", "hola", "Segunda oferta" });

            migrationBuilder.InsertData(
                table: "StudentCareer",
                columns: new[] { "CareerId", "StudentId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentCareer",
                columns: new[] { "CareerId", "StudentId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "StudentKnowledge",
                columns: new[] { "KnowledgeId", "UserId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "StudentKnowledge",
                columns: new[] { "KnowledgeId", "UserId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentOffer",
                columns: new[] { "OfferId", "StudentId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentOffer",
                columns: new[] { "OfferId", "StudentId" },
                values: new object[] { 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CompanyId",
                table: "Offers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCareer_CareerId",
                table: "StudentCareer",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentKnowledge_KnowledgeId",
                table: "StudentKnowledge",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOffer_StudentId",
                table: "StudentOffer",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCareer");

            migrationBuilder.DropTable(
                name: "StudentKnowledge");

            migrationBuilder.DropTable(
                name: "StudentOffer");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
