using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak1.Integration.Example.Containers
{
    public class ReportUrlResponse
    {
        public string RequestValidation { get; set; }
        public string ReportUrl { get; set; }
        public string HitColor { get; set; }
        public Guid TransactionId { get; set; }

    }
}
