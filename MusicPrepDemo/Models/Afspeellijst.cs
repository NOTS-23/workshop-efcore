namespace MusicPrepDemo.Models {
  public class Afspeellijst : Entiteit {
    public string Naam { get; set; }
    public ICollection<AfspeellijstNummer> Nummers { get; set; }
  }
}
