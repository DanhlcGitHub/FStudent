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
    
    public partial class TranscriptMarkEntry
    {
        public int EntryID { get; set; }
        public int TranscriptID { get; set; }
        public Nullable<int> SectionTemplateID { get; set; }
        public Nullable<decimal> Grade { get; set; }
    
        public virtual SectionSubTemplate SectionSubTemplate { get; set; }
        public virtual StudentTranscript StudentTranscript { get; set; }
    }
}
