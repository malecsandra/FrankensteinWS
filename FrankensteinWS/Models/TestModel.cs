using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class TestModel
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public string UnitMeasure { get; set; }
    }
}