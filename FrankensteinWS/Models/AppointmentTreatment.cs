using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class AppointmentTreatment
    {
        public int AppointmentId { get; set; }
        public System.DateTime TreatmentDate { get; set; }
        public string Diagnostic { get; set; }
        public string Doctor { get; set; }
        public string Speciality { get; set; }

        public List<TreatmentDetailsModel> TreatmentList { get; set; }
    }
}