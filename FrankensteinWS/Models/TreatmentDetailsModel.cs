using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class TreatmentDetailsModel
    {
        public int TreatmentId { get; set; }
        public int AppointmentId { get; set; }
        public string DrugName { get; set; }
        public int Tablets { get; set; }
        public int Dose { get; set; }
        public int Periodicity { get; set; }
        public int PeriodicityType { get; set; }
    }
}