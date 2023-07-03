﻿// <auto-generated />
using System;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    [DbContext(typeof(TPContext))]
    partial class TPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.CVFile", b =>
                {
                    b.Property<int>("CVId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CVIsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CVPendingConfirmation")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CVId");

                    b.HasIndex("StudentId");

                    b.ToTable("CVFiles");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Career", b =>
                {
                    b.Property<int>("CareerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CareerAbbreviation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CareerIsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CareerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CareerTotalSubjects")
                        .HasColumnType("int");

                    b.Property<string>("CareerType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CareerId");

                    b.ToTable("Careers");

                    b.HasData(
                        new
                        {
                            CareerId = 1,
                            CareerAbbreviation = "TUP",
                            CareerIsActive = true,
                            CareerName = "Tecnicatura Universitaria en Programación",
                            CareerTotalSubjects = 20,
                            CareerType = "Programación"
                        },
                        new
                        {
                            CareerId = 2,
                            CareerAbbreviation = "TUHS",
                            CareerIsActive = true,
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

                    b.Property<bool>("KnowledgeIsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KnowledgeId");

                    b.ToTable("Knowledges");

                    b.HasData(
                        new
                        {
                            KnowledgeId = 1,
                            KnowledgeIsActive = true,
                            Level = "Alto",
                            Type = "Programación"
                        },
                        new
                        {
                            KnowledgeId = 2,
                            KnowledgeIsActive = true,
                            Level = "Medio",
                            Type = "Diseño"
                        },
                        new
                        {
                            KnowledgeId = 3,
                            KnowledgeIsActive = true,
                            Level = "Bajo",
                            Type = "Marketing"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OfferDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("OfferIsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OfferSpecialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OfferTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OfferId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Conocimientos avanzados en SQL",
                            OfferIsActive = true,
                            OfferSpecialty = "SQL",
                            OfferTitle = "Analista de datos"
                        },
                        new
                        {
                            OfferId = 2,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Conocimientos avanzados en entorno .NET",
                            OfferIsActive = true,
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

                    b.Property<bool>("StudentCareerIsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("StudentId", "CareerId");

                    b.HasIndex("CareerId");

                    b.ToTable("StudentCareer", (string)null);

                    b.HasData(
                        new
                        {
                            StudentId = 4,
                            CareerId = 1,
                            StudentCareerIsActive = true
                        },
                        new
                        {
                            StudentId = 5,
                            CareerId = 2,
                            StudentCareerIsActive = true
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentKnowledge", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("KnowledgeId")
                        .HasColumnType("int");

                    b.Property<bool>("StudentKnowledgeIsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserId", "KnowledgeId");

                    b.HasIndex("KnowledgeId");

                    b.ToTable("StudentKnowledge", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 4,
                            KnowledgeId = 1,
                            StudentKnowledgeIsActive = true
                        },
                        new
                        {
                            UserId = 3,
                            KnowledgeId = 2,
                            StudentKnowledgeIsActive = true
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentOffer", b =>
                {
                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<bool>("StudentOfferIsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("OfferId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentOffer", (string)null);

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            StudentId = 4,
                            StudentOfferIsActive = true
                        },
                        new
                        {
                            OfferId = 2,
                            StudentId = 5,
                            StudentOfferIsActive = true
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("UserIsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Admin", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("NameAdmin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            UserId = 6,
                            Password = "fc6272df53e15d8fe84da2db5fdf6da3157b1a1488ff2d1c98b171039e2bf769d574e3efb9a0a3d9dc8e8ad182508b698bd739a7bd2fe75a5c6de5e2ab3c254a",
                            UserEmail = "luciano3924@gmail.com",
                            UserIsActive = true,
                            UserName = "admin",
                            NameAdmin = "AdminPepe"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Company", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("CompanyCUIT")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyLine")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CompanyPendingConfirmation")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CompanyPersonalJob")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyPersonalName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("CompanyPersonalPhone")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyPersonalSurname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("CompanyPhone")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyPostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyRelationContact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyWebPage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Company");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "579019246127c66d28bf72438ea616ee6013ec447aa6577507e12f3124da9bc70e5a856293a33bf390e436b97099ec2b92825216553d66b356a39229880c0f82",
                            UserEmail = "microsoftcontact@gmail.com",
                            UserIsActive = true,
                            UserName = "MicrosoftUser",
                            CompanyAddress = "D 15",
                            CompanyCUIT = 20447575751L,
                            CompanyLine = "Computación",
                            CompanyLocation = "Rosario",
                            CompanyName = "Microsoft",
                            CompanyPendingConfirmation = false,
                            CompanyPersonalJob = "Gerente",
                            CompanyPersonalName = "Juan Carlos",
                            CompanyPersonalPhone = 3413678989L,
                            CompanyPersonalSurname = "Peralta",
                            CompanyPhone = 3413678988L,
                            CompanyPostalCode = "2000",
                            CompanyRelationContact = "Vacio",
                            CompanyWebPage = "microsoft.com"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "579019246127c66d28bf72438ea616ee6013ec447aa6577507e12f3124da9bc70e5a856293a33bf390e436b97099ec2b92825216553d66b356a39229880c0f82",
                            UserEmail = "applecontact@gmail.com",
                            UserIsActive = true,
                            UserName = "AppleUser",
                            CompanyAddress = "E 18",
                            CompanyCUIT = 20445556661L,
                            CompanyLine = "Textil",
                            CompanyLocation = "Rosario",
                            CompanyName = "Apple",
                            CompanyPendingConfirmation = false,
                            CompanyPersonalJob = "Gerente",
                            CompanyPersonalName = "Juan Esteban",
                            CompanyPersonalPhone = 3413344556L,
                            CompanyPersonalSurname = "Peralta",
                            CompanyPhone = 3413344555L,
                            CompanyPostalCode = "2000",
                            CompanyRelationContact = "Vacio",
                            CompanyWebPage = "apple.com"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Student", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("AltEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ApprovedSubjectsQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("AverageMarksWithPostponement")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("AverageMarksWithoutPostponement")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CUIL_CUIT")
                        .HasColumnType("bigint");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CollegeDegree")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CurrentStudyYear")
                        .HasColumnType("int");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FamilyCountry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FamilyDepartment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FamilyFloor")
                        .HasColumnType("int");

                    b.Property<string>("FamilyLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("FamilyOtherPhone")
                        .HasColumnType("bigint");

                    b.Property<long>("FamilyPersonalPhone")
                        .HasColumnType("bigint");

                    b.Property<string>("FamilyProvince")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FamilyStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FamilyStreetLetter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FamilyStreetNumber")
                        .HasColumnType("int");

                    b.Property<int>("File")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalCountry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalDepartment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonalFloor")
                        .HasColumnType("int");

                    b.Property<string>("PersonalLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("PersonalOtherPhone")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonalPersonalPhone")
                        .HasColumnType("bigint");

                    b.Property<string>("PersonalProvince")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalStreetLetter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonalStreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryDegree")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SpecialtyPlan")
                        .HasColumnType("int");

                    b.Property<string>("StudyTurn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            UserId = 3,
                            Password = "579019246127c66d28bf72438ea616ee6013ec447aa6577507e12f3124da9bc70e5a856293a33bf390e436b97099ec2b92825216553d66b356a39229880c0f82",
                            UserEmail = "manuel@frro.utn.edu.ar",
                            UserIsActive = true,
                            UserName = "manuelI",
                            AltEmail = "manuelalt@gmail.com",
                            ApprovedSubjectsQuantity = 10,
                            AverageMarksWithPostponement = 8.5m,
                            AverageMarksWithoutPostponement = 8.6m,
                            Birth = new DateTime(2002, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 20445556661L,
                            CivilStatus = "Soltero",
                            CollegeDegree = "Sistemas",
                            CurrentStudyYear = 2,
                            DocumentNumber = 44555666,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "4B",
                            FamilyFloor = 2,
                            FamilyLocation = "Ciudad Autónoma de Buenos Aires",
                            FamilyOtherPhone = 3413332245L,
                            FamilyPersonalPhone = 3413332244L,
                            FamilyProvince = "Buenos Aires",
                            FamilyStreet = "Calle Principal",
                            FamilyStreetLetter = "A",
                            FamilyStreetNumber = 123,
                            File = 12345,
                            Name = "Manuel",
                            Observations = "Fanático de linux",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 3413332247L,
                            PersonalPersonalPhone = 3413332246L,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            SecondaryDegree = "Completo",
                            Sex = "Masculino",
                            Specialty = "Sistemas",
                            SpecialtyPlan = 2021,
                            StudyTurn = "Tarde",
                            Surname = "Ibarbia"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "579019246127c66d28bf72438ea616ee6013ec447aa6577507e12f3124da9bc70e5a856293a33bf390e436b97099ec2b92825216553d66b356a39229880c0f82",
                            UserEmail = "luciano@frro.utn.edu.ar",
                            UserIsActive = true,
                            UserName = "lucianoS",
                            AltEmail = "lucianoalt@gmail.com",
                            ApprovedSubjectsQuantity = 10,
                            AverageMarksWithPostponement = 6.2m,
                            AverageMarksWithoutPostponement = 7.6m,
                            Birth = new DateTime(1998, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 20334445551L,
                            CivilStatus = "Soltero",
                            CollegeDegree = "Sistemas",
                            CurrentStudyYear = 2,
                            DocumentNumber = 33444555,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "5B",
                            FamilyFloor = 22,
                            FamilyLocation = "Rosario",
                            FamilyOtherPhone = 3418889901L,
                            FamilyPersonalPhone = 3418889900L,
                            FamilyProvince = "Santa Fe",
                            FamilyStreet = "Calle asdasd",
                            FamilyStreetLetter = "AA",
                            FamilyStreetNumber = 12,
                            File = 12346,
                            Name = "Luciano",
                            Observations = "Fanático de linux",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 3418889903L,
                            PersonalPersonalPhone = 3418889902L,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            SecondaryDegree = "Completo",
                            Sex = "Masculino",
                            Specialty = "Sistemas",
                            SpecialtyPlan = 2021,
                            StudyTurn = "Tarde",
                            Surname = "Solari"
                        },
                        new
                        {
                            UserId = 5,
                            Password = "579019246127c66d28bf72438ea616ee6013ec447aa6577507e12f3124da9bc70e5a856293a33bf390e436b97099ec2b92825216553d66b356a39229880c0f82",
                            UserEmail = "santiago@frro.utn.edu.ar",
                            UserIsActive = true,
                            UserName = "santiagoC",
                            AltEmail = "santiagoalt@gmail.com",
                            ApprovedSubjectsQuantity = 10,
                            AverageMarksWithPostponement = 6.3m,
                            AverageMarksWithoutPostponement = 7.5m,
                            Birth = new DateTime(2003, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CUIL_CUIT = 20556667771L,
                            CivilStatus = "Soltero",
                            CollegeDegree = "Sistemas",
                            CurrentStudyYear = 2,
                            DocumentNumber = 55666777,
                            DocumentType = "DNI",
                            FamilyCountry = "Argentina",
                            FamilyDepartment = "5B",
                            FamilyFloor = 22,
                            FamilyLocation = "Rosario",
                            FamilyOtherPhone = 3415556678L,
                            FamilyPersonalPhone = 3415556677L,
                            FamilyProvince = "Santa Fe",
                            FamilyStreet = "Calle asdasd",
                            FamilyStreetLetter = "AA",
                            FamilyStreetNumber = 12,
                            File = 12347,
                            Name = "Santiago",
                            Observations = "Fanático de Visual Studio",
                            PersonalCountry = "Argentina",
                            PersonalDepartment = "Depto. 2",
                            PersonalFloor = 1,
                            PersonalLocation = "Córdoba Capital",
                            PersonalOtherPhone = 3415556680L,
                            PersonalPersonalPhone = 3415556679L,
                            PersonalProvince = "Córdoba",
                            PersonalStreet = "Avenida Principal",
                            PersonalStreetLetter = "B",
                            PersonalStreetNumber = 456,
                            SecondaryDegree = "Completo",
                            Sex = "Masculino",
                            Specialty = "Sistemas",
                            SpecialtyPlan = 2002,
                            StudyTurn = "Tarde",
                            Surname = "Caso"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.CVFile", b =>
                {
                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendBolsaDeTrabajoUTN.Entities.Student", "Student")
                        .WithMany("StudentOffers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
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
