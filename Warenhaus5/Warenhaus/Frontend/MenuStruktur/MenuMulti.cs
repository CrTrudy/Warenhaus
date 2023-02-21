namespace Warenhaus
{
    class MenuMulti
    {
        string _titel;
        string[] _optionen;
        string[] _optionen2;
        int _selectedIndex;
        int _selectedIndex2;
        int _absLinks;
        int _absOben;
        public MenuMulti(string titel, string[] optionen, string[] optionn2 ,int absLinks, int absOben)
        {
            _optionen = optionen;
            _optionen2 = optionn2;
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
                if (_optionen.Length - 1 == i)
                {
                    Console.SetCursorPosition(_absLinks + 6, _absOben + i + 1);
                    Console.WriteLine($"{aktuelleOption} ");
                }
                else
                {
                    Console.SetCursorPosition(_absLinks, _absOben + i);
                    Console.WriteLine($"{aktuelleOption} ");
                    Console.ResetColor();
                    for (int j = 0; j < _optionen2.Length; j++)
                    {
                        if (_selectedIndex == i)
                        {
                            Console.SetCursorPosition(_absLinks + 13 * (j + 1), _absOben + i); 
                            if (_selectedIndex2 == j)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write(">");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            Console.WriteLine($"{_optionen2[j]}");
                            Console.ResetColor();
                        }
                    }
                }
                    Console.ResetColor();
                }
            }
            public int[] Run()
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(_absLinks + 5, _absOben - 5);
                Console.WriteLine(_titel + "\n\n\n");
                ConsoleKey keyPressed;
                do
                {
                    Console.Clear();
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
                        _selectedIndex2 = 0;
                    }
                    else if (keyPressed == ConsoleKey.DownArrow)
                    {
                        _selectedIndex++;
                        if (_selectedIndex == _optionen.Length)
                        {
                            _selectedIndex = 0;
                        }
                        _selectedIndex2 = 0;
                    }
                    else if (keyPressed == ConsoleKey.RightArrow)
                    {
                        _selectedIndex2++;
                        if (_selectedIndex2 == _optionen2.Length)
                        {
                            _selectedIndex2 = 0;
                        }
                    }
                    else if (keyPressed == ConsoleKey.LeftArrow)
                    {
                        _selectedIndex2--;
                        if (_selectedIndex2 == -1)
                        {
                            _selectedIndex2 = _optionen2.Length - 1;
                        }
                    }

                } while (keyPressed != ConsoleKey.Enter);
                return new int[] { _selectedIndex, _selectedIndex2 };
            }

        }
    }
