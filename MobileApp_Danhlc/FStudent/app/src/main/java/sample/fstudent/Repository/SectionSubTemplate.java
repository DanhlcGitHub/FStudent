
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class SectionSubTemplate {

    @SerializedName("id")
    @Expose
    private Integer id;
    @SerializedName("sectionId")
    @Expose
    private String sectionId;
    @SerializedName("markTitle")
    @Expose
    private String markTitle;
    @SerializedName("percentage")
    @Expose
    private Integer percentage;
    @SerializedName("isCurrent")
    @Expose
    private Boolean isCurrent;
    @SerializedName("section")
    @Expose
    private Section section;
    @SerializedName("transcriptMarkEntry")
    @Expose
    private List<TranscriptMarkEntry> transcriptMarkEntry = null;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getSectionId() {
        return sectionId;
    }

    public void setSectionId(String sectionId) {
        this.sectionId = sectionId;
    }

    public String getMarkTitle() {
        return markTitle;
    }

    public void setMarkTitle(String markTitle) {
        this.markTitle = markTitle;
    }

    public Integer getPercentage() {
        return percentage;
    }

    public void setPercentage(Integer percentage) {
        this.percentage = percentage;
    }

    public Boolean getIsCurrent() {
        return isCurrent;
    }

    public void setIsCurrent(Boolean isCurrent) {
        this.isCurrent = isCurrent;
    }

    public Section getSection() {
        return section;
    }

    public void setSection(Section section) {
        this.section = section;
    }

    public List<TranscriptMarkEntry> getTranscriptMarkEntry() {
        return transcriptMarkEntry;
    }

    public void setTranscriptMarkEntry(List<TranscriptMarkEntry> transcriptMarkEntry) {
        this.transcriptMarkEntry = transcriptMarkEntry;
    }

    public Boolean getCurrent() {
        return isCurrent;
    }

    public void setCurrent(Boolean current) {
        isCurrent = current;
    }
}
