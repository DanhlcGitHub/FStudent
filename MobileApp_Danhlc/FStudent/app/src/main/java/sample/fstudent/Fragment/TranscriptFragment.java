package sample.fstudent.Fragment;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import org.w3c.dom.Text;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import sample.fstudent.Common.Constant;
import sample.fstudent.R;
import sample.fstudent.DTO.SectionTranscriptModel;
import sample.fstudent.DTO.SemesterTranscriptModel;
import sample.fstudent.Service.StudentReceiver;
import sample.fstudent.Service.StudentService;

public class TranscriptFragment extends Fragment implements StudentReceiver.Receiver{
    private ExpandableListView studentHistoryList;
    private List<SemesterTranscriptModel> semesterTranscriptModelList;
    public StudentReceiver mReceiver;
    public TextView tv_studyInfor;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        semesterTranscriptModelList = new ArrayList<>();
        View view = inflater.inflate(R.layout.transcript_fragment, container, false);
        studentHistoryList = (ExpandableListView) view.findViewById(R.id.student_history);
        tv_studyInfor = (TextView) view.findViewById(R.id.tv_studyInfor);
        callGetAllSectionOfSpecificStudentService();
        return view;
    }

    @Override
    public void onReceiveResult(int resultCode, Bundle resultData) {
        switch (resultCode) {
            case Constant.STATUS_RUNNING:
                break;
            case Constant.STATUS_FINISHED:
                if(resultData.getString("semesterTranscriptModels")!=null){
                    String jsonStr = resultData.getString("semesterTranscriptModels");
                    semesterTranscriptModelList = (List<SemesterTranscriptModel>) fromJson(jsonStr,
                            new TypeToken<List<SemesterTranscriptModel>>() {
                            }.getType());
                    CalculateGPA();
                    StudentHistoryAdapter studentHistoryAdapter = new StudentHistoryAdapter(getContext(), semesterTranscriptModelList);
                    studentHistoryList.setAdapter(studentHistoryAdapter);
                }
                break;
            case Constant.STATUS_ERROR:
                // handle the error;
                break;
        }
    }

    public void callGetAllSectionOfSpecificStudentService(){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "GetAllSectionOfSpecificStudentService");
        intent.putExtra("studentID",String.valueOf(Constant.StudentID));

        getContext().startService(intent);
    }

    private void CalculateGPA(){
        double sumGPA = 0;
        double GPA = 0 ;
        int totalCredit = 0;
        for(int i = 0; i < semesterTranscriptModelList.size(); i++){
            SemesterTranscriptModel stm = semesterTranscriptModelList.get(i);
            sumGPA += stm.getGPA();
            totalCredit += stm.getCredit();
        }
        GPA = sumGPA / semesterTranscriptModelList.size();
        String infor = "total credit: " + totalCredit + "/162 || GPA: " + GPA;
        tv_studyInfor.setText(infor);
    }

    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }

}
