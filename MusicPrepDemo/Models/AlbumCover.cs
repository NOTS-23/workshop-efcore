namespace MusicPrepDemo.Models {
  public class AlbumCover : Entiteit {
    public string Afbeelding { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
  }
}
