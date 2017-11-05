namespace FStudentWeb.DTO
{
    public class TranscriptMarkEntry
    {
        public int EntryID { get; set; }
        public int TranscriptID { get; set; }
        public int SubjectTeamplateID { get; set; }
        public decimal Grade { get; set; }
    }
}
