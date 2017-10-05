package sample.fstudent.Repository;

import java.util.Date;

/**
 * Created by gmtco on 10/5/2017.
 */

public class Section {
    private String SectionNo ;
    private int SeatingCapacity ;
    private Date StartDate ;
    private Date EndDate ;
    private String ProfessorCode ;
    private String RepresentedSubject ;
    private int SemesterBelong ;

    public Section(String sectionNo, int seatingCapacity, Date startDate, Date endDate, String professorCode, String representedSubject, int semesterBelong) {
        SectionNo = sectionNo;
        SeatingCapacity = seatingCapacity;
        StartDate = startDate;
        EndDate = endDate;
        ProfessorCode = professorCode;
        RepresentedSubject = representedSubject;
        SemesterBelong = semesterBelong;
    }

    public String getSectionNo() {
        return SectionNo;
    }

    public void setSectionNo(String sectionNo) {
        SectionNo = sectionNo;
    }

    public int getSeatingCapacity() {
        return SeatingCapacity;
    }

    public void setSeatingCapacity(int seatingCapacity) {
        SeatingCapacity = seatingCapacity;
    }

    public Date getStartDate() {
        return StartDate;
    }

    public void setStartDate(Date startDate) {
        StartDate = startDate;
    }

    public Date getEndDate() {
        return EndDate;
    }

    public void setEndDate(Date endDate) {
        EndDate = endDate;
    }

    public String getProfessorCode() {
        return ProfessorCode;
    }

    public void setProfessorCode(String professorCode) {
        ProfessorCode = professorCode;
    }

    public String getRepresentedSubject() {
        return RepresentedSubject;
    }

    public void setRepresentedSubject(String representedSubject) {
        RepresentedSubject = representedSubject;
    }

    public int getSemesterBelong() {
        return SemesterBelong;
    }

    public void setSemesterBelong(int semesterBelong) {
        SemesterBelong = semesterBelong;
    }
}
