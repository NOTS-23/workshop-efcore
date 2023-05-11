using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPrepDemo.Models {
  public class AlbumCover : Entiteit {
    public string Afbeelding { get; set; }
    public int AlbumId { get; set; }
    [ForeignKey("AlbumId")]
    public Album Album { get; set; }
  }
}
