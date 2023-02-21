namespace Warenhaus
{
    internal class Artikel
    {
        public int ArtikelID { get; set; }
        public string Artikelname { get; set; }
        public string Artikelbeschreibung { get; set; }
        public string ArtikelKathegorie { get; set; }
        public string Einheit { get; set; }
        public decimal Preis { get; set; }
    }
}