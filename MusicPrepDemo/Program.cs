using Microsoft.EntityFrameworkCore;
using MusicPrepDemo.Context;
using MusicPrepDemo.Models;
using MusicPrepDemo.Repositories;

namespace MusicPrepDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // om te zorgen dan we niet 100x dezelfde dummy-data invoegen, verwijderen we deze eerst:
            using var context = new DataContext();

            // verwijder Nummer met Id 13
            var nummerToDelete = await context.Nummers.FindAsync(13);
            if (nummerToDelete != null)
            {
                context.Nummers.Remove(nummerToDelete);
                await context.SaveChangesAsync();
            }

            // verwijder Afspeellijst en Afspeellijst nummers met Id 13 of AfspeellijstId 4
            var afspeellijstenToDelete = await context.Afspeellijsten
                .Where(a => a.Id == 4)
                .ToListAsync();
            if (afspeellijstenToDelete != null)
            {

                foreach (var afspeellijst in afspeellijstenToDelete)
                {
                    var afspeellijstNummersToDelete = await context.AfspeellijstNummers
                        .Where(an => an.AfspeellijstId == afspeellijst.Id)
                        .ToListAsync();

                    context.AfspeellijstNummers.RemoveRange(afspeellijstNummersToDelete);
                }

                context.Afspeellijsten.RemoveRange(afspeellijstenToDelete);
                await context.SaveChangesAsync();
            }

            // verwijder het Album met AlbumId 7
            var albumToDelete = await context.Albums.FindAsync(7);
            if (albumToDelete != null)
            {
                context.Albums.Remove(albumToDelete);
                await context.SaveChangesAsync();
            }

            // verwijder Artiest met Id 4
            var artiestToDelete = await context.Artiesten.FindAsync(4);
            if (artiestToDelete != null)
            {
                context.Artiesten.Remove(artiestToDelete);
                await context.SaveChangesAsync();
            }

            var nummerRepo = new GeneriekeRepository<Nummer>(context);
            var artiestRepo = new GeneriekeRepository<Artiest>(context);

            Console.WriteLine("--------");
            Console.WriteLine("Artiesten:");
            var artiesten = await artiestRepo.GetAll();
            foreach (var artiest in artiesten)
            {
                Console.WriteLine($"Artiest: {artiest.Id} {artiest.Naam}");
            }

            Console.WriteLine("--------");

            var nummers = await nummerRepo.GetAll();
            Console.WriteLine("Nummers:");
            foreach (var nummer in nummers)
            {
                Console.WriteLine($"Nummer: {nummer.Id} {nummer.Titel}");
            }

            Console.WriteLine("--------");
            Console.WriteLine("Afspeellijsten:");
            var afspeellijsten = await context.Afspeellijsten
                .Include(a => a.Nummers)
                .ThenInclude(n => n.Nummer)
                .ToListAsync();

            foreach (var lijst in afspeellijsten)
            {
                Console.WriteLine($"\tAfspeellijst: {lijst.Id} {lijst.Naam}");
                foreach (var nummer in lijst.Nummers)
                {
                    Console.WriteLine($"\t\tNummer: {nummer.Nummer.Id} {nummer.Nummer.Titel}");
                }
            }
        }
    }
}