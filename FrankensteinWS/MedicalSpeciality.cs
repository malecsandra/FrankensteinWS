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
    
    public partial class MedicalSpeciality
    {
        public MedicalSpeciality()
        {
            this.Doctors = new HashSet<Doctor>();
        }
    
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
    
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}