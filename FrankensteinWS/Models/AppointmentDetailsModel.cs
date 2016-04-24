using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class AppointmentDetailsModel
    {
        public int AppointmentDetailId { get; set; }
        public int AppointmentId { get; set; }

        public string Diagnostic { get; set; }

        public string Comments { get; set; }
        
    }
}