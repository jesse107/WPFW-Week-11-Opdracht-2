using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace Opdracht
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder b) =>
            b.UseSqlite("Data Source=database.db");
          //b.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<PremiumKlant> PremiumKlanten { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
               .HasOne(p => p.Maker)
               .WithMany(u => u.GemaakteReviews);
            modelBuilder.Entity<Review>()
               .HasOne(p => p.Commenter)
               .WithMany(u => u.ReviewComments);
        }
    }

    [Table("KlantTabel")]
    public class Klant
    {
        [Key]
        public int Id { get; set; }
        [Required][StringLength(20)]
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        [NotMapped]
        public string VolledigeNaam
        {
            get
            {
                return Naam + " " + Achternaam;
            }
        }
        public Adres Adres { get; set; }
        public int AdresId { get; set; }
        public List<Bestelling> Bestellingen { get; set; }


        //Dit moet als er wel Fluent API wordt gebruikt
        public List<Review> GemaakteReviews { get; set; }
        public List<Review> ReviewComments { get; set; }

        //Dit moet als er geen Fluent API wordt gebruikt
        /*[InverseProperty("Maker")]
        public List<Review> GemaakteReviews { get; set; }

        [InverseProperty("Commenter")]
        public List<Review> ReviewComments { get; set; }
        */
    }

    //Overerving van klant, waarbij een Premiumklant een code krijgt voor korting
    public class PremiumKlant : Klant
    {
        public int KortingCode { get; set; }
    }

    //Reviews kunnen geschreven worden en er kan een reactie op een review geplaatst worden.
    public class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int MakerId { get; set; }
        public Klant Maker { get; set; }

        public int CommentId { get; set; }
        public Klant Commenter { get; set; }
    }


    //1 op 1 relatie met klant
    public class Adres
    {
        public int Id { get; set; }
        [Column("Straatnaam")]
        public string Straat { get; set; }
        public Klant Klant { get; set; }
    }

    //1 op veel relatie met klant
    public class Bestelling
    {
        public int Id { get; set; }
        public string ArtikelNaam { get; set; }
        public int KlantId { get; set; } // hoeft niet
        public Klant Klant { get; set; } // hoeft niet

        public List<ProductBestelling> ProductBestelling { get; set; }
    }

    //veel op veel relatie met Bestelling
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int BestellingId { get; set; }
        public List<ProductBestelling> ProductBestelling { get; set; }
    }
    //tussentabel product en Bestelling
    public class ProductBestelling
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public Bestelling Bestelling { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
