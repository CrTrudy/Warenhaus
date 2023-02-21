namespace Warenhaus
{
    class MenuBestand
    {
        Menu _menu;
        MenuMulti _menuMulti;
        MenuBearbeiten _menuBearbeiten;
        MenuArtikelVerwaltung _menuVerwaltung;
        LagerVerwaltung _lagerverwaltung;
        int _left;
        int _top;
        public MenuBestand(DBAcess acess, int left, int top)
        {
            _left = left;
            _top = top;
            _menuVerwaltung = new MenuArtikelVerwaltung(acess, left, top);
            _lagerverwaltung = new LagerVerwaltung(acess);
        }
        public void DatenLager()
        {
            string lager = "Verwalten";
            string[] optionen = { "Bestand Verwaltung", "Artikel Verwaltung", "Nutzer Verwaltung" };
            _menu = new Menu(lager, optionen, _left, _top);
            int selectedIndex = _menu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    Lager();
                    break;
                case 1:
                    _menuVerwaltung.Datenbank();
                    break;
                case 2:
                    //_menuNutzer.Verwaltung();
                    break;
            }
        }
        void Lager()
        {
            string titel = "Lager Verwaltung";
            string[] optionen = { "Lager wählen", "Artikel/Lagern suche", "Lager Anlegen", "Zurück" };
            _menu = new Menu(titel, optionen, _left, _top);
            int selectedIndex = _menu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    LagerWahl();
                    break;
                case 1:
                    Daten();
                    break;
                case 2:
                    Daten();
                    break;
                case 3:
                    Daten();
                    break;
                case 4:
                    DatenLager();
                    break;
            }
        }
        void LagerWahl()
        {
            string titel = "Lager auswählen";
            _lagerverwaltung.LagerLaden();
            string[] optionen = new string[_lagerverwaltung.LagerListe.Count +1];
            int i = 0;
            foreach (var lag in _lagerverwaltung.LagerListe)
            {
                optionen[i] = lag.Name;
                i++;
            }
            optionen[i] = "Zurück";
            string[] optionen2 = { "Bearbeiten", "Löschen" };
            _menuMulti = new MenuMulti(titel, optionen, optionen2, _left, _top);
            int[] indexer = _menuMulti.Run();
            Console.Clear();
            if (indexer[0] == optionen.Length - 1)
            {
                Lager();
            }
            else if (indexer[1] == 0)
            {
                LagerBearbeiten(_lagerverwaltung.LagerListe[indexer[0]]);
            }
            else if (indexer[1] == 1)
            {
                if (_lagerverwaltung.LagerLoeschen(_lagerverwaltung.LagerListe[indexer[0]].Nummer))
                {
                    Console.WriteLine("Erfolgreich gelöscht");
                    Thread.Sleep(500);
                }
            }
            LagerWahl();
        }
        void SucheArtikelInLagern()
        {

        }
        void Daten()
        {
            DatenLager();
        }
        void LagerBearbeiten(Lager lag)
        {
            string titel = "Lager Bearbeiten";
            string[] optionen = {lag.Name.ToString(), lag.Kapazitaet.ToString(), "Zurück" };
            _menuBearbeiten = new MenuBearbeiten(titel, optionen, _left, _top);
            string[] eingabe = _menuBearbeiten.Run();

            for (int i = 0; i < optionen.Length; i++)
            {
                if (eingabe[i] != null | eingabe[i] != "")
                {
                    optionen[i] = eingabe[i];
                }
            }
            Console.Clear();
            _lagerverwaltung.LagerAktualisieren(optionen[0], lag.Nummer, Convert.ToInt32(optionen[1]));
        }
    }
}