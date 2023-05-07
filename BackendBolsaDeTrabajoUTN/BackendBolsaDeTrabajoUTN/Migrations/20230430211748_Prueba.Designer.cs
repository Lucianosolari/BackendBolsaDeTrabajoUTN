﻿// <auto-generated />
using System;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    [DbContext(typeof(TPContext))]
    [Migration("20230430211748_Prueba")]
    partial class Prueba
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Career", b =>
                {
                    b.Property<int>("CareerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("CareerId");

                    b.ToTable("Careers");

                    b.HasData(
                        new
                        {
                            CareerId = 1
                        },
                        new
                        {
                            CareerId = 2
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Knowledge", b =>
                {
                    b.Property<int>("KnowledgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfferDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OfferSpecialty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OfferTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OfferId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            CompanyId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Primera descripción",
                            OfferSpecialty = "hola",
                            OfferTitle = "Primera oferta"
                        },
                        new
                        {
                            OfferId = 2,
                            CompanyId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferDescription = "Segunda descripción",
                            OfferSpecialty = "hola",
                            OfferTitle = "Segunda oferta"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.StudentCareer", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareerId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<int>("KnowledgeId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Admin", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("NameAdmin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            UserId = 6,
                            Password = "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db",
                            UserName = "admin",
                            NameAdmin = "AdminPepe"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Company", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyCUIT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyContactPerson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyDocumentation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyPhone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyWebPage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Company");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db",
                            UserName = "Company 1",
                            CompanyAddress = "D 15",
                            CompanyCUIT = "20447575",
                            CompanyContactPerson = "22",
                            CompanyDocumentation = "asdasd",
                            CompanyEmail = "email",
                            CompanyName = "Primera empresa",
                            CompanyPhone = 341367898,
                            CompanyState = "ok",
                            CompanyType = "srl",
                            CompanyWebPage = "web"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "3627909a29c31381a071ec27f7c9ca97726182aed29a7ddd2e54353322cfb30abb9e3a6df2ac2c20fe23436311d678564d0c8d305930575f60e2d3d048184d79",
                            UserName = "Company 2",
                            CompanyAddress = "D 15",
                            CompanyCUIT = "20447575",
                            CompanyContactPerson = "22",
                            CompanyDocumentation = "asdasd",
                            CompanyEmail = "email",
                            CompanyName = "Segunda empresa",
                            CompanyPhone = 341367899,
                            CompanyState = "ok",
                            CompanyType = "srl",
                            CompanyWebPage = "web"
                        });
                });

            modelBuilder.Entity("BackendBolsaDeTrabajoUTN.Entities.Student", b =>
                {
                    b.HasBaseType("BackendBolsaDeTrabajoUTN.Entities.User");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("File")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            UserId = 3,
                            Password = "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87",
                            UserName = "string",
                            DocumentNumber = 44555666,
                            Email = "manuel@gmail.com",
                            File = 0,
                            Name = "Manuel",
                            Surname = "Ibarbia"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413",
                            UserName = "lucianoS",
                            DocumentNumber = 33444555,
                            Email = "luciano@gmail.com",
                            File = 0,
                            Name = "Luciano",
                            Surname = "Solari"
                        },
                        new
                        {
                            UserId = 5,
                            Password = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413",
                            UserName = "santiagoC",
                            DocumentNumber = 55666777,
                            Email = "santiago@gmail.com",
                            File = 0,
                            Name = "Santiago",
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