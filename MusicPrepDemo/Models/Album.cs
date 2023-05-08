namespace MusicPrepDemo.Models {
  public class Album : Entiteit {
    public string Titel { get; set; }
    public DateTime ReleaseDatum { get; set; }
    public int ArtiestId { get; set; }
    public Artiest Artiest { get; set; }
    public ICollection<Nummer> Nummers { get; set; }
    public AlbumCover AlbumCover { get; set; }
  }
}
