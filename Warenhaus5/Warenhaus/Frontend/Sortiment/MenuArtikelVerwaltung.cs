namespace Warenhaus
{
    class MenuArtikelVerwaltung
    {
        Menu _menu;
        MenuMulti _menuMulti;
        MenuBearbeiten _menuBearbeiten;
        ArtikelVerwaltung _verwaltung;
        int _left;
        int _top;
        public MenuArtikelVerwaltung(DBAcess acess, int left, int top)
        {
            _left = left;
            _top = top;
            _verwaltung = new ArtikelVerwaltung(acess);
        }
        public void Datenbank()
        {
            string artikel = "Artikel Verwaltung";
            string[] optionen = { "Alle Anzeigen", "Artikel Suchen", "Neuen Artikel Anlegen", "Zurück"};
            _menu = new Menu(artikel, optionen, _left, _top);
            int selectedIndex = _menu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    AlleAnzeigen();
                    break;
                case 1:
                    ArtikelSuchen();
                    break;
                case 2:
                    NeuerArtikel();
                    break;
                case 3:
                    
                    break;
            }
        }
        public void AlleAnzeigen()
        {
            _verwaltung.ArtikelLaden();
            int i = 0;
            string[] optionen = new string[_verwaltung.ArtikelListe.Count + 1];
            string titel = "Artikel Verwaltung";
            foreach (Artikel art in _verwaltung.ArtikelListe)
            {
                optionen[i] = art.Artikelname;
                i++;
            }
            optionen[i] = "Zurück";
            string[] optionen2 = { "Bearbeiten", "Löschen" };
            _menuMulti = new MenuMulti(titel, optionen, optionen2, _left, _top);
            int[] indexer = _menuMulti.Run();
            Console.Clear();
            if (indexer[0] == optionen.Length - 1)
            {
                Datenbank();

            }
            else if (indexer[1] == 0) 
            {
                ArtikelBearbeiten(_verwaltung.ArtikelListe[indexer[0]]);
            }
            else if(indexer[1] == 1)
            {
                if(_verwaltung.ArtikelLoeschen(_verwaltung.ArtikelListe[indexer[0]].ArtikelID))
                {

                }
            }
            else if (indexer[1] == 2)
            {

            }
            Datenbank();
        }
        void ArtikelSuchen()
        {
            string titel = "Artikel Suche";
            string[] optionen = { "Name", "Zurück" };
            _menuBearbeiten = new MenuBearbeiten(titel, optionen, _left, _top);
            string[] eingabe = _menuBearbeiten.Run();
            Console.Clear();
            ArtikelBearbeiten(_verwaltung.ArtikelSuchenName(eingabe[0]));
        }
        void NeuerArtikel()
        {
            string titel = "Neuer Artikel";
            string[] optionen = { "Name", "Beschreibung", "Kathegorie", "einheit", "preis", "Fertig" };
            _menuBearbeiten = new MenuBearbeiten(titel, optionen, _left, _top);
            string[] eingabe = _menuBearbeiten.Run();
            if(_verwaltung.ArtikelAnlegen(eingabe[0], eingabe[1], Convert.ToInt32(eingabe[2]), eingabe[3], Convert.ToDecimal(eingabe[4])))
            {
                Console.SetCursorPosition(_left, _top - 1);
                Console.WriteLine("Erfolgreich eingetragen");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(_left, _top - 1);
                Console.WriteLine("Fehler!!!");
                Console.ReadKey();
            }
            Console.Clear();
            Datenbank();
        }
        void ArtikelBearbeiten(Artikel artikel)
        {
            string titel = "Artikel Bearbeiten";
            string[] optionen = { artikel.ArtikelID.ToString(), artikel.Artikelname, artikel.Artikelbeschreibung, artikel.ArtikelKathegorie.ToString(), "Zurück" };
            _menuBearbeiten = new MenuBearbeiten(titel, optionen, _left, _top);
            string[] eingabe = _menuBearbeiten.Run();

            for (int i = 1; i < optionen.Length; i++)
            {
                if(eingabe[i] != null | eingabe[i] != "")
                {
                    optionen[i] = eingabe[i];
                }
            }

            Console.Clear();
            _verwaltung.ArtikelAktualisieren(artikel.ArtikelID, optionen[1], optionen[2], optionen[3], Convert.ToInt32(eingabe[3]), Convert.ToDecimal(eingabe[4]));
 
        }

    }
}