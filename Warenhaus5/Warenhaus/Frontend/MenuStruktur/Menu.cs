namespace Warenhaus
{
    class Menu
    {
        string _titel;
        string[] _optionen;
        int _selectedIndex;
        int _absLinks;
        int _absOben;
        public Menu(string titel, string[] optionen, int absLinks, int absOben)
        {
            _optionen = optionen;
            _titel = titel;
            _absLinks = absLinks;
            _absOben = absOben;
        }
        void OptionenAnzeigen()
        {
            for (int i = 0; i < _optionen.Length; i++)
            {
                Console.SetCursorPosition(_absLinks, _absOben + i);
                string aktuelleOption = _optionen[i];
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
                Console.WriteLine($" << {aktuelleOption} >> ");
                Console.ResetColor();
            }
        }
        public int Run()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_absLinks, _absOben - 5);
            Console.WriteLine(_titel + "\n\n\n");
            ConsoleKey keyPressed;
            do
            {
                OptionenAnzeigen();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
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
            } while (keyPressed != ConsoleKey.Enter);
            return _selectedIndex;
        }
    }
}