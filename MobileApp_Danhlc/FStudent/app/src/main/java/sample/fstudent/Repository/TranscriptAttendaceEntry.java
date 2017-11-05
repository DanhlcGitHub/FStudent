
package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class TranscriptAttendaceEntry {

    @SerializedName("entryId")
    @Expose
    private Integer entryId;
    @SerializedName("transcriptId")
    @Expose
    private Integer transcriptId;
    @SerializedName("attendanceStatus")
    @Expose
    private Integer attendanceStatus;
    @SerializedName("sectionScheduleId")
    @Expose
    private Integer sectionScheduleId;
    @SerializedName("sectionSchedule")
    @Expose
    private SectionSchedule sectionSchedule;
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

    public Integer getAttendanceStatus() {
        return attendanceStatus;
    }

    public void setAttendanceStatus(Integer attendanceStatus) {
        this.attendanceStatus = attendanceStatus;
    }

    public Integer getSectionScheduleId() {
        return sectionScheduleId;
    }

    public void setSectionScheduleId(Integer sectionScheduleId) {
        this.sectionScheduleId = sectionScheduleId;
    }

    public SectionSchedule getSectionSchedule() {
        return sectionSchedule;
    }

    public void setSectionSchedule(SectionSchedule sectionSchedule) {
        this.sectionSchedule = sectionSchedule;
    }

    public StudentTranscript getTranscript() {
        return transcript;
    }

    public void setTranscript(StudentTranscript transcript) {
        this.transcript = transcript;
    }

}
