using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trak1.Integration.Example.Containers
{
    public class Package
    {
        public string PackageServiceNumber { get; set; }
        public string PackageName { get; set; }
        public string PackagePrice { get; set; }
        public string PackageDescription { get; set; }
        public string TierOrder { get; set; }
        public List<Component> Components { get; set; }

    }
}
