using Microsoft.EntityFrameworkCore;
using MusicPrepDemo.Models;

namespace MusicPrepDemo.Context {
  public class DataContext : DbContext {

    public DataContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseNpgsql("Host=localhost;Database=nots-wapp-muziek-prep-db;Username=postgres;Password=postgres;");
    }

    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumCover> AlbumCovers { get; set; }
    public DbSet<Artiest> Artiesten { get; set; }
    public DbSet<Nummer> Nummers { get; set; }
    public DbSet<Afspeellijst> Afspeellijsten { get; set; }
    public DbSet<AfspeellijstNummer> AfspeellijstNummers { get; set; }
  }
}
