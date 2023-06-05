using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    CareerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerTotalSubjects = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.CareerId);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    KnowledgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.KnowledgeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<int>(type: "int", nullable: true),
                    CompanyWebPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPersonalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPersonalSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPersonalJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPersonalPhone = table.Column<int>(type: "int", nullable: true),
                    CompanyRelationContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPendingConfirmation = table.Column<bool>(type: "bit", nullable: true),
                    File = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    CUIL_CUIT = table.Column<int>(type: "int", nullable: true),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyStreetNumber = table.Column<int>(type: "int", nullable: true),
                    FamilyStreetLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyFloor = table.Column<int>(type: "int", nullable: true),
                    FamilyDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyPersonalPhone = table.Column<int>(type: "int", nullable: true),
                    FamilyOtherPhone = table.Column<int>(type: "int", nullable: true),
                    PersonalStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalStreetNumber = table.Column<int>(type: "int", nullable: true),
                    PersonalStreetLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalFloor = table.Column<int>(type: "int", nullable: true),
                    PersonalDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalPersonalPhone = table.Column<int>(type: "int", nullable: true),
                    PersonalOtherPhone = table.Column<int>(type: "int", nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedSubjects = table.Column<int>(type: "int", nullable: true),
                    SpecialtyPlan = table.Column<int>(type: "int", nullable: true),
                    StudyYear = table.Column<int>(type: "int", nullable: true),
                    Turn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageWithPostponement = table.Column<int>(type: "int", nullable: true),
                    AverageWithoutPostponement = table.Column<int>(type: "int", nullable: true),
                    CollegeDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CVFiles",
                columns: table => new
                {
                    CVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVFiles", x => x.CVId);
                    table.ForeignKey(
                        name: "FK_CVFiles_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
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
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CareerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCareer", x => new { x.StudentId, x.CareerId });
                    table.ForeignKey(
                        name: "FK_StudentCareer_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "CareerId");
                        
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    KnowledgeId = table.Column<int>(type: "int", nullable: false)
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
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOffer", x => new { x.OfferId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId");
                        
                    table.ForeignKey(
                        name: "FK_StudentOffer_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "CareerId", "CareerAbbreviation", "CareerName", "CareerTotalSubjects", "CareerType" },
                values: new object[,]
                {
                    { 1, "TUP", "Tecnicatura Universitaria en Programación", 20, "Programación" },
                    { 2, "TUHS", "Tecnicatura Universitaria en Higiene y Seguridad", 15, "Seguridad" }
                });

            migrationBuilder.InsertData(
                table: "Knowledges",
                columns: new[] { "KnowledgeId", "Level", "Type" },
                values: new object[,]
                {
                    { 1, "Advanced", "Programming" },
                    { 2, "Intermediate", "Design" },
                    { 3, "Beginner", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "NameAdmin", "Password", "UserEmail", "UserName", "UserType" },
                values: new object[] { 6, "AdminPepe", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "luciano3924@gmail.com", "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyLine", "CompanyLocation", "CompanyName", "CompanyPendingConfirmation", "CompanyPersonalJob", "CompanyPersonalName", "CompanyPersonalPhone", "CompanyPersonalSurname", "CompanyPhone", "CompanyPostalCode", "CompanyRelationContact", "CompanyWebPage", "Password", "UserEmail", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "D 15", "20447575", "Textil", "Rosario", "Microsoft", true, "Gerente", "Juan Carlos", 22, "Peralta", 341367898, "2000", "Vacio", "web", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "mail1@gmai.com", "Company 1", "Company" },
                    { 2, "E 18", "20445556661", "Textil", "Rosario", "Apple", true, "Gerente", "Juan Esteban", 25, "Peralta", 341334455, "2000", "Vacio", "web2", "7e2feac95dcd7d1df803345e197369af4b156e4e7a95fcb2955bdbbb3a11afd8bb9d35931bf15511370b18143e38b01b903f55c5ecbded4af99934602fcdf38c", "mail2@gmai.com", "Company 2", "Company" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AltEmail", "ApprovedSubjects", "AverageWithPostponement", "AverageWithoutPostponement", "Birth", "CUIL_CUIT", "CivilStatus", "CollegeDegree", "DocumentNumber", "DocumentType", "FamilyCountry", "FamilyDepartment", "FamilyFloor", "FamilyLocation", "FamilyOtherPhone", "FamilyPersonalPhone", "FamilyProvince", "FamilyStreet", "FamilyStreetLetter", "FamilyStreetNumber", "File", "Name", "Observations", "Password", "PersonalCountry", "PersonalDepartment", "PersonalFloor", "PersonalLocation", "PersonalOtherPhone", "PersonalPersonalPhone", "PersonalProvince", "PersonalStreet", "PersonalStreetLetter", "PersonalStreetNumber", "SecondaryDegree", "Sex", "Specialty", "SpecialtyPlan", "StudyYear", "Surname", "Turn", "UserEmail", "UserName", "UserType" },
                values: new object[,]
                {
                    { 3, "manuelAlt@gmail.com", 10, 6, 7, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 231332, "Casado", "Sistemas", 44555666, "DNI", "Argentina", "4B", 2, "Ciudad Autónoma de Buenos Aires", 987654321, 123456789, "Buenos Aires", "Calle Principal", "A", 123, 12345, "Manuel", "Fanatico de linux", "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, 2, "Ibarbia", "Tarde", "manuel@gmail.com", "string", "Student" },
                    { 4, "lucianoAlt@gmail.com", 10, 6, 7, new DateTime(1800, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2313321, "Soltero", "Sistemas", 33444555, "DNI", "Argentina", "5B", 22, "Rosario", 987654321, 123456789, "Santa Fe", "Calle asdasd", "AA", 12, 12346, "Luciano", "Fanatico de linux", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, 2, "Solari", "Tarde", "luciano@gmail.com", "lucianoS", "Student" },
                    { 5, "santiagoAlt@gmail.com", 10, 6, 7, new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2313321, "Soltero", "Sistemas", 55666777, "DNI", "Argentina", "5B", 22, "Rosario", 987654321, 123456789, "Santa Fe", "Calle asdasd", "AA", 12, 12347, "Santiago", "Fanatico de linux", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, 2, "Caso", "Tarde", "santiago@gmail.com", "santiagoC", "Student" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferSpecialty", "OfferTitle" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conocimientos avanzados en SQL", "SQL", "Analista de datos" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conocimientos avanzados en entorno .NET", ".NET", "Desarrollador Backend" }
                });

            migrationBuilder.InsertData(
                table: "StudentCareer",
                columns: new[] { "CareerId", "StudentId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "StudentKnowledge",
                columns: new[] { "KnowledgeId", "UserId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "StudentOffer",
                columns: new[] { "OfferId", "StudentId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentOffer",
                columns: new[] { "OfferId", "StudentId" },
                values: new object[] { 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_CVFiles_StudentId",
                table: "CVFiles",
                column: "StudentId");

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
                name: "CVFiles");

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
