using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.DBContexts
{
    public class TPContext : DbContext
    {
        public DbSet<Student> Students { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Company> Companies { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentKnowledge> StudentKnowledge { get; set; }

        public TPContext(DbContextOptions<TPContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            Company company1 = new Company()
            {
                UserId = 1,
                UserName = "Company 1",
                Password = "1234",
                //CompanyId = 1,
                CompanyCUIT = "20447575",
                CompanyName = "Primera empresa",
                CompanyPhone = 341367898,
                CompanyAddress = "D 15",
                CompanyContactPerson = "22",
                CompanyEmail = "email",
                CompanyDocumentation = "asdasd",
                CompanyState = "ok",
                CompanyType = "srl",
                CompanyWebPage = "web",

            };

            Company company2 = new Company()
            {
                UserId = 2,
                UserName = "Company 2",
                CompanyAddress = "D 15",
                CompanyContactPerson = "22",
                CompanyEmail = "email",
                CompanyDocumentation = "asdasd",
                CompanyState = "ok",
                //CompanyId = 2,
                Password = "12345",
                CompanyCUIT = "20447575",
                CompanyName = "Segunda empresa",
                CompanyPhone = 341367899,
                CompanyType = "srl",
                CompanyWebPage = "web",
            };

            modelBuilder.Entity<Company>().HasData(
                company1, company2);

            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            Offer offer1 = new Offer()
            {
                OfferId = 1,
                OfferTitle = "Primera oferta",
                OfferDescription = "Primera descripción",
                OfferSpecialty = "hola",
                CompanyId = 2,
            };

            Offer offer2 = new Offer()
            {
                OfferId = 2,
                OfferTitle = "Segunda oferta",
                OfferDescription = "Segunda descripción",
                OfferSpecialty = "hola",
                CompanyId = 1,
            };

            modelBuilder.Entity<Offer>().HasData(
                offer1, offer2);

           

            Career career1 = new Career()
            {
                CareerId = 1,
            };

            Career career2 = new Career()
            {
                CareerId = 2,
            };


            modelBuilder.Entity<Career>().HasData(
                career1, career2);

            Knowledge knowledge1 = new Knowledge()
            {
                KnowledgeId = 1,
                Type = "Programming",
                Level = "Advanced"
            };
            Knowledge knowledge2 = new Knowledge()
            {
                KnowledgeId = 2,
                Type = "Design",
                Level = "Intermediate"
            };
            Knowledge knowledge3 = new Knowledge()
            {
                KnowledgeId = 3,
                Type = "Marketing",
                Level = "Beginner"
            };
            modelBuilder.Entity<Knowledge>().HasData(
                knowledge1, knowledge2, knowledge3);



            Student student1 = new Student()
            {
                UserId = 3,

                //StudentId = 1,
                Name = "Manuel",
                Surname = "Ibarbia",
                Email = "manuel@gmail.com",
                Password = "string",
                UserName = "string",
                DocumentNumber = 44555666,
            };

            Student student2 = new Student()
            {
                UserId = 4,
                //StudentId = 2,
                Name = "Luciano",
                Surname = "Solari",
                Email = "luciano@gmail.com",
                Password = "123456",
                UserName = "lucianoS",
                DocumentNumber = 33444555,
            };

            Student student3 = new Student()
            {
                UserId = 5,
                //StudentId = 3,
                Name = "Santiago",
                Surname = "Caso",
                Email = "santiago@gmail.com",
                Password = "123456",
                UserName = "santiagoC",
                DocumentNumber = 55666777,
            };


            modelBuilder.Entity<Student>().HasData(
                student1, student2, student3);

            modelBuilder.Entity<Company>()
                .HasMany<Offer>(c => c.AnnouncedOffers)
                .WithOne(o => o.Company);

            modelBuilder.Entity<Student>()
            .HasMany(s => s.Knowledges)
            .WithMany(k => k.Students)
            .UsingEntity<StudentKnowledge>(
                j => j
                    .HasOne(sk => sk.Knowledge)
                    .WithMany(k => k.StudentKnowledges)
                    .HasForeignKey(sk => sk.KnowledgeId),
                j => j
                    .HasOne(sk => sk.Student)
                    .WithMany(s => s.StudentKnowledges)
                    .HasForeignKey(sk => sk.UserId),
                j =>
                {
                    j.HasKey(sk => new { sk.UserId, sk.KnowledgeId });
                    j.ToTable("StudentKnowledge");
                    j.HasData(
                        new StudentKnowledge { UserId = 4, KnowledgeId = 1 },
                        new StudentKnowledge { UserId = 3, KnowledgeId = 2 }
                    );
                }
            );


            modelBuilder.Entity<Student>() // ESTUDIANTE_CARRERA
                .HasMany(s => s.Careers)
                .WithMany(c => c.Students)
                .UsingEntity<StudentCareer>(
                    j => j.HasOne(c => c.Career)
                          .WithMany()
                          .HasForeignKey(c => c.CareerId),
                    j => j.HasOne(s => s.Student)
                          .WithMany()
                          .HasForeignKey(s => s.StudentId),
                    j =>
                    {
                        j.ToTable("StudentCareer");
                        j.HasKey(k => new { k.StudentId, k.CareerId });
                        j.HasData(
                            new StudentCareer { StudentId = 4, CareerId = 1 },
                            new StudentCareer { StudentId = 5, CareerId = 2 }
                        );
                    }
                );


                modelBuilder.Entity<Student>()
          .HasMany(s => s.Offers)
          .WithMany(o => o.Students)
          .UsingEntity<StudentOffer>(
              j => j
                  .HasOne(so => so.Offer)
                  .WithMany(o => o.StudentOffers)
                  .HasForeignKey(so => so.OfferId),
              j => j
                  .HasOne(so => so.Student)
                  .WithMany(s => s.StudentOffers)
                  .HasForeignKey(so => so.StudentId),
              j =>
              {
                  j.ToTable("StudentOffer");
                  j.HasData(
                      new { OfferId = 1, StudentId = 4 },
                      new { OfferId = 2, StudentId = 5 }
                  );
              });


            base.OnModelCreating(modelBuilder);
        }
    }
}
