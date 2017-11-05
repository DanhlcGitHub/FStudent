package sample.fstudent.Service;

import java.util.List;

import retrofit.Callback;
import retrofit.http.GET;
import retrofit.http.Path;

public interface MInterface {
    @GET("/users/mobilesiri")
    void getUser(Callback<Pojo> uscb);

    @GET("/api/GetWeekBySemester/{semesterID}")
    void getWeekInSemester(@Path("semesterID") String semesterID,
                 Callback<List<String>> uscb);
}
