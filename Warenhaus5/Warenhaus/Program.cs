namespace Warenhaus
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int left = 30;
            int top = 10;
            DBAcess _dBAcess = new DBAcess("root", "");
            Display _display = new Display(_dBAcess, left, top);

            if(_display.Start())
            {
                MitarbeiterDisplay miDisplay = new MitarbeiterDisplay(_dBAcess, left, top);
            }





            Console.ReadLine();

        }
    }
    class KundenDisplay
    {

        public KundenDisplay()
        {

        }
    }
}