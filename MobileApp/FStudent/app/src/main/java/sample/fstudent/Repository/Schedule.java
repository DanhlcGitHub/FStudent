package sample.fstudent.Repository;

import java.util.Date;

/**
 * Created by gmtco on 10/5/2017.
 */

public class Schedule {
    private int SemesterID ;
    private Date StartDate ;
    private Date EndDate ;
    private String SemesterName ;

    public Schedule(Date startDate, Date endDate, String semesterName) {
        StartDate = startDate;
        EndDate = endDate;
        SemesterName = semesterName;
    }

    public int getSemesterID() {
        return SemesterID;
    }

    public void setSemesterID(int semesterID) {
        SemesterID = semesterID;
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

    public String getSemesterName() {
        return SemesterName;
    }

    public void setSemesterName(String semesterName) {
        SemesterName = semesterName;
    }
}
