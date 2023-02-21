namespace WarenhausForms6
{
    class Bestellung
    {
        public int BestellID { get; set; }
        public string E_mail { get; set; }
        public Status Status { get; set; }
        public DateTime Datum { get; set; }
    }
    enum Status
    {
        Warenkorb,
        bezahlt,
        verpackt,
        versendet,
        storniert
    }
    class Warenkorb
    {
        public string ArtikelName { get; set; }
        public int Anzahl {  get; set; }
        public Einheit Einheit { get; set; }
        public double StkPreis { get; set; }
        public double Preis { get; set; }
    }
}