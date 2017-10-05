package sample.fstudent.Repository;

/**
 * Created by gmtco on 10/5/2017.
 */

public class PrequisiteManager {
    private int PrequisiteID ;
    private String SubjectRepresented ;
    private String PrequisiteSubject ;

    public PrequisiteManager() {
    }

    public PrequisiteManager(String subjectRepresented, String prequisiteSubject) {
        SubjectRepresented = subjectRepresented;
        PrequisiteSubject = prequisiteSubject;
    }

    public int getPrequisiteID() {
        return PrequisiteID;
    }

    public void setPrequisiteID(int prequisiteID) {
        PrequisiteID = prequisiteID;
    }

    public String getSubjectRepresented() {
        return SubjectRepresented;
    }

    public void setSubjectRepresented(String subjectRepresented) {
        SubjectRepresented = subjectRepresented;
    }

    public String getPrequisiteSubject() {
        return PrequisiteSubject;
    }

    public void setPrequisiteSubject(String prequisiteSubject) {
        PrequisiteSubject = prequisiteSubject;
    }
}
