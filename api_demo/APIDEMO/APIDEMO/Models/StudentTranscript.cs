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
    
    public partial class StudentTranscript
    {
        public StudentTranscript()
        {
            this.TranscriptAttendaceEntries = new HashSet<TranscriptAttendaceEntry>();
            this.TranscriptMarkEntries = new HashSet<TranscriptMarkEntry>();
        }
    
        public int TranscriptID { get; set; }
        public string StudentCode { get; set; }
        public string SectionID { get; set; }
        public Nullable<float> AverageGrade { get; set; }
        public string LearningStatus { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<TranscriptAttendaceEntry> TranscriptAttendaceEntries { get; set; }
        public virtual ICollection<TranscriptMarkEntry> TranscriptMarkEntries { get; set; }
    }
}
