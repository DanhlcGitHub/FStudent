namespace FAdmin.DTO
{
    public class SectionSchedule
    {
        public int SectionScheduleID { get; set; }
        public string SectionID { get; set; }
        public System.DateTime Date { get; set; }
        public int Slot { get; set; }
        public int Duration { get; set; }
        public string Room { get; set; }
    }
}
