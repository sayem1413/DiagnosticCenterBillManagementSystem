using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class PatientTestRequestManager
    {
        PatientTestRequestGateway patientTestRequestGateway = new PatientTestRequestGateway();

        public bool IsPatientExist(PatientTestRequest patient)
        {
            int countPatient = patientTestRequestGateway.GetPatientByMobile(patient.ContactNumber);
            if (countPatient != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SavePatient(PatientTestRequest patientInfo)
        {
            return patientTestRequestGateway.SavePatient(patientInfo);
        }
        public int SavePatientTest(PatientTestRequest testpatientTest, TestDetails testDetails)
        {
            return patientTestRequestGateway.SavePatientTest(testpatientTest, testDetails);
        }


    }
}