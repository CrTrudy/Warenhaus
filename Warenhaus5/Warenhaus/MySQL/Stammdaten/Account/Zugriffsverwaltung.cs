namespace Warenhaus
{
    static class Zugriffsverwaltung
    {
        public static bool AccountZugriff(DBAcess acess, int berechtigung, string name, string pswd)
        {
                                                            //berechtigung = kunde oder mitarbeiter
            string[,] wer = { {"kd_name", "kunde", "kd_pswd"},{"mi_name", "mitarbeiter" ,"mi_pswd"} };
            var tabel = acess.Return($"select count({wer[berechtigung,0]}) from {wer[berechtigung, 1]} where {wer[berechtigung, 0]} = '{name}' and {wer[berechtigung,2]} = '{pswd}';");
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