using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cassetes
{
    [Serializable]
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

        public void Serialize(string path)
        {
            Stream testFileStream = File.Create(path);
            var serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, this);
            testFileStream.Close();
        }

        public static Bankomat Deserialize(string path)
        {
            Stream stream = Stream.Null;
            try
            {
                stream = File.OpenRead(path);
                var deserializer = new BinaryFormatter();
                var cashMachine = (Bankomat)deserializer.Deserialize(stream);
                stream.Close();
                return cashMachine;
            }
            catch (Exception)
            {
                stream.Close();
                return null;
            }
            

        }
    }
}