using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class AppointmentTestSet
    {
        public int AppointmentId { get; set; }
        public System.DateTime MedicalTestDate { get; set; }

        public string Doctor { get; set; }
        public string Speciality { get; set; }

        public List<MedicalTestModel> TestList { get; set; }
    }
}