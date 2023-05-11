using Microsoft.EntityFrameworkCore;
using MusicPrepDemo.Models;

namespace MusicPrepDemo.Context {
  public class DataContext : DbContext {

    public DataContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseNpgsql("Host=localhost;Database=nots-wapp-muziek-preparation-db;Username=postgres;Password=postgres;");
    }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            
            // artiest -> albums: one-many
            mb.Entity<Artiest>().HasMany(a => a.Albums).WithOne(a => a.Artiest).HasForeignKey(a => a.ArtiestId);
            
            // album -> albumcover: one-one
            mb.Entity<Album>().HasOne(a => a.AlbumCover).WithOne(ac => ac.Album).HasForeignKey<AlbumCover>(ac => ac.AlbumId);
            
            // Nummers <> Afspeellijst: many-many
            mb.Entity<AfspeellijstNummer>().HasKey(an => new { an.NummerId, an.AfspeellijstId });
            mb.Entity<AfspeellijstNummer>().HasOne(an => an.Nummer).WithMany(n => n.Lijsten).HasForeignKey(l => l.NummerId);
            mb.Entity<AfspeellijstNummer>().HasOne(an => an.Afspeellijst).WithMany(a => a.Nummers).HasForeignKey(n => n.AfspeellijstId);
            
            // --- seed data ---
            // Artiesten
            mb.Entity<Artiest>().HasData(
                new Artiest { Id = 1, Land = "UK", Naam = "The Beatles" },
                new Artiest { Id = 2, Land = "FR", Naam = "Stromae" },
                new Artiest { Id = 3, Land = "AU", Naam = "Bach"}
            );
            // Albums
            mb.Entity<Album>().HasData(
                new Album { Id = 1, AlbumCoverId = 1, ArtiestId = 1, Titel = "Abbey Road" },
                new Album { Id = 2, AlbumCoverId = 2, ArtiestId = 1, Titel = "Resolver" },
                new Album { Id = 3, AlbumCoverId = 3, ArtiestId = 2, Titel = "Cheese" },
                new Album { Id = 4, AlbumCoverId = 4, ArtiestId = 2, Titel = "Multitude" },
                new Album { Id = 5, AlbumCoverId = 5, ArtiestId = 3, Titel = "Sonata's" },
                new Album { Id = 6, AlbumCoverId = 6, ArtiestId = 3, Titel = "Flute's" }
            );
            // AlbumCovers
            mb.Entity<AlbumCover>().HasData(
                new AlbumCover { Id = 1, AlbumId = 1, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" },
                new AlbumCover { Id = 2, AlbumId = 2, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" },
                new AlbumCover { Id = 3, AlbumId = 3, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" },
                new AlbumCover { Id = 4, AlbumId = 4, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" },
                new AlbumCover { Id = 5, AlbumId = 5, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" },
                new AlbumCover { Id = 6, AlbumId = 6, Afbeelding = "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg" }
            );
            // Nummers
            mb.Entity<Nummer>().HasData(
                // Nummers van Abbey Road door The Beatles
                new Nummer { Id = 1, AlbumId = 1, Titel = "Come Together", Lengte = 259 },
                new Nummer { Id = 2, AlbumId = 1, Titel = "Something", Lengte = 183 },
                // Nummers van Resolver door The Beatles
                new Nummer { Id = 3, AlbumId = 2, Titel = "Back in the USSR", Lengte = 163 },
                new Nummer { Id = 4, AlbumId = 2, Titel = "Dear Prudence", Lengte = 254 },
                // Nummers van Cheese door Stromae
                new Nummer { Id = 5, AlbumId = 3, Titel = "Alors on danse", Lengte = 220 },
                new Nummer { Id = 6, AlbumId = 3, Titel = "Te Quiero", Lengte = 228 },
                // Nummers van Multitude door Stromae
                new Nummer { Id = 7, AlbumId = 4, Titel = "Meltdown", Lengte = 213 },
                new Nummer { Id = 8, AlbumId = 4, Titel = "Papaoutai", Lengte = 229 },
                // Nummers van Sonata's door Bach
                new Nummer { Id = 9, AlbumId = 5, Titel = "Sonata No. 1 in G minor", Lengte = 287 },
                new Nummer { Id = 10, AlbumId = 5, Titel = "Sonata No. 2 in A major", Lengte = 285 },
                // Nummers van Flute's door Bach
                new Nummer { Id = 11, AlbumId = 6, Titel = "Flute Sonata in E-flat major", Lengte = 345 },
                new Nummer { Id = 12, AlbumId = 6, Titel = "Flute Sonata in C major", Lengte = 208 }
            );


            // Afspeellijsten
            mb.Entity<Afspeellijst>().HasData(
                new Afspeellijst { Id = 1, Naam = "Rock Classics" },
                new Afspeellijst { Id = 2, Naam = "Electronic Hits" },
                new Afspeellijst { Id = 3, Naam = "Hip Hop Gems" }
            );


            // AfspeellijstNummers
            mb.Entity<AfspeellijstNummer>().HasData(
                new AfspeellijstNummer { AfspeellijstId = 1, NummerId = 1 },
                new AfspeellijstNummer { AfspeellijstId = 1, NummerId = 3 },
                new AfspeellijstNummer { AfspeellijstId = 1, NummerId = 5 },
                new AfspeellijstNummer { AfspeellijstId = 1, NummerId = 7 },
                new AfspeellijstNummer { AfspeellijstId = 2, NummerId = 2 },
                new AfspeellijstNummer { AfspeellijstId = 2, NummerId = 4 },
                new AfspeellijstNummer { AfspeellijstId = 2, NummerId = 6 },
                new AfspeellijstNummer { AfspeellijstId = 2, NummerId = 8 },
                new AfspeellijstNummer { AfspeellijstId = 3, NummerId = 9 },
                new AfspeellijstNummer { AfspeellijstId = 3, NummerId = 11 },
                new AfspeellijstNummer { AfspeellijstId = 3, NummerId = 12 }
            );
        }
    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumCover> AlbumCovers { get; set; }
    public DbSet<Artiest> Artiesten { get; set; }
    public DbSet<Nummer> Nummers { get; set; }
    public DbSet<Afspeellijst> Afspeellijsten { get; set; }
    public DbSet<AfspeellijstNummer> AfspeellijstNummers { get; set; }
  }
}
