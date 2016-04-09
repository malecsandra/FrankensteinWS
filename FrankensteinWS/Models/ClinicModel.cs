using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class ClinicModel
    {
        public int LocationId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
    }
}