namespace MusicPrepDemo.Models {
  public class Nummer : Entiteit {
    public string Titel { get; set; }
    public int Lengte { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public ICollection<AfspeellijstNummer> Lijsten { get; set; }
  }
}
