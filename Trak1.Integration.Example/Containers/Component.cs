using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trak1.Integration.Example.Containers
{
    public class Component
    {
        public string ComponentName { get; set; }
        public string ComponentDescription { get; set; }
        public List<Field> RequiredFields { get; set; }
    }
}
