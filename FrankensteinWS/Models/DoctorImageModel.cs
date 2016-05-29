using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class DoctorImageModel
    {
        public int DoctorId { get; set; }
        public byte[] Photo { get; set; }
    }
}