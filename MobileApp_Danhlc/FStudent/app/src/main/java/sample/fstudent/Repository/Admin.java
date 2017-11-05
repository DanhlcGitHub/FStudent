package sample.fstudent.Repository;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Admin {

    @SerializedName("adminId")
    @Expose
    private String adminId;
    @SerializedName("password")
    @Expose
    private String password;
    @SerializedName("adminName")
    @Expose
    private Object adminName;

    public String getAdminId() {
        return adminId;
    }

    public void setAdminId(String adminId) {
        this.adminId = adminId;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Object getAdminName() {
        return adminName;
    }

    public void setAdminName(Object adminName) {
        this.adminName = adminName;
    }

}