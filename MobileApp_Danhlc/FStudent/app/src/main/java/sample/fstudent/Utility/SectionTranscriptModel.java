package sample.fstudent.Utility;

import java.util.List;

/**
 * Created by gmtco on 10/27/2017.
 */

public class SectionTranscriptModel {
    String sectionID;
    String status;
    int credit;
    double GPA;

    public SectionTranscriptModel(String sectionID, String status, int credit, double GPA) {
        this.sectionID = sectionID;
        this.status = status;
        this.credit = credit;
        this.GPA = GPA;
    }

    public String getSectionID() {
        return sectionID;
    }

    public void setSectionID(String sectionID) {
        this.sectionID = sectionID;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public int getCredit() {
        return credit;
    }

    public void setCredit(int credit) {
        this.credit = credit;
    }

    public double getGPA() {
        return GPA;
    }

    public void setGPA(double GPA) {
        this.GPA = GPA;
    }
}
