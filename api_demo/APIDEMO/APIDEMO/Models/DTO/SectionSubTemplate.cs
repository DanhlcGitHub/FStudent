using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDEMO.Models.DTO
{
    public class SectionSubTemplate
    {
        public int ID { get; set; }
        public string SectionID { get; set; }
        public string MarkTitle { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
    }
}