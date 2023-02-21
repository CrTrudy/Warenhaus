namespace Warenhaus
{
    class LagerVerwaltung 
    {
        public List<Lager> LagerListe = new List<Lager>();
        DBAcess _DBacess;
        public LagerVerwaltung(DBAcess acess)
        {
            _DBacess = acess;
        }
        public bool LagerLaden()
        {
            LagerListe.Clear();
            var tabel = _DBacess.Return("select * from lager;");
            if(tabel == null) { return false; }
            foreach(var row in tabel)
            {
                LagerListe.Add(new Lager(row[1].ToString(), Convert.ToInt32(row[0]), Convert.ToInt32(row[2])));
            }
            if (LagerListe[0] != null)
            {
                return true;
            }
            return false;
        }
        public bool LagerAnlegen(string name, int kap)
        {
            string query = @$"insert into lager(lag_name, kapazitaet) values('{name}', {kap});";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        public bool LagerLoeschen(int lagerID)
        {
            string query = @$"DELETE FROM lager WHERE (`lag_id` = {lagerID});";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;
        }
        public bool LagerAktualisieren(string name, int nummer, int kap)
        {
            string query = @$"UPDATE `artikel` SET `art_name` = '{name}', `kapazitaet` = '{kap}' WHERE `lag_id` = {nummer};";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;

        }
        public bool ArtikelInLager(int lag_id, int art_id, int anzahl)
        {
            string query = @$"call p_bestand_hinzu({lag_id}, {art_id}, {anzahl}";
            if (_DBacess.Act(query))
            {
                return true;
            }
            return false;

        }
    }
}