using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak1.Integration.Example.Containers
{
    public class Trak1Request
    {
        public SecurityInformation Authentication { get; set; }

        public ApplicantInformation Applicant { get; set; }

        public string PackageName { get; set; }

        public Guid TransactionId { get; set; }

        public Guid? AllowDuplicates { get; set; }

        public AdditionalFunctionality AdditionalFunctionality { get; set; }
        

    }
}
