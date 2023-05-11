using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPrepDemo.Models {
  public class Album : Entiteit {
    public string Titel { get; set; }
    public DateTime ReleaseDatum { get; set; }
    public int ArtiestId { get; set; }

    [ForeignKey("ArtiestId")]
    public Artiest Artiest { get; set; }
    public ICollection<Nummer> Nummers { get; set; }
    public AlbumCover AlbumCover { get; set; }
    public int AlbumCoverId { get; set; }
  }
}
