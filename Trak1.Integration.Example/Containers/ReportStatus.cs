using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak1.Integration.Example.Containers
{
    public class ReportStatusResponse
    {
        public string RequestValidation { get; set; }
        public string ReportStatus { get; set; }
        public string HitColor { get; set; }
        public string Recomendation { get; set; }
        public string Decision { get; set; }
        public DateTime ReportLastUpdate { get; set; }
        public Guid TransactionId { get; set; }
    }
}
