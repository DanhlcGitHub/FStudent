//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIDEMO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SectionSubTemplate
    {
        public SectionSubTemplate()
        {
            this.TranscriptMarkEntries = new HashSet<TranscriptMarkEntry>();
        }
    
        public int ID { get; set; }
        public string SectionID { get; set; }
        public string MarkTitle { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual ICollection<TranscriptMarkEntry> TranscriptMarkEntries { get; set; }
    }
}
