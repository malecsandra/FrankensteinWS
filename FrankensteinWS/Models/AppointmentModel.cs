using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class AppointmentModel
    {

        public int AppointmentId { get; set; }
        public int PersonId { get; set; }
        public int DoctorId { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public int StatusId { get; set; }

        public string Doctor { get; set; }

        public string Speciality { get; set; }
        public string ClinicName { get; set; }

        public List<AppointmentDetailsModel> AppointmentDetailsList { get; set; } 
    }
}