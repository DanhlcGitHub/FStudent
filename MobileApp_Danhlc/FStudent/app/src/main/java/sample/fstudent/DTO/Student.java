package sample.fstudent.DTO;


        import com.google.gson.annotations.Expose;
        import com.google.gson.annotations.SerializedName;

public class Student {

    @SerializedName("StudentID")
    @Expose
    private String studentID;
    @SerializedName("StudentName")
    @Expose
    private String studentName;
    @SerializedName("Major")
    @Expose
    private String major;
    @SerializedName("Address")
    @Expose
    private String address;
    @SerializedName("Sex")
    @Expose
    private Integer sex;
    @SerializedName("BirthDay")
    @Expose
    private String birthDay;
    @SerializedName("Country")
    @Expose
    private String country;
    @SerializedName("Email")
    @Expose
    private String email;
    @SerializedName("Phone")
    @Expose
    private String phone;
    @SerializedName("Password")
    @Expose
    private String password;

    public String getStudentID() {
        return studentID;
    }

    public void setStudentID(String studentID) {
        this.studentID = studentID;
    }

    public String getStudentName() {
        return studentName;
    }

    public void setStudentName(String studentName) {
        this.studentName = studentName;
    }

    public String getMajor() {
        return major;
    }

    public void setMajor(String major) {
        this.major = major;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Integer getSex() {
        return sex;
    }

    public void setSex(Integer sex) {
        this.sex = sex;
    }

    public String getBirthDay() {
        return birthDay;
    }

    public void setBirthDay(String birthDay) {
        this.birthDay = birthDay;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

}