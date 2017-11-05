package sample.fstudent.Fragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;

import java.util.ArrayList;
import java.util.List;

import sample.fstudent.R;
import sample.fstudent.Utility.SectionTranscriptModel;
import sample.fstudent.Utility.SemesterTranscriptModel;

public class TranscriptFragment extends Fragment {
    private ExpandableListView studentHistoryList;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.transcript_fragment, container, false);
        studentHistoryList = (ExpandableListView) view.findViewById(R.id.student_history);
        StudentHistoryAdapter studentHistoryAdapter = new StudentHistoryAdapter(getContext(), getDummyData());
        studentHistoryList.setAdapter(studentHistoryAdapter);
        return view;
    }

    public List<SemesterTranscriptModel> getDummyData(){
        List<SemesterTranscriptModel> list = new ArrayList<>();

        SectionTranscriptModel sec1 = new SectionTranscriptModel("HCI","pass",3,7.2);
        SectionTranscriptModel sec2 = new SectionTranscriptModel("SWD","pass",3,7.3);
        SectionTranscriptModel sec3 = new SectionTranscriptModel("ISC","pass",3,7.4);
        SectionTranscriptModel sec4 = new SectionTranscriptModel("PRO","pass",3,7.5);
        SectionTranscriptModel sec5 = new SectionTranscriptModel("NNN","pass",3,7.6);
        List<SectionTranscriptModel> seclist = new ArrayList<>();
        seclist.add(sec1);
        seclist.add(sec2);
        seclist.add(sec3);
        seclist.add(sec4);
        seclist.add(sec5);

        for(int i = 0 ; i<5; i++){
            SemesterTranscriptModel semester = new SemesterTranscriptModel(i,"Semester fall " + i,3,7.5,
                    seclist);
            list.add(semester);
        }
        return list;
    }
}
