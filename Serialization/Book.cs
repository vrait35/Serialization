using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    [MyCustomAttribute(SomeProperty = "Рефлекции нету")]
    public class Book
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
    }
}
