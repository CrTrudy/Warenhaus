namespace WarenhausForms6
{
    class Lager
    {
        public readonly int Nummer;
        public readonly int Kapazitaet;
        public readonly string Name;
        List<Artikel> _artikelliste;
        public Lager(string name, int nummer, int kapazitaet)
        {
            Nummer = nummer;
            Kapazitaet = kapazitaet;
            Name = name;
            _artikelliste = new List<Artikel>();
        }
        public Artikel SucheID(int ID)
        {
            foreach (var artikel in _artikelliste)
            {
                if (artikel.ArtikelID == ID)
                {
                    return artikel;
                }
            }
            return null;
        }
        public int Frei()
        {
            return Kapazitaet - _artikelliste.Count();
        }
        public int AnzahlEinArtikel(Artikel artikel)
        {
            int count = 0;
            foreach (var item in _artikelliste)
            {
                if (Object.Equals(item, artikel))
                {
                    count++;
                }
            }
            return count;
        }
        public bool Einlagern(Artikel artikel, int menge)
        {
            if (Frei() >= menge)
            {
                for (int i = 0; i < menge; i++)
                {
                    _artikelliste.Add(artikel);
                }
                return true;
            }
            return false;
        }
        public bool Auslagern(Artikel artikel, int menge)
        {
            if (AnzahlEinArtikel(artikel) > menge)
            {
                for (int i = 0; i < menge; i++)
                {
                    _artikelliste.Remove(artikel);
                }
                return true;
            }
            return false;
            

        }
    }
}