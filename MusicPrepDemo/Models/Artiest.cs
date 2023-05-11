using System.Text.Json.Serialization;

namespace MusicPrepDemo.Models {
  public class Artiest : Entiteit {
    public string Naam { get; set; }
    public string Land { get; set; }
    public DateTime Geboortedatum { get; set; }

    [JsonIgnore]
    public ICollection<Album> Albums { get; set; }
  }
}
