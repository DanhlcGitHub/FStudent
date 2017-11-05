package sample.fstudent.Service;

import android.app.IntentService;
import android.content.Intent;
import android.os.Bundle;
import android.os.ResultReceiver;
import android.support.annotation.Nullable;
import android.util.Log;

import com.google.gson.Gson;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import retrofit.Callback;
import retrofit.RestAdapter;
import retrofit.RetrofitError;
import retrofit.client.Response;
import sample.fstudent.Common.Constant;
import sample.fstudent.DTO.SemesterTranscriptModel;
import sample.fstudent.Repository.Section;
import sample.fstudent.DTO.SectionSchedule;
import sample.fstudent.DTO.Student;

/**
 * Created by gmtco on 10/13/2017.
 */

public class StudentService extends IntentService {
    public StudentService() {
        super("StudentService");
    }

    @Override
    protected void onHandleIntent(@Nullable Intent intent) {
        final ResultReceiver receiver = intent.getParcelableExtra("receiver");
        String command = intent.getStringExtra("command");
        final Bundle b = new Bundle();

        if(command.equals("getWeeklyScheduleList")) {
            String datePeriod = intent.getStringExtra("datePeriod");
            getWeeklyScheduleListService(receiver,b,datePeriod);
        }else if(command.equals("getWeekInSemester")){
            String semesterID  = intent.getStringExtra("semesterID");
            getWeekInSemesterService(receiver,b,semesterID);
        }else if(command.equals("studentLoginService")){
            String StudentID = intent.getStringExtra("StudentID");
            String Password = intent.getStringExtra("Password");
            checkLoginService(receiver,b,StudentID,Password);
        }else if(command.equals("getStudentByID")){
            String StudentID = intent.getStringExtra("StudentID");
            getStudentByID(receiver,b,StudentID);
        }else if(command.equals("PostGetCurrentSemester")){
            DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
            Date date = new Date();
            String currentDate = dateFormat.format(date);
            PostGetCurrentSemester(receiver,b,currentDate);
        }else if(command.equals("GetAllSectionOfSpecificStudentService")){
            String StudentID = intent.getStringExtra("studentID");
            PostGetAllSectionOfSpecificStudentService(receiver,b,StudentID);
        }


    }

    private void getWeekInSemesterService(final ResultReceiver receiver,final Bundle b,String semesterID){
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.PostGetAllWeekInSemester(semesterID, new Callback<List<String>>() {
                @Override
                public void success(List<String> strings, Response response) {
                    String jsonStr = new Gson().toJson(strings);
                    b.putString("semesterList",jsonStr);
                    receiver.send(Constant.STATUS_FINISHED, b);
                }

                @Override
                public void failure(RetrofitError error) {
                    String s = "";
                }
            });


        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

    private void getWeeklyScheduleListService(final ResultReceiver receiver,final Bundle b,String datePeriod){
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.PostGetListSectionScheduleInWeek(datePeriod,String.valueOf(Constant.CurrentSemester)
                    ,Constant.StudentID
                    ,new Callback<List<SectionSchedule>>() {
                @Override
                public void success(List<SectionSchedule> sectionScheduleList, Response response) {
                    ArrayList results = new ArrayList<String>();

                    String json = new Gson().toJson(sectionScheduleList);
                    b.putString("sectionScheduleList",json);
                    receiver.send(Constant.STATUS_FINISHED, b);
                }
                @Override
                public void failure(RetrofitError error) {

                    String err = error.getMessage();
                }
            });


        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

    private void checkLoginService(final ResultReceiver receiver,final Bundle b,String studentID,String password){
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.checkStudentLogin(studentID, password, new Callback<String>() {
                @Override
                public void success(String s, Response response) {
                    b.putString("loginStatus",s);
                    receiver.send(Constant.STATUS_FINISHED, b);
                }

                @Override
                public void failure(RetrofitError error) {
                    String err = error.getMessage();
                }
            });
        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

    private void getStudentByID(final ResultReceiver receiver,final Bundle b,String studentID){
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.getStudentByID(studentID, new Callback<Student>() {
                @Override
                public void success(Student student, Response response) {
                    String jsonStr = new Gson().toJson(student);
                    b.putString("studentInfor",jsonStr);
                    receiver.send(Constant.STATUS_FINISHED, b);
                }

                @Override
                public void failure(RetrofitError error) {
                    String err = error.getMessage();
                }
            });
        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

    private void PostGetCurrentSemester(final ResultReceiver receiver,final Bundle b,String currentDate){
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.PostGetCurrentSemester(currentDate, new Callback<Integer>() {
                @Override
                public void success(Integer semesterID, Response response) {
                    b.putString("semesterID",semesterID.toString());

                    receiver.send(Constant.STATUS_FINISHED, b);
                }

                @Override
                public void failure(RetrofitError error) {
                    String err = error.getMessage();
                }
            });
        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

    private void PostGetAllSectionOfSpecificStudentService(final ResultReceiver receiver,final Bundle b,String studentID)
    {
        receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
        try {
            RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.API_BASE_URL).build();

            MInterface restInt=radapter.create(MInterface.class);

            restInt.PostGetAllSectionOfSpecificStudentService(studentID, new Callback<List<SemesterTranscriptModel>>() {
                @Override
                public void success(List<SemesterTranscriptModel> semesterTranscriptModels, Response response) {
                    String json = new Gson().toJson(semesterTranscriptModels);
                    b.putString("semesterTranscriptModels",json);
                    receiver.send(Constant.STATUS_FINISHED, b);
                }

                @Override
                public void failure(RetrofitError error) {
                    String err = error.getMessage();
                }
            });
        } catch(Exception e) {
            b.putString(Intent.EXTRA_TEXT, e.toString());
            receiver.send(Constant.STATUS_ERROR, b);
        }
    }

}
