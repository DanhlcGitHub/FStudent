

namespace FAdmin.DTO
{
    public class Section
    {
        public string SectionNo { get; set; }
        public int SeatingCapacity { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string ProfessorCode { get; set; }
        public string RepresentedSubject { get; set; }
        public int SemesterBelong { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-25} {1,-50}\n", SectionNo, SeatingCapacity);
        }
    }
}
