namespace Warenhaus
{
    class KundenAccount : IAccount
    {
        public string Benutzername;
        public KundenAccount(string name)
        {
            Benutzername = name;
        }
        public void BenutzernameAender(string neu)
        {

        }
        public void PasswortAender(string neu)
        {

        }
    }
}