using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPrepDemo.Models {
  public class AfspeellijstNummer : Entiteit {
    public int NummerId { get; set; }
    [ForeignKey("NummerId")]

    public Nummer Nummer { get; set; }
    public int AfspeellijstId { get; set; }
    [ForeignKey("AfspeellijstId")]
    public Afspeellijst Afspeellijst { get; set; }
  }
}
