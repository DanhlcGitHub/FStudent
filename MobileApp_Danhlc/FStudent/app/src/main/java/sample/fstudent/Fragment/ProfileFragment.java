package sample.fstudent.Fragment;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.ArrayList;

import sample.fstudent.Common.Constant;
import sample.fstudent.R;
import sample.fstudent.DTO.Student;
import sample.fstudent.Service.StudentReceiver;
import sample.fstudent.Service.StudentService;


public class ProfileFragment extends Fragment implements StudentReceiver.Receiver{
    TextView tv_name;
    TextView tv_id;
    TextView tv_birthday;
    TextView tv_gender;
    TextView tv_address;
    TextView tv_phone;
    TextView tv_email;
    public StudentReceiver mReceiver;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.profile_fragment, container, false);
        tv_name = (TextView) view.findViewById(R.id.name);
        tv_id = (TextView) view.findViewById(R.id.studentID);
        tv_birthday = (TextView) view.findViewById(R.id.tv_birthday);
        tv_gender = (TextView) view.findViewById(R.id.tv_gender);

        tv_address = (TextView) view.findViewById(R.id.tv_address);
        tv_phone = (TextView) view.findViewById(R.id.tv_phone);
        tv_email = (TextView) view.findViewById(R.id.tv_email);
        callGetInforService();
        return view;
    }


    @Override
    public void onReceiveResult(int resultCode, Bundle resultData) {
        switch (resultCode) {
            case Constant.STATUS_RUNNING:
                //show progress
                //progressDialog.show();
                break;
            case Constant.STATUS_FINISHED:
                Student student = new Student();
                String studentInfor = resultData.getString("studentInfor");
                if(studentInfor!=null) {
                    student = (Student) fromJson(studentInfor,
                            new TypeToken<Student>() {
                            }.getType());
                }

                tv_name.setText(student.getStudentName());
                tv_id.setText(student.getStudentID());
                tv_birthday.setText(student.getBirthDay().toString());
                String sex = "unknown";
                if(student.getSex() == 1) sex = "male";
                else sex = "female";
                tv_gender.setText(sex);
                tv_address.setText(student.getAddress());
                tv_phone.setText(student.getPhone());
                tv_email.setText(student.getEmail());
                break;
            case Constant.STATUS_ERROR:
                // handle the error;
                break;
        }
    }

    public void callGetInforService(){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "getStudentByID");
        String studentID = Constant.StudentID;
        intent.putExtra("StudentID", Constant.StudentID);

        getContext().startService(intent);
    }

    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }
}
