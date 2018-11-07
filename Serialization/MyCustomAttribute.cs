using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class MyCustomAttribute:System.Attribute
    {
        public string SomeProperty { get; set; }
    }
}
