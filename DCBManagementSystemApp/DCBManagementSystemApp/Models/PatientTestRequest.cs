using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBManagementSystemApp.Models
{
    public class PatientTestRequest
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime PatientBirthDate { get; set; }

        public PatientTestRequest()
        {
            
        }
        

        public PatientTestRequest(string patientName, DateTime patientBirthDate, string contactNumber)
        {
            this.PatientName = patientName;
            this.PatientBirthDate = patientBirthDate;
            this.ContactNumber = contactNumber;
        }
        public PatientTestRequest(string patientName, string contactNumber)
        {
            this.PatientName = patientName;
            this.ContactNumber = contactNumber;
        }
    }
}