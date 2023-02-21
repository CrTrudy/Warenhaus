namespace WarenhausForms6
{
    static class Zugriffsverwaltung
    {
        public static bool AccountZugriff(DBAcess acess, bool berechtigung, string name, string pswd)
        {
            string[] wer;
            if(berechtigung)
            {
                wer = new string[]{ "mi_email", "mitarbeiter", "mi_pswd" };
            }
            else
            {
                wer = new string[]{ "kd_email", "kunde", "kd_pswd" };
            }
            var tabel = acess.Return($"select count({wer[0]}) from {wer[1]} where {wer[0]} = '{name}' and {wer[2]} = '{pswd}';");
            
            if(tabel == null)
            { 
                return false;
            }
            if (Convert.ToInt32(tabel[0][0]) == 1)
            {
                return true; 
            }
            return false;   
        }
    }
}