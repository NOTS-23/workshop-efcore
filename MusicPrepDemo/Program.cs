using MusicPrepDemo.Context;
using MusicPrepDemo.Models;
using MusicPrepDemo.Repositories;

namespace MusicPrepDemo {
  public class Program {
    static async void Main(string[] args) {
      using var db = new DataContext();
      Console.WriteLine("Hello, World!");

      var repository = new GeneriekeRepository<Artiest>(db);

      if (await repository.GetAll() == null) {
        var artiest = new Artiest {
          Naam = "The Beatles",
          Land = "UK",
          Geboortedatum = new DateTime(1960, 1, 1)
        };
        await repository.Add(artiest);
      }

      var artiest = await repository.Find

    }
  }
}