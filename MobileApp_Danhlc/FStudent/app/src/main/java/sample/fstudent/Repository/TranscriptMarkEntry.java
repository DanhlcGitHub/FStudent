
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class TranscriptMarkEntry {

    @SerializedName("entryId")
    @Expose
    private Integer entryId;
    @SerializedName("transcriptId")
    @Expose
    private Integer transcriptId;
    @SerializedName("sectionTemplateId")
    @Expose
    private Integer sectionTemplateId;
    @SerializedName("grade")
    @Expose
    private Integer grade;
    @SerializedName("sectionTemplate")
    @Expose
    private SectionSubTemplate sectionTemplate;
    @SerializedName("transcript")
    @Expose
    private StudentTranscript transcript;

    public Integer getEntryId() {
        return entryId;
    }

    public void setEntryId(Integer entryId) {
        this.entryId = entryId;
    }

    public Integer getTranscriptId() {
        return transcriptId;
    }

    public void setTranscriptId(Integer transcriptId) {
        this.transcriptId = transcriptId;
    }

    public Integer getSectionTemplateId() {
        return sectionTemplateId;
    }

    public void setSectionTemplateId(Integer sectionTemplateId) {
        this.sectionTemplateId = sectionTemplateId;
    }

    public Integer getGrade() {
        return grade;
    }

    public void setGrade(Integer grade) {
        this.grade = grade;
    }

    public SectionSubTemplate getSectionTemplate() {
        return sectionTemplate;
    }

    public void setSectionTemplate(SectionSubTemplate sectionTemplate) {
        this.sectionTemplate = sectionTemplate;
    }

    public StudentTranscript getTranscript() {
        return transcript;
    }

    public void setTranscript(StudentTranscript transcript) {
        this.transcript = transcript;
    }
}
