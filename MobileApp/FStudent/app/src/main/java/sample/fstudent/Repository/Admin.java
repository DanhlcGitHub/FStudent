package sample.fstudent.Repository;

/**
 * Created by gmtco on 10/5/2017.
 */

public class Admin {
    private String AdminID ;
    private String Password ;
    private String AdminName ;

    public Admin(String adminID, String password, String adminName) {
        AdminID = adminID;
        Password = password;
        AdminName = adminName;
    }

    public String getAdminID() {
        return AdminID;
    }

    public void setAdminID(String adminID) {
        AdminID = adminID;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public String getAdminName() {
        return AdminName;
    }

    public void setAdminName(String adminName) {
        AdminName = adminName;
    }
}
