
namespace WarenhausForms6
{
    class BestandVerwalten
    {
        public List<Bestand> BestandListe;
        public List<Bestellung> BestellungListe;
        public List<Warenkorb> WarenkorbListe;
        DBAcess _dBacess;
        public BestandVerwalten(DBAcess acess)
        {
            _dBacess = acess;
            BestellungListe = new List<Bestellung>();
            BestandListe = new List<Bestand>();
            WarenkorbListe = new List<Warenkorb>();
        }
        public void Angebot()
        {
            BestandListe = new List<Bestand>();
            var tabel = _dBacess.Return("select * from v_aktueller_bestand;");
            foreach (var row in tabel)
            {
                var bestand = new Bestand();
                bestand.LagerName = row[0];
                bestand.ArtikelName = row[1];
                bestand.Anzahl = Convert.ToInt32(row[2]);
                BestandListe.Add(bestand);
            }
        }
        public void Bestellungen(string status)
        {
            BestellungListe = new List<Bestellung>();
            var tabel = _dBacess.Return($"select * from v_aktuelle_be where status = '{status}';");
            foreach (var row in tabel)
            {
                var bestellung = new Bestellung();
                bestellung.BestellID = Convert.ToInt32(row[1]);
                bestellung.E_mail = row[0];
                bestellung.Status = (Status)Enum.Parse(typeof(Status), row[2]);
                bestellung.Datum = Convert.ToDateTime(row[3]);
                BestellungListe.Add(bestellung);
            }
        }
        public void Warenkorb(Bestellung bestellung)
        {
            WarenkorbListe = new List<Warenkorb>();
            var tabel = _dBacess.Return($"select name, count(name) as anzahl, einheit, preis as 'stk preis', preis * count(name) as preis from v_be_art where be_id = {bestellung.BestellID} group by name;");
            foreach (var row in tabel)
            {
                var korb = new Warenkorb();
                korb.ArtikelName = row[0];
                korb.Anzahl = Convert.ToInt32(row[1]);
                korb.Einheit = (Einheit)Enum.Parse(typeof(Einheit), row[2]);
                korb.StkPreis = Convert.ToInt32(row[3]);
                korb.Preis = Convert.ToInt32(row[4]);
                WarenkorbListe.Add(korb);
            }
        }

    }
}