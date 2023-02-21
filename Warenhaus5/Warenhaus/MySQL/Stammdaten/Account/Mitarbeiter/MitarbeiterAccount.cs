namespace Warenhaus
{
    internal class MitarbeiterAccount : IAccount
    {
        // Attribute
        public readonly string Benutzername;
        DBAcess _acess;

        // Methode

        public MitarbeiterAccount(DBAcess acess, string name)
        {
            _acess = acess;
            Benutzername = name;
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