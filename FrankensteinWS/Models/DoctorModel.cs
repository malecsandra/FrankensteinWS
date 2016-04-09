using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecialityId { get; set; }
        public int LocationId { get; set; }
        public string Stamp { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public SpecialityModel SpecialityModel { get; set; }

        public ClinicModel ClinicModel { get; set; }
    }
}