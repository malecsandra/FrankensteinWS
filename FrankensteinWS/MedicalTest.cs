//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrankensteinWS
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalTest
    {
        public int MedicalTestId { get; set; }
        public int AppointmentId { get; set; }
        public Nullable<System.DateTime> MedicalTestDate { get; set; }
        public int TestId { get; set; }
        public string Result { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        public virtual Test Test { get; set; }
    }
}
