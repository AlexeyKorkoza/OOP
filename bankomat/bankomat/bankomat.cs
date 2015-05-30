using System.Collections.Generic;
using System.Linq;

namespace Cassetes
{
    public class Bankomat
    {
        private List<Cassetes> _list = new List<Cassetes>(); 
        private int _min = int.MaxValue;
        public List<int> Withdraw(int m,string path)
        {
            if (m > TotalSum || m < _min)
            {
                return new List<int>();
            }
            var money = GiveMoney.Calculation(_list, m, _min);
            IWriter writer;
            var maStrings = path.Split('.');
            if (maStrings[1] == "json")
            {
                writer = new JsonWriter();
                writer.Write(_list,path);
            }
            if (maStrings[1] == "txt")
            {
                writer = new TxtWriter();
                writer.Write(_list, path);
            }
            if (maStrings[1] == "xml")
            {
                writer = new XmlWriter();
                writer.Write(_list, path);
            }
            if (maStrings[1] == "csv")
            {
                writer = new CsvWriter();
                writer.Write(_list, path);
            }
            
            return money;
        }
        public void InputCassettes(List<Cassetes> data)
        {
            _list = data;
            foreach (var item in _list.Where(item => item.Nominal < _min))
            {
                _min = item.Nominal;
            }
        }

        public void DeleteCassetes()
        {
            _list = new List<Cassetes>();
        }

        public int TotalSum
        {
            get
            {
                return _list.Sum(cassetese => cassetese.Nominal*cassetese.Count);
            }
        }
    }
}