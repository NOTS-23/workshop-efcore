# Stappenplan

1. ## Maak een nieuwe console applicatie aan

1. ## Installeer de volgende packages:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite // of een andere database provider

1. ## Bedenk je structuur:

- Artiest
- Album
  - AlbumCover
- Nummer
- Afspeellijst
  - AfspeellijstNummer

Artiest maakt nummers en albums: 1-many relatie
Albums hebben nummers: 1-many relatie
AlbumCovers hebben een afbeelding voor een album: 1-1 relatie
Afspeellijsten hebben nummers die ook in andere afspeellijsten kunnen zitten: many-to-many relatie

1. ## Maak je modellen aan

```csharp
public class Artiest
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Land { get; set; }
    public DateTime Geboortedatum { get; set; }
    public ICollection<Album> Albums { get; set; }
}

public class Album
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public DateTime ReleaseDatum { get; set; }
    public int ArtiestId { get; set; }
    public Artiest Artiest { get; set; }
    public ICollection<Nummer> Nummers { get; set; }
    public AlbumCover AlbumCover { get; set; }
}

public class AlbumCover
{
    public int Id { get; set; }
    public string Afbeelding { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
}

public class Nummer
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public ICollection<AfspeellijstNummer> Lijsten { get; set; }
}

public class AfspeelLijst
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public ICollection<AfspeellijstNummer> Nummers { get; set; }
}

public class AfspeellijstNummer
{
    public int Id { get; set; }
    public int NummerId { get; set; }
    public Nummer Nummer { get; set; }
    public int AfspeellijstId { get; set; }
    public AfspeelLijst Afspeellijst { get; set; }
}
```

1. ## Maak je context aan

```csharp
public class MuziekContext : DbContext
{
    public DbSet<Artiest> Artiesten { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumCover> AlbumCovers { get; set; }
    public DbSet<Nummer> Nummers { get; set; }
    public DbSet<AfspeelLijst> AfspeelLijsten { get; set; }
    public DbSet<AfspeellijstNummer> AfspeellijstNummers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Jouw connectie string hier");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      /**
        * Hier kan je data seeden.
       */
    }
}
```

1. ## Maak je migraties aan

```bash
dotnet ef migrations add InitialCreate
```

1. ## Maak je database aan

```bash
dotnet ef database update
```

1. ## Maak een repository aan

```csharp
public class Repository<T> : IRepository<T> where T : class // ik zeg vaak zelf hier T = Entity, dan weet je dat deze entiteit in de database zit en dat je niet een willekeurig object kan meegeven
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
```

1. ## Maak gebruik van de repository

```csharp
public class Program
{
    private static readonly MuziekContext _context = new MuziekContext();
    private static readonly IRepository<Artiest> _artiestRepository = new Repository<Artiest>(_context);

    static void Main(string[] args)
    {
        var artiest = new Artiest
        {
            Naam = "Eminem",
            Land = "USA",
            Geboortedatum = new DateTime(1972, 10, 17)
        };

        _artiestRepository.Add(artiest);
        _artiestRepository.SaveChanges();

        var artiesten = _artiestRepository.GetAll();
        foreach (var a in artiesten)
        {
            Console.WriteLine(a.Naam);
        }
    }
}
```

1. ## Run de applicatie

```bash
dotnet run
```
