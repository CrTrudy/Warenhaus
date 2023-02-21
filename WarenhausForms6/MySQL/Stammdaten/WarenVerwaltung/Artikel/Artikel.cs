namespace WarenhausForms6
{
    internal class Artikel
    {
        public int ArtikelID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Kategorie Kategorie { get; set; }
        public Einheit Einheit { get; set; }
        public decimal Preis { get; set; }
        public Artikel()
        {
            Kategorie = Kategorie.Obst_frisch;
            Einheit = Einheit.kg;
        }
    }

    public enum Einheit
    {
        kg,
        g,
        stk,
        bund,
        L
    }
    public enum Kategorie
    {
        Obst_frisch = 1,
        Gemuese_frisch = 2,
        Obst = 3,
        Gemuese = 4,
        Milchprodukt = 5,
        Snack = 6

    }
}