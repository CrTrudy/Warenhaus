namespace WarenhausForms6
{
    internal interface IAccount
    {
        static Adresse Adresse;
        void AdresseHolen(string email);
        void BenutzernameAender(string neu);
        void PasswortAender(string neu);
        DBAcess Zugriff();

    }
}