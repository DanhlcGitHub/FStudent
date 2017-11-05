
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class PrequisiteManager {

    @SerializedName("prequisiteId")
    @Expose
    private Integer prequisiteId;
    @SerializedName("subjectRepresented")
    @Expose
    private String subjectRepresented;
    @SerializedName("prequisiteSubject")
    @Expose
    private String prequisiteSubject;
    @SerializedName("prequisiteSubjectNavigation")
    @Expose
    private Subject prequisiteSubjectNavigation;
    @SerializedName("subjectRepresentedNavigation")
    @Expose
    private Subject subjectRepresentedNavigation;

    public Integer getPrequisiteId() {
        return prequisiteId;
    }

    public void setPrequisiteId(Integer prequisiteId) {
        this.prequisiteId = prequisiteId;
    }

    public String getSubjectRepresented() {
        return subjectRepresented;
    }

    public void setSubjectRepresented(String subjectRepresented) {
        this.subjectRepresented = subjectRepresented;
    }

    public String getPrequisiteSubject() {
        return prequisiteSubject;
    }

    public void setPrequisiteSubject(String prequisiteSubject) {
        this.prequisiteSubject = prequisiteSubject;
    }

    public Subject getPrequisiteSubjectNavigation() {
        return prequisiteSubjectNavigation;
    }

    public void setPrequisiteSubjectNavigation(Subject prequisiteSubjectNavigation) {
        this.prequisiteSubjectNavigation = prequisiteSubjectNavigation;
    }

    public Subject getSubjectRepresentedNavigation() {
        return subjectRepresentedNavigation;
    }

    public void setSubjectRepresentedNavigation(Subject subjectRepresentedNavigation) {
        this.subjectRepresentedNavigation = subjectRepresentedNavigation;
    }
}
