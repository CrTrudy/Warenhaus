
namespace WarenhausForms6
{
    class ArtikelVerwaltung : IVerwaltung
    {
        public List<Artikel> ArtikelListe { get; set; }
        DBAcess _DBacess;
        public ArtikelVerwaltung(DBAcess acess)
        {
            _DBacess = acess;
            Download();
        }
        public void Download()
        {
            string query = "select * from artikel;";
            ArtikelListe = new List<Artikel>();

            var tabel = _DBacess.Return(query);
            foreach (var row in tabel)
            {
                var Artikel = new Artikel();
                Artikel.ArtikelID = Convert.ToInt32(row[0]);
                Artikel.Name = row[1];
                Artikel.Beschreibung = row[2];
                Artikel.Kategorie = (Kategorie)Enum.Parse(typeof(Kategorie), row[3]);
                Artikel.Einheit = (Einheit)Enum.Parse(typeof(Einheit), row[4]);
                Artikel.Preis = Convert.ToDecimal(row[5]);
                ArtikelListe.Add(Artikel);
            }
        }
        public bool SuchenName(string name)
        {
            string query = $"select * from artikel where art_name = '{name}';";
            //ArtikelListe.Clear();
            var row = _DBacess.Return(query)[0];
            if (row[0] != null)
            {
                var Artikel = new Artikel();
                Artikel.ArtikelID = Convert.ToInt32(row[0]);
                Artikel.Name = row[1];
                Artikel.Beschreibung = row[2];
                Artikel.Kategorie = (Kategorie)Enum.Parse(typeof(Kategorie), row[3]);
                Artikel.Einheit = (Einheit)Enum.Parse(typeof(Einheit), row[4]);
                Artikel.Preis = Convert.ToDecimal(row[5]);
                ArtikelListe.Add(Artikel); return true;
            }
            return false;
        }
        public bool Upload(Artikel artikel)
        {
            string query = $"INSERT INTO artikel(art_name, besch, kat_id, einheit, preis) VALUES('{artikel.Name}', '{artikel.Beschreibung}', '{Convert.ToInt32(artikel.Kategorie)}', '{artikel.Einheit}', {artikel.Preis});";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        bool Loeschen(Artikel artikel)
        {
            string query = @$"DELETE FROM `artikel` WHERE `art_id` = {artikel.ArtikelID};";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        bool Update(Artikel artikel)
        {
            string query = @$"UPDATE `artikel` SET `art_name` = '{artikel.Name}', `besch` = '{artikel.Beschreibung}', `kat_id` = {((int)artikel.Kategorie)}, `einheit` = '{artikel.Einheit}', `preis` = {artikel.Preis} WHERE `art_id` = {artikel.ArtikelID};";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        public void Submit(List<int> neu, List<int> alt)
        {
            foreach (var num in neu)
            {
                Upload(ArtikelListe[num]);
            }

            foreach (var num in alt)
            {
                Update(ArtikelListe[num]);
            }
        }
    }
}