namespace FAdmin.DTO
{
    public class StudentTranscript
    {
        public int TranscriptID { get; set; }
        public string StudentCode { get; set; }
        public string SectionID { get; set; }
        public double AverageGrade { get; set; }
        public string LearningStatus { get; set; }
    }
}
