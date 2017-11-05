
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.Date;
import java.util.List;

public class SectionSchedule {

    @SerializedName("sectionScheduleId")
    @Expose
    private Integer sectionScheduleId;
    @SerializedName("sectionId")
    @Expose
    private String sectionId;
    @SerializedName("date")
    @Expose
    private Date date;
    @SerializedName("slot")
    @Expose
    private Integer slot;
    @SerializedName("duration")
    @Expose
    private Integer duration;
    @SerializedName("room")
    @Expose
    private String room;
    @SerializedName("section")
    @Expose
    private Section section;
    @SerializedName("transcriptAttendaceEntry")
    @Expose
    private List<TranscriptAttendaceEntry> transcriptAttendaceEntry = null;

    public SectionSchedule(Integer sectionScheduleId, String sectionId, Date date, Integer slot, Integer duration, String room) {
        this.sectionScheduleId = sectionScheduleId;
        this.sectionId = sectionId;
        this.date = date;
        this.slot = slot;
        this.duration = duration;
        this.room = room;
    }

    public Integer getSectionScheduleId() {
        return sectionScheduleId;
    }

    public void setSectionScheduleId(Integer sectionScheduleId) {
        this.sectionScheduleId = sectionScheduleId;
    }

    public String getSectionId() {
        return sectionId;
    }

    public void setSectionId(String sectionId) {
        this.sectionId = sectionId;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
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

    public Section getSection() {
        return section;
    }

    public void setSection(Section section) {
        this.section = section;
    }

    public List<TranscriptAttendaceEntry> getTranscriptAttendaceEntry() {
        return transcriptAttendaceEntry;
    }

    public void setTranscriptAttendaceEntry(List<TranscriptAttendaceEntry> transcriptAttendaceEntry) {
        this.transcriptAttendaceEntry = transcriptAttendaceEntry;
    }

}
