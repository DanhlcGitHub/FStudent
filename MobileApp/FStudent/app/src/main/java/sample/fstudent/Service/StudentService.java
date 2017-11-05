package sample.fstudent.Service;

import android.app.IntentService;
import android.content.Intent;
import android.os.Bundle;
import android.os.ResultReceiver;
import android.support.annotation.Nullable;
import android.util.Log;

import com.google.gson.Gson;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import retrofit.Callback;
import retrofit.RestAdapter;
import retrofit.RetrofitError;
import retrofit.client.Response;
import sample.fstudent.Common.Constant;
import sample.fstudent.Repository.Section;
import sample.fstudent.Repository.SectionSchedule;

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
            receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
            try {
                RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.TEST_LINK).build();

                MInterface restInt=radapter.create(MInterface.class);

                restInt.getUser(new Callback<Pojo>() {
                    @Override
                    public void success(Pojo model, Response response) {
                        ArrayList results = new ArrayList<String>();
                        results.add(model.getCompany());
                        results.add(model.getBlog());
                        results.add(model.getHtmlUrl());
                        // get some data or something
                        //b.putParcelableArrayList("results", results);
                        b.putString("sectionScheduleList",dummyData());
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
        }else if(command.equals("getWeekInSemester")){
            receiver.send(Constant.STATUS_RUNNING, Bundle.EMPTY);
            try {
                RestAdapter radapter=new RestAdapter.Builder().setEndpoint(Constant.GET_WEEKLY_SCHEDULE_LINK).build();
                String semesterID  = intent.getStringExtra("semesterID");
                MInterface restInt=radapter.create(MInterface.class);

                restInt.getWeekInSemester(semesterID, new Callback<List<String>>() {
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
    }

    public String spinnerDummyData(){
        ArrayList<Date> lists = new ArrayList<Date>();
        Date date1 = null;
        Date date2 = null;
        Date date3 = null;
        Date date4 = null;
        Date date5 = null;

        try{
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            date1 = dateFormat.parse("2017-10-09 07:00:00");
            date2 = dateFormat.parse("2017-10-10 07:00:00");
            date3 = dateFormat.parse("2017-10-11 07:00:00");
            date4 = dateFormat.parse("2017-10-12 07:00:00");
            date5 = dateFormat.parse("2017-10-13 07:00:00");

        }catch(Exception e){

        }
        lists.add(date1);
        lists.add(date1);
        lists.add(date1);
        lists.add(date1);
        lists.add(date1);
        String json = new Gson().toJson(lists);
        return json;
    }

    public String dummyData(){
        ArrayList<SectionSchedule> lists = new ArrayList<SectionSchedule>();
        Date date1 = null;
        Date date2 = null;
        Date date3 = null;
        Date date4 = null;
        Date date5 = null;
        try{
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            date1 = dateFormat.parse("2017-10-09 07:00:00");

            date2 = dateFormat.parse("2017-10-10 07:00:00");
            date3 = dateFormat.parse("2017-10-11 07:00:00");
            date4 = dateFormat.parse("2017-10-12 07:00:00");
            date5 = dateFormat.parse("2017-10-13 07:00:00");

        }catch(Exception e){

        }
        SectionSchedule sec1 = new SectionSchedule(1,"HCI", date1,1,90,"R101");
        SectionSchedule sec2 = new SectionSchedule(2,"ACC", date1,2,90,"R101");

        SectionSchedule sec3 = new SectionSchedule(3,"ACC", date2,2,90,"R201");
        SectionSchedule sec4 = new SectionSchedule(4,"ACC", date2,3,90,"R201");
        SectionSchedule sec5 = new SectionSchedule(5,"PRO", date2,4,90,"R201");

        SectionSchedule sec6 = new SectionSchedule(6,"HCI", date3,1,90,"R101");
        SectionSchedule sec7 = new SectionSchedule(7,"PRO", date3,2,90,"R101");

        SectionSchedule sec8 = new SectionSchedule(8,"Ecommerce", date4,1,90,"R101");
        SectionSchedule sec9 = new SectionSchedule(9,"Ecommerce", date4,2,90,"R101");
        SectionSchedule sec10 = new SectionSchedule(10,"LMHT", date5,1,90,"R101");
        SectionSchedule sec11 = new SectionSchedule(11,"LMHT", date5,2,90,"R101");

        lists.add(sec1);
        lists.add(sec2);
        lists.add(sec3);
        lists.add(sec4);
        lists.add(sec5);
        lists.add(sec6);
        lists.add(sec7);
        lists.add(sec8);
        lists.add(sec9);
        lists.add(sec10);
        lists.add(sec11);

        String json = new Gson().toJson(lists);
        return json;
    }
}
