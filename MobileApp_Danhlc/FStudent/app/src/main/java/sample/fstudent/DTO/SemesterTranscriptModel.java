package sample.fstudent.DTO;

import java.util.List;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SemesterTranscriptModel {

    @SerializedName("semesterID")
    @Expose
    private Integer semesterID;
    @SerializedName("semesterName")
    @Expose
    private String semesterName;
    @SerializedName("credit")
    @Expose
    private Integer credit;
    @SerializedName("GPA")
    @Expose
    private Double gPA;
    @SerializedName("sectionTranscriptModel")
    @Expose
    private List<SectionTranscriptModel> sectionTranscriptModel = null;

    public Integer getSemesterID() {
        return semesterID;
    }

    public void setSemesterID(Integer semesterID) {
        this.semesterID = semesterID;
    }

    public String getSemesterName() {
        return semesterName;
    }

    public void setSemesterName(String semesterName) {
        this.semesterName = semesterName;
    }

    public Integer getCredit() {
        return credit;
    }

    public void setCredit(Integer credit) {
        this.credit = credit;
    }

    public Double getGPA() {
        return gPA;
    }

    public void setGPA(Double gPA) {
        this.gPA = gPA;
    }

    public List<SectionTranscriptModel> getSectionTranscriptModel() {
        return sectionTranscriptModel;
    }

    public void setSectionTranscriptModel(List<SectionTranscriptModel> sectionTranscriptModel) {
        this.sectionTranscriptModel = sectionTranscriptModel;
    }

}