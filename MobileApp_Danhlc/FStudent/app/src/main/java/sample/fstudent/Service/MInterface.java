package sample.fstudent.Service;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Field;
import retrofit.http.FormUrlEncoded;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.Path;
import sample.fstudent.DTO.SemesterTranscriptModel;
import sample.fstudent.DTO.Student;
import sample.fstudent.DTO.SectionSchedule;

public interface MInterface {
    @GET("/users/mobilesiri")
    void getUser(Callback<Pojo> uscb);


    @GET("/api/GetWeekBySemester/{semesterID}")
    void getWeekInSemester(@Path("semesterID") String semesterID,
                 Callback<List<String>> uscb);

    @FormUrlEncoded
    @POST("/api/custom/login")
    void checkStudentLogin(
            @Field("StudentID") String StudentID,
            @Field("Password") String Password,
            Callback<String> uscb);

    @FormUrlEncoded
    @POST("/api/custom/PostGetStudentByID")
    void getStudentByID(
            @Field("StudentID") String StudentID,
            Callback<Student> uscb);

    @FormUrlEncoded
    @POST("/api/custom/PostGetCurrentSemester")
    void PostGetCurrentSemester(
            @Field("currentDate") String currentDate,
            Callback<Integer> uscb);

    @FormUrlEncoded
    @POST("/api/custom/PostGetAllWeekInSemester")
    void PostGetAllWeekInSemester(@Field("semesterID") String semesterID,
                           Callback<List<String>> uscb);

    @FormUrlEncoded
    @POST("/api/custom/GetListSectionScheduleInWeek")
    void PostGetListSectionScheduleInWeek(@Field("datePeriod") String datePeriod,
                                          @Field("semesterID") String semesterID,
                                          @Field("studentID") String studentID,
                                  Callback<List<SectionSchedule>> uscb);

    @FormUrlEncoded
    @POST("/api/custom/GetAllSectionOfSpecificStudentService")
    void PostGetAllSectionOfSpecificStudentService(
                                          @Field("studentID") String studentID,
                                          Callback<List<SemesterTranscriptModel>> uscb);
}
