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

        public TPContext(DbContextOptions<TPContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Company company1 = new Company()
            {
                UserId = 1,
                //CompanyId = 1,
                CompanyCUIT = "20447575",
                CompanyName = "Primera empresa",
                CompanyPhone = 341367898,
            };

            Company company2 = new Company()
            {
                UserId = 2,
                //CompanyId = 2,
                CompanyCUIT = "20447575",
                CompanyName = "Segunda empresa",
                CompanyPhone = 341367899,
            };

            modelBuilder.Entity<Company>().HasData(
                company1, company2);

            Offer offer1 = new Offer()
            {
                OfferId = 1,
                OfferTitle = "Primera oferta",
                OfferDescription = "Primera descripción",
            };

            Offer offer2 = new Offer()
            {
                OfferId = 2,
                OfferTitle = "Segunda oferta",
                OfferDescription = "Segunda descripción",
            };

            modelBuilder.Entity<Offer>().HasData(
                offer1, offer2);

            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

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
                UserId=5,
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

            modelBuilder.Entity<Student>() //ESTUDIANTE_CONOCIMIENTO
                .HasMany(s => s.Knowledges)
                .WithMany(k => k.Students)
                .UsingEntity(e => e
                .ToTable("StudentKnowledge")
                .HasData(new[]
                {
                    new { KnowledgeId = 1, UserId = 1},
                    new { KnowledgeId = 2, UserId = 2},
                }
                ));

            modelBuilder.Entity<Student>() //ESTUDIANTE_CARRERA
                .HasMany(s => s.Careers)
                .WithMany(c => c.Students)
                .UsingEntity(e => e
                .ToTable("StudentCareer")
                .HasData(new[]
                {
                    new { CareerId = 1, UserId = 4},
                    new { CareerId = 2, UserId = 5},
                }
                ));

            modelBuilder.Entity<Student>() //ESTUDIANTE_CARRERA
                .HasMany(s => s.Offers)
                .WithMany(o => o.Students)
                .UsingEntity(e => e
                .ToTable("StudentOffer")
                .HasData(new[]
                {
                    new { OfferId = 1, UserId = 1},
                    new { OfferId = 2, UserId = 3},
                }
                ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
