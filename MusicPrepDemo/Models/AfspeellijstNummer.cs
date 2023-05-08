namespace MusicPrepDemo.Models {
  public class AfspeellijstNummer : Entiteit {
    public int NummerId { get; set; }
    public Nummer Nummer { get; set; }
    public int AfspeellijstId { get; set; }
    public Afspeellijst Afspeellijst { get; set; }
  }
}
