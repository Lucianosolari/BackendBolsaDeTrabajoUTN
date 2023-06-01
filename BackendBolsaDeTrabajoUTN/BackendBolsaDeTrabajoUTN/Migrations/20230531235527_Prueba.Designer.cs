﻿// <auto-generated />
using System;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    [DbContext(typeof(TPContext))]
    [Migration("20230531235527_Prueba")]
    partial class Prueba
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Career", b =>
                {
                    b.Property<int>("CareerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerId"), 1L, 1);

                    b.Property<string>("CareerAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CareerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CareerTotalSubjects")
                        .HasColumnType("int");

                    b.Property<string>("CareerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareerId");

                    b.ToTable("Careers");

                    b.HasData(
                        new
                        {
                            CareerId = 1,
                            CareerAbbreviation = "TUP",
                            CareerName = "Tecnicatura Universitaria en Programación",
                            CareerTotalSubjects = 20,
                            CareerType = "Programación"
                        },
                        new
                        {
                            CareerId = 2,
                            CareerAbbreviation = "TUHS",
                            CareerName = "Tecnicatura Universitaria en Higiene y Seguridad",
                            CareerTotalSubjects = 15,
                            CareerType = "Seguridad"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Knowledge", b =>
                {
                    b.Property<int>("KnowledgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KnowledgeId"), 1L, 1);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KnowledgeId");

                    b.ToTable("Knowledges");

                    b.HasData(
                        new
                        {
                            KnowledgeId = 1,
                            Level = "Advanced",
                            Type = "Programming"
                        },
                        new
                        {
                            KnowledgeId = 2,
                            Level = "Intermediate",
                            Type = "Design"
                        },
                        new
                        {
                            KnowledgeId = 3,
                            Level = "Beginner",
                            Type = "Marketing"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OfferDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferSpecialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            CompanyId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Conocimientos avanzados en SQL",
                            OfferSpecialty = "SQL",
                            OfferTitle = "Analista de datos"
                        },
                        new
                        {
                            OfferId = 2,
                            CompanyId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Conocimientos avanzados en entorno .NET",
                            OfferSpecialty = ".NET",
                            OfferTitle = "Desarrollador Backend"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentCareer", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CareerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CareerId");

                    b.HasIndex("CareerId");

                    b.ToTable("StudentCareer", (string)null);

                    b.HasData(
                        new
                        {
                            StudentId = 4,
                            CareerId = 1
                        },
                        new
                        {
                            StudentId = 5,
                            CareerId = 2
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentKnowledge", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("KnowledgeId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "KnowledgeId");

                    b.HasIndex("KnowledgeId");

                    b.ToTable("StudentKnowledge", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 4,
                            KnowledgeId = 1
                        },
                        new
                        {
                            UserId = 3,
                            KnowledgeId = 2
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentOffer", b =>
                {
                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("OfferId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentOffer", (string)null);

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            StudentId = 4
                        },
                        new
                        {
                            OfferId = 2,
                            StudentId = 5
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Admin", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("NameAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            UserId = 6,
                            Password = "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db",
                            UserEmail = "luciano3924@gmail.com",
                            UserName = "admin",
                            NameAdmin = "AdminPepe"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Company", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyCUIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompanyPendingConfirmation")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyPersonalJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPersonalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyPersonalPhone")
                        .HasColumnType("int");

                    b.Property<string>("CompanyPersonalSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyPhone")
                        .HasColumnType("int");

                    b.Property<string>("CompanyPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyRelationContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWebPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db",
                            UserEmail = "mail1@gmai.com",
                            UserName = "Company 1",
                            CompanyAddress = "D 15",
                            CompanyCUIT = "20447575",
                            CompanyLine = "Textil",
                            CompanyLocation = "Rosario",
                            CompanyName = "Microsoft",
                            CompanyPendingConfirmation = true,
                            CompanyPersonalJob = "Gerente",
                            CompanyPersonalName = "Juan Carlos",
                            CompanyPersonalPhone = 22,
                            CompanyPersonalSurname = "Peralta",
                            CompanyPhone = 341367898,
                            CompanyPostalCode = "2000",
                            CompanyRelationContact = "Vacio",
                            CompanyWebPage = "web"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "7e2feac95dcd7d1df803345e197369af4b156e4e7a95fcb2955bdbbb3a11afd8bb9d35931bf15511370b18143e38b01b903f55c5ecbded4af99934602fcdf38c",
                            UserEmail = "mail2@gmai.com",
                            UserName = "Company 2",
                            CompanyAddress = "E 18",
                            CompanyCUIT = "20445556661",
                            CompanyLine = "Textil",
                            CompanyLocation = "Rosario",
                            CompanyName = "Apple",
                            CompanyPendingConfirmation = true,
                            CompanyPersonalJob = "Gerente",
                            CompanyPersonalName = "Juan Esteban",
                            CompanyPersonalPhone = 25,
                            CompanyPersonalSurname = "Peralta",
                            CompanyPhone = 341334455,
                            CompanyPostalCode = "2000",
                            CompanyRelationContact = "Vacio",
                            CompanyWebPage = "web2"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Student", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("AltEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUIL_CUIT")
                        .HasColumnType("int");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyFloor")
                        .HasColumnType("int");

                    b.Property<string>("FamilyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyOtherPhone")
                        .HasColumnType("int");

                    b.Property<int>("FamilyPersonalPhone")
                        .HasColumnType("int");

                    b.Property<string>("FamilyProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyStreetLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyStreetNumber")
                        .HasColumnType("int");

                    b.Property<int>("File")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalFloor")
                        .HasColumnType("int");

                    b.Property<string>("PersonalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalOtherPhone")
                        .HasColumnType("int");

                    b.Property<int>("PersonalPersonalPhone")
                        .HasColumnType("int");

                    b.Property<string>("PersonalProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalStreetLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalStreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            UserId = 3,
                            Password = "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87",
                            UserEmail = "manuel@gmail.com",
                            UserName = "string",
                            AltEmail = "manuelAlt@gmail.com",
                            Birth = new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 231332,
                            CivilStatus = "Casado",
                            DocumentNumber = 44555666,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "4B",
                            FamilyFloor = 2,
                            FamilyLocation = "Ciudad Autónoma de Buenos Aires",
                            FamilyOtherPhone = 987654321,
                            FamilyPersonalPhone = 123456789,
                            FamilyProvince = "Buenos Aires",
                            FamilyStreet = "Calle Principal",
                            FamilyStreetLetter = "A",
                            FamilyStreetNumber = 123,
                            File = 12345,
                            Name = "Manuel",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 123456789,
                            PersonalPersonalPhone = 987654321,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            Sex = "Masculino",
                            Surname = "Ibarbia"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413",
                            UserEmail = "luciano@gmail.com",
                            UserName = "lucianoS",
                            AltEmail = "lucianoAlt@gmail.com",
                            Birth = new DateTime(1800, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 2313321,
                            CivilStatus = "Soltero",
                            DocumentNumber = 33444555,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "5B",
                            FamilyFloor = 22,
                            FamilyLocation = "Rosario",
                            FamilyOtherPhone = 987654321,
                            FamilyPersonalPhone = 123456789,
                            FamilyProvince = "Santa Fe",
                            FamilyStreet = "Calle asdasd",
                            FamilyStreetLetter = "AA",
                            FamilyStreetNumber = 12,
                            File = 12346,
                            Name = "Luciano",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 123456789,
                            PersonalPersonalPhone = 987654321,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            Sex = "Masculino",
                            Surname = "Solari"
                        },
                        new
                        {
                            UserId = 5,
                            Password = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413",
                            UserEmail = "santiago@gmail.com",
                            UserName = "santiagoC",
                            AltEmail = "santiagoAlt@gmail.com",
                            Birth = new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 2313321,
                            CivilStatus = "Soltero",
                            DocumentNumber = 55666777,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "5B",
                            FamilyFloor = 22,
                            FamilyLocation = "Rosario",
                            FamilyOtherPhone = 987654321,
                            FamilyPersonalPhone = 123456789,
                            FamilyProvince = "Santa Fe",
                            FamilyStreet = "Calle asdasd",
                            FamilyStreetLetter = "AA",
                            FamilyStreetNumber = 12,
                            File = 12347,
                            Name = "Santiago",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 123456789,
                            PersonalPersonalPhone = 987654321,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            Sex = "Masculino",
                            Surname = "Caso"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Offer", b =>
                {
                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Company", "Company")
                        .WithMany("AnnouncedOffers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentCareer", b =>
                {
                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Career", "Career")
                        .WithMany()
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Career");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentKnowledge", b =>
                {
                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Knowledge", "Knowledge")
                        .WithMany("StudentKnowledges")
                        .HasForeignKey("KnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Student", "Student")
                        .WithMany("StudentKnowledges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knowledge");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentOffer", b =>
                {
                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Offer", "Offer")
                        .WithMany("StudentOffers")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Student", "Student")
                        .WithMany("StudentOffers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Knowledge", b =>
                {
                    b.Navigation("StudentKnowledges");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Offer", b =>
                {
                    b.Navigation("StudentOffers");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Company", b =>
                {
                    b.Navigation("AnnouncedOffers");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Student", b =>
                {
                    b.Navigation("StudentKnowledges");

                    b.Navigation("StudentOffers");
                });
#pragma warning restore 612, 618
        }
    }
}