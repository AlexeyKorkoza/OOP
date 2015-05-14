using System.Collections.Generic;
using System.Linq;

namespace Cassetes
{
    public class Bankomat
    {
        private List<Cassetes> _list = new List<Cassetes>(); 
        private int _min = int.MaxValue;
        public List<int> Money(int m)
        {
            if (m > TotalSum || m < _min)
            {
                return new List<int>();
            }
            //TODO: сделать проверку соответствия выдаваемой суммы и требуемой
            var dengi = GiveMoney.Calculation(_list, m, _min);
            IWriter writer = new CsvWriter();
            writer.Write(_list);
            return dengi;
        }
        public void InputCassettes(List<Cassetes> data)
        {
            _list = data;
            foreach (var item in _list)
            {
                if (item.Nominal < _min)
                {
                    _min = item.Nominal;
                }
            }
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