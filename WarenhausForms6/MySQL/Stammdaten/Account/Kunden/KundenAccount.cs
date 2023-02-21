namespace WarenhausForms6
{
    class KundenAccount : IAccount
    {
        Adresse _adresse;
        public Adresse Adresse { get => _adresse;  }


        DBAcess _acess;

        public KundenAccount(string email)
        {
            _acess = new DBAcess("root", "");
            AdresseHolen(email);
        }
        public void AdresseHolen(string email)
        {
            string query = $"select * from mitarbeiter where mi_email = '{email}'";
            _adresse = new Adresse();
            var adresse = _acess.Return(query)[0];

            _adresse.ID = Convert.ToInt32(adresse[0]);
            _adresse.VorName = adresse[1].ToString();
            _adresse.NachName = adresse[2].ToString();
            _adresse.Email = adresse[4].ToString();

        }
        public void BenutzernameAender(string neu)
        {

        }
        public void PasswortAender(string neu)
        {

        }
        public DBAcess Zugriff()
        {
            return _acess;
        }
    }
}