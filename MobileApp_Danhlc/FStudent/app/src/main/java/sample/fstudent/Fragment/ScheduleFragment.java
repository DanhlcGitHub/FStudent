package sample.fstudent.Fragment;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.os.Handler;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import sample.fstudent.Common.Constant;
import sample.fstudent.R;
import sample.fstudent.Repository.SectionSchedule;
import sample.fstudent.Service.StudentReceiver;
import sample.fstudent.Service.StudentService;


public class ScheduleFragment extends Fragment implements StudentReceiver.Receiver {
    private View view;
    private static final int NUM_PAGES = 2;
    private ViewPager mPager;
    private PagerAdapter mPagerAdapter;
    private TextView txtCurrentViewpager;
    private int currentPage = 0;
    Spinner dropdown;
    public StudentReceiver mReceiver;
    FloatingActionButton moveNextBackButton;
    private String jsonScheduleData;
    private boolean orientation;
    private FrameLayout container;
    private List<String> weeklyList;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        view = inflater.inflate(R.layout.schedule_fragment, container, false);
        Configuration config = getResources().getConfiguration();
        if (config.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            orientation = false;
        }else{
            orientation = true;
        }
        if(orientation == true) {
            getIDs(view);
        }else{
            getIDsLand(view);
        }
        //setValueForSpinner();
        callGetWeeklyService();
        return view;
    }

    public void getIDs(View view){
        dropdown = (Spinner)view.findViewById(R.id.weeklySpinner);
        mPager = (ViewPager) view.findViewById(R.id.paper);
        moveNextBackButton = (FloatingActionButton) view.findViewById(R.id.moveNextBackButton);
        txtCurrentViewpager = (TextView) view.findViewById(R.id.txtCurrentViewpager);
        String pageRatio = (currentPage +1 ) + "/" + NUM_PAGES;
        txtCurrentViewpager.setText(pageRatio);
    }

    public void getIDsLand(View view){
        dropdown = (Spinner)view.findViewById(R.id.weeklySpinner);
        container = (FrameLayout) view.findViewById(R.id.timetable_container);
    }

    public void setValueForSpinner(){
        List<String> formatWeeklyList = new ArrayList<String>();
        for(int i = 0 ; i<weeklyList.size();i++){
            String s = weeklyList.get(i);
            String[] parts = s.split(",");
            String startDay = parts[0];
            String endDay = parts[1];

            formatWeeklyList.add("week" +  (i + 1) + ": " + startDay + " to " + endDay);
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),
                android.R.layout.simple_spinner_dropdown_item, formatWeeklyList);
        dropdown.setAdapter(adapter);

        dropdown.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int pos, long l) {

                String selected = adapterView.getItemAtPosition(pos).toString();
                selected = selected.substring(selected.indexOf(":") + 1,selected.length());
                selected = selected.trim();
                selected = selected.replace("to",",");
                callGetSectionScheduleInWeekService(selected);
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }

    public void setViewPagerListener(){
        mPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {

            // This method will be invoked when a new page becomes selected.
            @Override
            public void onPageSelected(int position) {
                currentPage = position;
                String text = (position+1) + "/" + NUM_PAGES;
                txtCurrentViewpager.setText(text);
            }

            // This method will be invoked when the current page is scrolled
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }

        });

    }


    @Override
    public void onReceiveResult(int resultCode, final Bundle resultData) {
        final ProgressDialog progressDialog = new ProgressDialog((getActivity()),
                R.style.AppTheme_Dark_Dialog);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Loading");

        switch (resultCode) {
            case Constant.STATUS_RUNNING:
                //show progress
                //progressDialog.show();
                break;
            case Constant.STATUS_FINISHED:
                if(resultData.getString("sectionScheduleList")!=null) {
                    new android.os.Handler().postDelayed(
                            new Runnable() {
                                public void run() {

                                    onGetDataSuccess(resultData);

                                    //progressDialog.dismiss();
                                }
                            }, 300);
                }else if(resultData.getString("semesterList")!=null){
                    String jsonStr = resultData.getString("semesterList");
                    weeklyList = (ArrayList<String>) fromJson(jsonStr,
                            new TypeToken<ArrayList<String>>() {
                            }.getType());
                    setValueForSpinner();
                }
                break;
            case Constant.STATUS_ERROR:
                // handle the error;
                break;
        }
    }

    public void onGetDataSuccess(Bundle resultData){
        jsonScheduleData = resultData.getString("sectionScheduleList");
        if(jsonScheduleData == null)
            Log.i("mytag","it's null");
        else {
          /*  */
            //Toast.makeText(getContext(), jsonScheduleData, Toast.LENGTH_LONG).show();
        }
        if(orientation == true) {
            mPagerAdapter = new ScreenSlidePagerAdapter(getFragmentManager());
            mPager.setAdapter(mPagerAdapter);
            setViewPagerListener();
        }else{
            TimeTableFragment ttFragment = new TimeTableFragment();
            Bundle bundle = new Bundle();
            bundle.putInt("pageIndex", 1);
            bundle.putString("data",jsonScheduleData);
            ttFragment.setArguments(bundle);

            FragmentManager fragmentManager = getFragmentManager();
            android.support.v4.app.FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

            fragmentTransaction.replace(R.id.timetable_container,ttFragment);//
            fragmentTransaction.addToBackStack(null);
            fragmentTransaction.commitAllowingStateLoss();
        }
        //setValueForSpinner()
    }

    public void callGetSectionScheduleInWeekService(String datePeriod){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "getWeeklyScheduleList");
        intent.putExtra("datePeriod", datePeriod);

        getContext().startService(intent);
    }

    public void callGetWeeklyService(){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "getWeekInSemester");
        intent.putExtra("semesterID",String.valueOf(Constant.CurrentSemester));

        getContext().startService(intent);
    }

    private void replaceFragment(Fragment childFragment){

    }

    private class ScreenSlidePagerAdapter extends FragmentStatePagerAdapter {
        public ScreenSlidePagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            TimeTableFragment ttFragment = new TimeTableFragment();
            Bundle bundle = new Bundle();
            bundle.putInt("pageIndex", position);
            bundle.putString("data",jsonScheduleData);
            ttFragment.setArguments(bundle);

            return ttFragment;
        }

        @Override
        public int getCount() {
            return NUM_PAGES;
        }
    }
    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }
}
