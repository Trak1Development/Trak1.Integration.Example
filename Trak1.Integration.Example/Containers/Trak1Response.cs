using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trak1.Integration.Example.Containers
{
    [DataContract]
    public class Trak1Response
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid TransactionId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string RedirectUrl { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ErrorInformation Error { get; set; }
    }
}
