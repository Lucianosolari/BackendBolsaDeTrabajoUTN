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
                    CompanyCUIT = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyPhone = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyEmail = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyWebPage = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyContactPerson = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyType = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyState = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyDocumentation = table.Column<string>(type: "TEXT", nullable: true),
                    File = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentNumber = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CareerStudent",
                columns: table => new
                {
                    CareersCareerId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerStudent", x => new { x.CareersCareerId, x.StudentsUserId });
                    table.ForeignKey(
                        name: "FK_CareerStudent_Careers_CareersCareerId",
                        column: x => x.CareersCareerId,
                        principalTable: "Careers",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareerStudent_Users_StudentsUserId",
                        column: x => x.StudentsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeStudent",
                columns: table => new
                {
                    KnowledgesKnowledgeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeStudent", x => new { x.KnowledgesKnowledgeId, x.StudentsUserId });
                    table.ForeignKey(
                        name: "FK_KnowledgeStudent_Knowledges_KnowledgesKnowledgeId",
                        column: x => x.KnowledgesKnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "KnowledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeStudent_Users_StudentsUserId",
                        column: x => x.StudentsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "OfferStudent",
                columns: table => new
                {
                    OffersOfferId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStudent", x => new { x.OffersOfferId, x.StudentsUserId });
                    table.ForeignKey(
                        name: "FK_OfferStudent_Offers_OffersOfferId",
                        column: x => x.OffersOfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferStudent_Users_StudentsUserId",
                        column: x => x.StudentsUserId,
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
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferSpecialty", "OfferTitle" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primera descripción", "hola", "Primera oferta" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferSpecialty", "OfferTitle" },
                values: new object[] { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segunda descripción", "hola", "Segunda oferta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyContactPerson", "CompanyDocumentation", "CompanyEmail", "CompanyName", "CompanyPhone", "CompanyState", "CompanyType", "CompanyWebPage", "Password", "UserName", "UserType" },
                values: new object[] { 1, "D 15", "20447575", "22", "asdasd", "email", "Primera empresa", 341367898, "ok", "srl", "web", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "Company 1", "Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyContactPerson", "CompanyDocumentation", "CompanyEmail", "CompanyName", "CompanyPhone", "CompanyState", "CompanyType", "CompanyWebPage", "Password", "UserName", "UserType" },
                values: new object[] { 2, "D 15", "20447575", "22", "asdasd", "email", "Segunda empresa", 341367899, "ok", "srl", "web", "3627909a29c31381a071ec27f7c9ca97726182aed29a7ddd2e54353322cfb30abb9e3a6df2ac2c20fe23436311d678564d0c8d305930575f60e2d3d048184d79", "Company 2", "Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DocumentNumber", "Email", "File", "Name", "Password", "Surname", "UserName", "UserType" },
                values: new object[] { 3, 44555666, "manuel@gmail.com", 0, "Manuel", "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87", "Ibarbia", "string", "Student" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DocumentNumber", "Email", "File", "Name", "Password", "Surname", "UserName", "UserType" },
                values: new object[] { 4, 33444555, "luciano@gmail.com", 0, "Luciano", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Solari", "lucianoS", "Student" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DocumentNumber", "Email", "File", "Name", "Password", "Surname", "UserName", "UserType" },
                values: new object[] { 5, 55666777, "santiago@gmail.com", 0, "Santiago", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Caso", "santiagoC", "Student" });

            migrationBuilder.CreateIndex(
                name: "IX_CareerStudent_StudentsUserId",
                table: "CareerStudent",
                column: "StudentsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeStudent_StudentsUserId",
                table: "KnowledgeStudent",
                column: "StudentsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CompanyId",
                table: "Offers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferStudent_StudentsUserId",
                table: "OfferStudent",
                column: "StudentsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerStudent");

            migrationBuilder.DropTable(
                name: "KnowledgeStudent");

            migrationBuilder.DropTable(
                name: "OfferStudent");

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
