namespace Warenhaus
{
    class MenuBearbeiten
    {
        string _titel;
        string[] _optionen;
        int _selectedIndex;
        string[] _eingaben;
        int _absLinks;
        int _absOben;
        int _laenge;
        public MenuBearbeiten(string titel, string[] optionen, int absLinks, int absOben)
        {
            _optionen = optionen;
            _titel = titel;
            _absLinks = absLinks;
            _absOben = absOben;
            _laenge = optionen.Length;
            _eingaben = new string[_laenge];
        }
        void OptionenAnzeigen()
        {
            for (int i = 0; i < _laenge; i++)
            {
                Console.SetCursorPosition(_absLinks, _absOben + i);
                string aktuelleOption = _optionen[i];
                string aktuelleEingabe = _eingaben[i];
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (_laenge - 1 == i)
                {
                    Console.SetCursorPosition(_absLinks + 6, _absOben + i + 1);
                    Console.WriteLine($"{aktuelleOption}");
                }
                else
                {
                    Console.SetCursorPosition(_absLinks, _absOben + i);
                    Console.WriteLine($"{aktuelleOption}: ");
                    Console.ResetColor();
                    Console.SetCursorPosition(_absLinks + 13, _absOben + i);
                    Console.WriteLine($"{aktuelleEingabe}");
                }
                Console.ResetColor();
            }
        }
        public string[] Run()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_absLinks + 5, _absOben - 5);
            Console.WriteLine(_titel + "\n\n\n");
            ConsoleKey keyPressed;
            do
            {
                OptionenAnzeigen();
                ConsoleKeyInfo keyInfo = Console.ReadKey(false);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _optionen.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _optionen.Length)
                    {
                        _selectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    Eingabe();
                }

            } while (keyPressed != ConsoleKey.Enter | _selectedIndex != _laenge - 1);
            return _eingaben;
        }

        void Eingabe()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(_absLinks + 13, _absOben + _selectedIndex);
            _eingaben[_selectedIndex] = Console.ReadLine().ToString();
            Console.CursorVisible = false;
        }
    }
}