package sample.fstudent.DTO;

/**
 * Created by gmtco on 11/3/2017.
 */


        import com.google.gson.annotations.Expose;
        import com.google.gson.annotations.SerializedName;

public class SectionTranscriptModel {

    @SerializedName("sectionID")
    @Expose
    private String sectionID;
    @SerializedName("status")
    @Expose
    private String status;
    @SerializedName("credit")
    @Expose
    private Integer credit;
    @SerializedName("GPA")
    @Expose
    private Double gPA;

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

}