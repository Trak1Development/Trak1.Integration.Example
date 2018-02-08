using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Trak1.Integration.Example.Containers;

namespace Trak1.Integration.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string subscriberCode = "test";
            string companyCode = "test2";
            string url = "https://stgapi.trak-1.com/T1MockServices";

            GetAvailablePackages(companyCode, subscriberCode, url);
            RunPackage(companyCode, subscriberCode, url);
            GetReportStatus(companyCode, subscriberCode, url);
            GetReportUrl(companyCode, subscriberCode, url);


            Console.ReadLine();
        }

        static void GetAvailablePackages(string companyCode, string subscriberCode, string url)
        {
            HttpClient client = new HttpClient();
            //Call GetAvailablePackages with GetAsync and use ReadAsAsync to Deserialize the results into our List of Packages.
            var packageList = client.GetAsync($"{url}/Integration/GetAvailablePackages/{subscriberCode}/{companyCode}").Result.Content.ReadAsAsync<List<Package>>().Result;
            //We can not iterate over the package and gather information about what is available to us.
            foreach (var package in packageList)
            {
                Console.WriteLine($"{package.PackageName}:{package.PackagePrice}");
                foreach(var component in package.Components)
                {
                    Console.WriteLine($"\t{component.ComponentName}");
                    foreach(var requiredField in component.RequiredFields)
                    {
                        Console.WriteLine($"\t\t{requiredField.Name}:{requiredField.Type}");
                    }
                }
            }
        }

        static void RunPackage(string companyCode, string subscriberCode, string url)
        {
            var request = new Trak1Request
            {
                Authentication = new SecurityInformation
                {
                    BranchName = "Branch Name goes here if none place Main",
                    CompanyCode = companyCode,
                    SubscriberCode = subscriberCode,
                    UserName = "Your User Name goes here"
                },
                Applicant = new ApplicantInformation
                {
                    SSN = "Applicant’s Social Security Number",
                    FirstName = "Applicant’s First Name",
                    MiddleName = "Applicant’s Middle Name",
                    LastName = "Applicant’s Last Name",
                    Email = "Applicant’s Email Address",
                    DateOfBirth = new DateTime(1900, 01, 01),
                    Address1 = "Applicant’s First Line of Address Information",
                    Address2 = "Applicant’s Second Line of Address Information",
                    City = "Applicant’s City",
                    State = "Applicant’s State Abbreviation (OK, TX, etc)",
                    Zip = "Applicant’s Zip Code",
                    Suffix = "Applicant’s Suffix",
                    Title = "Applicant’s Title",
                    RequiredFields = new Dictionary<string, string>(),
                },
                PackageName = "Sunscreen Verify", //We got this from GetAvailablePackages's PackageName
            };
            request.Applicant.RequiredFields["SPFValue"] = "60"; //We got this from GetAvailablePackages's Component's Required Field


            HttpClient client = new HttpClient();
            //Call GetAvailablePackages with GetAsync and use ReadAsAsync to Deserialize the results into our List of Packages.
            var response = client.PostAsJsonAsync<Trak1Request>($"{url}/Integration/RunPackage", request).Result.Content.ReadAsAsync<Trak1Response>().Result;
            //We can not iterate over the package and gather information about what is available to us.
            Console.WriteLine($"{response.TransactionId}");
        }

        static void GetReportStatus(string companyCode, string subscriberCode, string url)
        {
            string transactionId = "test3";
            HttpClient client = new HttpClient();
            //Call GetAvailablePackages with GetAsync and use ReadAsAsync to Deserialize the results into our List of Packages.
            var reportStatus = client.GetAsync($"{url}/Integration/GetReportStatus/{subscriberCode}/{companyCode}/{transactionId}").Result.Content.ReadAsAsync<ReportStatusResponse>().Result;
            //We can not iterate over the package and gather information about what is available to us.
            Console.WriteLine($"{reportStatus.ReportStatus}:{reportStatus.Recomendation}");
        }

        static void GetReportUrl(string companyCode, string subscriberCode, string url)
        {
            string transactionId = "test3";
            HttpClient client = new HttpClient();
            //Call GetAvailablePackages with GetAsync and use ReadAsAsync to Deserialize the results into our List of Packages.
            var reportUrl = client.GetAsync($"{url}/Integration/GetReportUrl/{subscriberCode}/{companyCode}/{transactionId}").Result.Content.ReadAsAsync<ReportUrlResponse>().Result;
            //We can not iterate over the package and gather information about what is available to us.
            Console.WriteLine($"{reportUrl.ReportUrl}");
        }
    }
}
