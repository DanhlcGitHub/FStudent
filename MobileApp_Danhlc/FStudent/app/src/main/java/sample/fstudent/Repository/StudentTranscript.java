
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class StudentTranscript {

    @SerializedName("transcriptId")
    @Expose
    private Integer transcriptId;
    @SerializedName("studentCode")
    @Expose
    private String studentCode;
    @SerializedName("sectionId")
    @Expose
    private String sectionId;
    @SerializedName("averageGrade")
    @Expose
    private Integer averageGrade;
    @SerializedName("learningStatus")
    @Expose
    private String learningStatus;
    @SerializedName("section")
    @Expose
    private Section section;
    @SerializedName("studentCodeNavigation")
    @Expose
    private Student studentCodeNavigation;
    @SerializedName("transcriptAttendaceEntry")
    @Expose
    private List<TranscriptAttendaceEntry> transcriptAttendaceEntry = null;
    @SerializedName("transcriptMarkEntry")
    @Expose
    private List<TranscriptMarkEntry> transcriptMarkEntry = null;

    public Integer getTranscriptId() {
        return transcriptId;
    }

    public void setTranscriptId(Integer transcriptId) {
        this.transcriptId = transcriptId;
    }

    public String getStudentCode() {
        return studentCode;
    }

    public void setStudentCode(String studentCode) {
        this.studentCode = studentCode;
    }

    public String getSectionId() {
        return sectionId;
    }

    public void setSectionId(String sectionId) {
        this.sectionId = sectionId;
    }

    public Integer getAverageGrade() {
        return averageGrade;
    }

    public void setAverageGrade(Integer averageGrade) {
        this.averageGrade = averageGrade;
    }

    public String getLearningStatus() {
        return learningStatus;
    }

    public void setLearningStatus(String learningStatus) {
        this.learningStatus = learningStatus;
    }

    public Section getSection() {
        return section;
    }

    public void setSection(Section section) {
        this.section = section;
    }

    public Student getStudentCodeNavigation() {
        return studentCodeNavigation;
    }

    public void setStudentCodeNavigation(Student studentCodeNavigation) {
        this.studentCodeNavigation = studentCodeNavigation;
    }

    public List<TranscriptAttendaceEntry> getTranscriptAttendaceEntry() {
        return transcriptAttendaceEntry;
    }

    public void setTranscriptAttendaceEntry(List<TranscriptAttendaceEntry> transcriptAttendaceEntry) {
        this.transcriptAttendaceEntry = transcriptAttendaceEntry;
    }

    public List<TranscriptMarkEntry> getTranscriptMarkEntry() {
        return transcriptMarkEntry;
    }

    public void setTranscriptMarkEntry(List<TranscriptMarkEntry> transcriptMarkEntry) {
        this.transcriptMarkEntry = transcriptMarkEntry;
    }
}
