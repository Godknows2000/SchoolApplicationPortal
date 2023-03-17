using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string CountryOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinNumber { get; set; }
        public string SubjectCategory { get; set; }
        public string Combination { get; set; }
        public string Intake { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Disability { get; set; }
        public string Sponsor { get; set; }
        public string BirthFile { get; set; }
        public string ResultsFile { get; set; }
        public string ReferenceFile { get; set; }
    }
}
