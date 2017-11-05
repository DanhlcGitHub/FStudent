
package sample.fstudent.Repository;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Subject {

    @SerializedName("subjectCode")
    @Expose
    private String subjectCode;
    @SerializedName("subjectName")
    @Expose
    private String subjectName;
    @SerializedName("credit")
    @Expose
    private Integer credit;
    @SerializedName("prequisiteManagerPrequisiteSubjectNavigation")
    @Expose
    private List<PrequisiteManager> prequisiteManagerPrequisiteSubjectNavigation = null;
    @SerializedName("prequisiteManagerSubjectRepresentedNavigation")
    @Expose
    private List<PrequisiteManager> prequisiteManagerSubjectRepresentedNavigation = null;
    @SerializedName("section")
    @Expose
    private List<Section> section = null;
    @SerializedName("subjectTemplate")
    @Expose
    private List<SubjectTemplate> subjectTemplate = null;

    public String getSubjectCode() {
        return subjectCode;
    }

    public void setSubjectCode(String subjectCode) {
        this.subjectCode = subjectCode;
    }

    public String getSubjectName() {
        return subjectName;
    }

    public void setSubjectName(String subjectName) {
        this.subjectName = subjectName;
    }

    public Integer getCredit() {
        return credit;
    }

    public void setCredit(Integer credit) {
        this.credit = credit;
    }

    public List<PrequisiteManager> getPrequisiteManagerPrequisiteSubjectNavigation() {
        return prequisiteManagerPrequisiteSubjectNavigation;
    }

    public void setPrequisiteManagerPrequisiteSubjectNavigation(List<PrequisiteManager> prequisiteManagerPrequisiteSubjectNavigation) {
        this.prequisiteManagerPrequisiteSubjectNavigation = prequisiteManagerPrequisiteSubjectNavigation;
    }

    public List<PrequisiteManager> getPrequisiteManagerSubjectRepresentedNavigation() {
        return prequisiteManagerSubjectRepresentedNavigation;
    }

    public void setPrequisiteManagerSubjectRepresentedNavigation(List<PrequisiteManager> prequisiteManagerSubjectRepresentedNavigation) {
        this.prequisiteManagerSubjectRepresentedNavigation = prequisiteManagerSubjectRepresentedNavigation;
    }

    public List<Section> getSection() {
        return section;
    }

    public void setSection(List<Section> section) {
        this.section = section;
    }

    public List<SubjectTemplate> getSubjectTemplate() {
        return subjectTemplate;
    }

    public void setSubjectTemplate(List<SubjectTemplate> subjectTemplate) {
        this.subjectTemplate = subjectTemplate;
    }
}
