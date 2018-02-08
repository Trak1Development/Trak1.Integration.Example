using System;
using System.Collections.Generic;

namespace Trak1.Integration.Example.Containers
{
    public class ApplicantInformation
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IgnoreDuplicates { get; set; }
        public Dictionary<string, string> RequiredFields { get; set; } = new Dictionary<string, string>();
        public string Gender { get; internal set; }
        public string Suffix { get; internal set; }
        public string Title { get; internal set; }
    }
}