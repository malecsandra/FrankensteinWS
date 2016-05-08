using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class ScheduleModel
    {
        public int DoctorId { get; set; }
        public System.DateTime RequestDate { get; set; }
    }
}