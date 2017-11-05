
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Section {

    @SerializedName("sectionNo")
    @Expose
    private String sectionNo;
    @SerializedName("seatingCapacity")
    @Expose
    private Integer seatingCapacity;
    @SerializedName("startDate")
    @Expose
    private String startDate;
    @SerializedName("endDate")
    @Expose
    private String endDate;
    @SerializedName("professorCode")
    @Expose
    private String professorCode;
    @SerializedName("representedSubject")
    @Expose
    private String representedSubject;
    @SerializedName("semesterBelong")
    @Expose
    private Integer semesterBelong;
    @SerializedName("professorCodeNavigation")
    @Expose
    private Professor professorCodeNavigation;
    @SerializedName("representedSubjectNavigation")
    @Expose
    private Subject representedSubjectNavigation;
    @SerializedName("semesterBelongNavigation")
    @Expose
    private Schedule semesterBelongNavigation;
    @SerializedName("sectionSchedule")
    @Expose
    private List<SectionSchedule> sectionSchedule = null;
    @SerializedName("sectionSubTemplate")
    @Expose
    private List<SectionSubTemplate> sectionSubTemplate = null;
    @SerializedName("studentTranscript")
    @Expose
    private List<StudentTranscript> studentTranscript = null;

    public String getSectionNo() {
        return sectionNo;
    }

    public void setSectionNo(String sectionNo) {
        this.sectionNo = sectionNo;
    }

    public Integer getSeatingCapacity() {
        return seatingCapacity;
    }

    public void setSeatingCapacity(Integer seatingCapacity) {
        this.seatingCapacity = seatingCapacity;
    }

    public String getStartDate() {
        return startDate;
    }

    public void setStartDate(String startDate) {
        this.startDate = startDate;
    }

    public String getEndDate() {
        return endDate;
    }

    public void setEndDate(String endDate) {
        this.endDate = endDate;
    }

    public String getProfessorCode() {
        return professorCode;
    }

    public void setProfessorCode(String professorCode) {
        this.professorCode = professorCode;
    }

    public String getRepresentedSubject() {
        return representedSubject;
    }

    public void setRepresentedSubject(String representedSubject) {
        this.representedSubject = representedSubject;
    }

    public Integer getSemesterBelong() {
        return semesterBelong;
    }

    public void setSemesterBelong(Integer semesterBelong) {
        this.semesterBelong = semesterBelong;
    }

    public Professor getProfessorCodeNavigation() {
        return professorCodeNavigation;
    }

    public void setProfessorCodeNavigation(Professor professorCodeNavigation) {
        this.professorCodeNavigation = professorCodeNavigation;
    }

    public Subject getRepresentedSubjectNavigation() {
        return representedSubjectNavigation;
    }

    public void setRepresentedSubjectNavigation(Subject representedSubjectNavigation) {
        this.representedSubjectNavigation = representedSubjectNavigation;
    }

    public Schedule getSemesterBelongNavigation() {
        return semesterBelongNavigation;
    }

    public void setSemesterBelongNavigation(Schedule semesterBelongNavigation) {
        this.semesterBelongNavigation = semesterBelongNavigation;
    }

    public List<SectionSchedule> getSectionSchedule() {
        return sectionSchedule;
    }

    public void setSectionSchedule(List<SectionSchedule> sectionSchedule) {
        this.sectionSchedule = sectionSchedule;
    }

    public List<SectionSubTemplate> getSectionSubTemplate() {
        return sectionSubTemplate;
    }

    public void setSectionSubTemplate(List<SectionSubTemplate> sectionSubTemplate) {
        this.sectionSubTemplate = sectionSubTemplate;
    }

    public List<StudentTranscript> getStudentTranscript() {
        return studentTranscript;
    }

    public void setStudentTranscript(List<StudentTranscript> studentTranscript) {
        this.studentTranscript = studentTranscript;
    }
}
