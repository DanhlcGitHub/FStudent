package sample.fstudent.Utility;

import java.util.List;

/**
 * Created by gmtco on 10/27/2017.
 */

public class SemesterTranscriptModel {
    int semesterID;
    String semesterName;
    int credit;
    double GPA;
    private List<SectionTranscriptModel> sectionTranscriptModelList;

    public SemesterTranscriptModel(int semesterID, String semesterName, int credit, double GPA, List<SectionTranscriptModel> sectionTranscriptModelList) {
        this.semesterID = semesterID;
        this.semesterName = semesterName;
        this.credit = credit;
        this.GPA = GPA;
        this.sectionTranscriptModelList = sectionTranscriptModelList;
    }

    public int getSemesterID() {
        return semesterID;
    }

    public void setSemesterID(int semesterID) {
        this.semesterID = semesterID;
    }

    public String getSemesterName() {
        return semesterName;
    }

    public void setSemesterName(String semesterName) {
        this.semesterName = semesterName;
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

    public List<SectionTranscriptModel> getSectionTranscriptModelList() {
        return sectionTranscriptModelList;
    }

    public void setSectionTranscriptModelList(List<SectionTranscriptModel> sectionTranscriptModelList) {
        this.sectionTranscriptModelList = sectionTranscriptModelList;
    }
}
