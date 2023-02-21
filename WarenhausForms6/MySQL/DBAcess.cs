using MySql.Data.MySqlClient;
using System.Data;

namespace WarenhausForms6
{
    class DBAcess
    {
        MySqlConnection _conn;
        MySqlCommand _cmd;
        MySqlDataReader _DbReader;
        MySqlTransaction _DbTran;
        string _connectionString;
        List<List<string>> _list;


        public DBAcess(string user, string password)
        {
            _connectionString = "SERVER=" + "localhost" + ";"
                                + "DATABASE=" + "gemuese_laden" + ";"
                                + "UID=" + user + ";"
                                + "PASSWORD=" + password + ";";
            _conn = new MySqlConnection(_connectionString);
        }
        bool OpenConnection()
        {
            if( _conn.State == ConnectionState.Open) { _conn.Close(); }
            if(_conn.State != ConnectionState.Open) { _conn.Open(); }
            if (_conn.State == ConnectionState.Open) { return true; }
            return false;
        }
        bool CloseConnection()
        {
            //_DbReader.Close();
            if (_conn.State != ConnectionState.Closed) { _conn.Close(); }
            if (_conn.State == ConnectionState.Closed) { return true; }
            return false;
        }
        void Reader(string query)
        {

            _DbTran = _conn.BeginTransaction();
            _cmd = new MySqlCommand(query, _conn);
            _DbReader = _cmd.ExecuteReader();
            Feld();

        }
        void Transact(string query)
        {
            try
            {
                _DbTran = _conn.BeginTransaction();
                _cmd = new MySqlCommand(query, _conn);
                _cmd.ExecuteNonQuery();
                _DbTran.Commit();
                _DbTran.Dispose();
            }
            catch
            {
                _DbTran.Rollback();
            }
        }
        void Feld()
        {
            _list = new List<List<string>>();
            while (_DbReader.Read())
            {
                List<string> list2 = new List<string>();
                for (int i = 0; i < _DbReader.FieldCount; i++)
                {
                    list2.Add(_DbReader.GetString(i));
                }
                _list.Add(list2);
            }
        }






        public bool Act(string query)
        {
            if (!OpenConnection()) 
            {
                return false;
            }
            Transact(query); 
            CloseConnection();
            return true;
        }


        public List<List<string>> Return(string query)
        {
            if (!OpenConnection()) 
            { 
                return null; 
            }
            Reader(query);
            CloseConnection();
            return _list;
        }
    }
}