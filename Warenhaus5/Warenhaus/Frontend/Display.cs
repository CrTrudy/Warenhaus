namespace Warenhaus
{
    class Display
    {
        MenuLogin _login;
        MenuBestand _bestand;
        DBAcess _dBAcess;

        public Display(DBAcess acess, int left, int top)
        {
            _dBAcess = acess;
            _login = new MenuLogin(left, top);
        }
        public bool Start()
        {
            var account = _login.Start();
            if (!account)
            {
                Console.WriteLine("Bitte verlassen Sie den Arbeitsplatz!");
                return false;
            }
            return true;
        }
        void Mitarbeiterzugang(MitarbeiterAccount acc)
        {
            
        }
        void Kundenzugang(KundenAccount acc)
        {

        }

    }
}