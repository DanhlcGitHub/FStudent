package sample.fstudent.Repository;

/**
 * Created by gmtco on 10/5/2017.
 */

public class Professor {
    private String ProfessorCode ;
    private String ProfessorName ;
    private int DepartmentID ;
    private String Title ;
    private double Salary ;
    private String Phone ;
    private String Address ;
    private String Password ;

    public Professor(String professorCode, String professorName, int departmentID, String title, double salary, String phone, String address, String password) {
        ProfessorCode = professorCode;
        ProfessorName = professorName;
        DepartmentID = departmentID;
        Title = title;
        Salary = salary;
        Phone = phone;
        Address = address;
        Password = password;
    }

    public String getProfessorCode() {
        return ProfessorCode;
    }

    public void setProfessorCode(String professorCode) {
        ProfessorCode = professorCode;
    }

    public String getProfessorName() {
        return ProfessorName;
    }

    public void setProfessorName(String professorName) {
        ProfessorName = professorName;
    }

    public int getDepartmentID() {
        return DepartmentID;
    }

    public void setDepartmentID(int departmentID) {
        DepartmentID = departmentID;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public double getSalary() {
        return Salary;
    }

    public void setSalary(double salary) {
        Salary = salary;
    }

    public String getPhone() {
        return Phone;
    }

    public void setPhone(String phone) {
        Phone = phone;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }
}
