package sample.fstudent.DTO;

/**
 * Created by gmtco on 10/31/2017.
 */
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SectionSchedule {

    @SerializedName("SectionScheduleID")
    @Expose
    private Integer sectionScheduleID;
    @SerializedName("SectionID")
    @Expose
    private String sectionID;
    @SerializedName("Date")
    @Expose
    private String date;
    @SerializedName("Slot")
    @Expose
    private Integer slot;
    @SerializedName("Duration")
    @Expose
    private Integer duration;
    @SerializedName("Room")
    @Expose
    private String room;

    public SectionSchedule(Integer sectionScheduleID, String sectionID, String date, Integer slot, Integer duration, String room) {
        this.sectionScheduleID = sectionScheduleID;
        this.sectionID = sectionID;
        this.date = date;
        this.slot = slot;
        this.duration = duration;
        this.room = room;
    }

    public Integer getSectionScheduleID() {
        return sectionScheduleID;
    }

    public void setSectionScheduleID(Integer sectionScheduleID) {
        this.sectionScheduleID = sectionScheduleID;
    }

    public String getSectionID() {
        return sectionID;
    }

    public void setSectionID(String sectionID) {
        this.sectionID = sectionID;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public Integer getSlot() {
        return slot;
    }

    public void setSlot(Integer slot) {
        this.slot = slot;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }

    public String getRoom() {
        return room;
    }

    public void setRoom(String room) {
        this.room = room;
    }

}
