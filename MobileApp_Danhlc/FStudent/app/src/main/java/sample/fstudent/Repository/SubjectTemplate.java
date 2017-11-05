
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SubjectTemplate {

    @SerializedName("id")
    @Expose
    private Integer id;
    @SerializedName("subjectId")
    @Expose
    private String subjectId;
    @SerializedName("markTitle")
    @Expose
    private String markTitle;
    @SerializedName("percentage")
    @Expose
    private Integer percentage;
    @SerializedName("isCurrent")
    @Expose
    private Boolean isCurrent;
    @SerializedName("subject")
    @Expose
    private Subject subject;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getSubjectId() {
        return subjectId;
    }

    public void setSubjectId(String subjectId) {
        this.subjectId = subjectId;
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

    public Subject getSubject() {
        return subject;
    }

    public void setSubject(Subject subject) {
        this.subject = subject;
    }

    public Boolean getCurrent() {
        return isCurrent;
    }

    public void setCurrent(Boolean current) {
        isCurrent = current;
    }
}
