using MusicPrepDemo.Context;
using MusicPrepDemo.Models;
using MusicPrepDemo.Repositories;

namespace MusicPrepDemo {
  public class Program {
    static async Task Main(string[] args) {
      using var db = new DataContext();
      Console.WriteLine("Hello, World!");

      var artiestRepository = new GeneriekeRepository<Artiest>(db);
        Artiest? artiest = await artiestRepository.Find(a => a.Naam == "Bach");
        Console.WriteLine(artiest.Id);

            var albumRepository = new GeneriekeRepository<Album>(db);
            Album? album = await albumRepository.Find(a => a.Artiest.Naam == "Bach");
            Console.WriteLine(album.Id);
    }
  }
}