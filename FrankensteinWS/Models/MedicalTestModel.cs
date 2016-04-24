using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class MedicalTestModel
    {
        public int MedicalTestId { get; set; }
        public int AppointmentId { get; set; }

        public string Result { get; set; }

        public string TestName { get; set; }
        public string CategoryName { get; set; }
        public Nullable<decimal> MinValue { get; set; }
        public Nullable<decimal> MaxValue { get; set; }
        public string UnitMeasure { get; set; }
    }
}