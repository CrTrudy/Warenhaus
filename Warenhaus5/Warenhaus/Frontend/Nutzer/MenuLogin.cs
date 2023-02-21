namespace Warenhaus
{
    class MenuLogin
    {
        Menu _menu;
        MenuBearbeiten _menuBearbeiten;
        DBAcess _dBAcess;
        int _left;
        int _top;
        public MenuLogin(int left, int top)
        {
            _dBAcess = new DBAcess("root", "");
            _left = left;
            _top = top;
        }
        public bool Start()
        {
            var x = Berechtigung();
            for (int i = 0; i < 3; i++)
            {

                return Einloggen(x);
                
            }
            return false;
        }
        int Berechtigung()
        {
            string titel = "Login";
            string[] anmeldung = { "Kunde", "Mitarbeiter"};
            _menu = new Menu(titel, anmeldung, _left, _top);
            return _menu.Run();
        }
        bool Einloggen(int a)
        {
            Console.Clear();
            string titel = "Login";
            string[] anmeldung = { "Name", "Passwort", "Bestätigen" };
            _menuBearbeiten = new MenuBearbeiten(titel, anmeldung, _left, _top);
            string[] login = _menuBearbeiten.Run();
            Console.Clear();
            var account = Zugriffsverwaltung.AccountZugriff(_dBAcess, a, login[0], SHA1.GetSha1(login[1]));
            if (account)
            {
                return account;
            }
            if(!account)
            {
                Console.WriteLine("Versuche es erneut");
                /////////////////////////////////////////////////////////
                Einloggen(a);
            }
           return false;
        }
        
    }
}