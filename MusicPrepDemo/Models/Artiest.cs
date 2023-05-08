namespace MusicPrepDemo.Models {
  public class Artiest : Entiteit {
    public string Naam { get; set; }
    public string Land { get; set; }
    public DateTime Geboortedatum { get; set; }
    public ICollection<Album> Albums { get; set; }
  }
}
