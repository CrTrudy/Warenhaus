using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenhausForms6.MySQL
{
    public class DataGridBearbeiten
    {
        List<int> _changeIndex = new List<int>();
        List<int> _newIndex = new List<int>();
        List<int> _delIndex = new List<int>();
        public void AddChange(int row)
        {
            _changeIndex.Add(row);
        }
        public void AddNew(int row)
        {
            _newIndex.Add(row);
        }
        public void AddDel(int row)
        {
            _delIndex.Add(row);
        }
        public List<int> GetChIndex()
        {
            return _changeIndex;
        }
        public List<int> GetNewIndex()
        {
            return _newIndex;
        }
        public List<int> GetDelIndex()
        {
            return _delIndex;
        }


    }
}
