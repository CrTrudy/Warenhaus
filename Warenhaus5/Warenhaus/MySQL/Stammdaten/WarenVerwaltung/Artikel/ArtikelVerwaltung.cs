
namespace Warenhaus
{
    class ArtikelVerwaltung
    {
        public List<Artikel> ArtikelListe = new List<Artikel>();
        DBAcess _DBacess;
        public ArtikelVerwaltung(DBAcess acess)
        {
            _DBacess = acess;
            ArtikelLaden();
        }
        public void ArtikelLaden()
        { 
            string query = "select * from artikel;";
            ArtikelListe.Clear();
            var tabel = _DBacess.Return(query);
            foreach(var row in tabel)
            {
                ArtikelListe.Add(new Artikel(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), Convert.ToDecimal(row[5])));
            }
            
        }
        public Artikel ArtikelSuchenName(string name)
        {
            string query = $"select * from artikel where art_name = '{name}';";
            ArtikelListe.Clear();
            var tabel = _DBacess.Return(query);
            return new Artikel(Convert.ToInt32(tabel[0][0]), tabel[0][1].ToString(), tabel[0][2].ToString(), tabel[0][3].ToString(), tabel[0][4].ToString(), Convert.ToDecimal(tabel[0][5]));
        }
        public bool ArtikelAnlegen(string name, string beschreibung, int kat, string einheit, decimal preis)
        {
            string query = $"INSERT INTO artikel(art_name, besch, kat_id, einheit, preis) VALUES('{name}', '{beschreibung}', {kat}, '{einheit}', {preis});";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        public bool ArtikelLoeschen(int artikelID)
        {
            string query = @$"DELETE FROM `artikel` WHERE `art_id` = {artikelID};";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        public bool ArtikelAktualisieren(int artikelID, string name, string besch, string kat, int einheit, decimal preis)
        {
            string query = @$"UPDATE `artikel` SET `art_name` = '{name}', `besch` = '{besch}', `kat_id` = '{kat}', `einheit` = '{einheit}', 'preis' = {preis} WHERE `art_id` = {artikelID};";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }      
    }
}