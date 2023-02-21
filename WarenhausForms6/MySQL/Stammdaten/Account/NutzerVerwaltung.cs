using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenhausForms6.MySQL.Stammdaten.Account
{
    internal class NutzerVerwaltung
    {
        protected DBAcess _DBacess;


        List<Adresse> _mitarbeiterListe = new List<Adresse>();
        public List<Adresse> MitarbeiterListe { get => _mitarbeiterListe; }
        
        
        List<Adresse> _kundenListe = new List<Adresse>();
        public List<Adresse> KundenListe { get => _kundenListe; }
        
        
        public NutzerVerwaltung(DBAcess acess)
        {
            _DBacess = acess;
        }
        public void MitarbeiterLaden()
        {
            _mitarbeiterListe = new List<Adresse>();
            string query = "select mi_id, mi_name, mi_nach_name, mi_email from mitarbeiter;";
            var tabel = _DBacess.Return(query);
            foreach (var row in tabel)
            {
                var adr = new Adresse();
                adr.ID = Convert.ToInt32(row[0]);
                adr.VorName = row[1].ToString();
                adr.NachName = row[2].ToString();
                adr.Email = row[3].ToString();
                _mitarbeiterListe.Add(adr);
            }
        }
        public void NeuerMi(string name, string na_name, string pswd, string email)
        {
            var adr = new Adresse();
            string query = $"call p_neu_mi('{name}', '{na_name}', '{pswd}', '{email});";

        }
        public void KundenLaden()
        {
            string query = "select kd_id, kd_name, kd_nach_name, kd_email from kunde;";
            _kundenListe = new List<Adresse>();
            var tabel = _DBacess.Return(query);
            foreach (var row in tabel)
            {
                var adr = new Adresse();
                adr.ID = Convert.ToInt32(row[0]);
                adr.VorName = row[1].ToString();
                adr.NachName = row[2].ToString();
                adr.Email = row[3].ToString();
                _kundenListe.Add(adr);
            }
        }
    }
}
