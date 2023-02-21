namespace Warenhaus
{
    class MitarbeiterDisplay
    {
        MenuBestand _bestand;
        MenuArtikelVerwaltung _verwaltung;
        public MitarbeiterDisplay(DBAcess acess, int left, int top)
        {
            _bestand = new MenuBestand(acess, left, top);
            _verwaltung = new MenuArtikelVerwaltung(acess, left, top);
            Start();
        }

        void Start()
        {
            _bestand.DatenLager();
        }

    }
    
}