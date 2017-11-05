package sample.fstudent.Fragment;

import android.content.Context;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;
import android.widget.Toast;


import java.util.List;

import sample.fstudent.R;
import sample.fstudent.DTO.SectionTranscriptModel;
import sample.fstudent.DTO.SemesterTranscriptModel;

/**
 * Created by Yellow Code Books on 11/3/16.
 */

public class StudentHistoryAdapter extends BaseExpandableListAdapter {

    private Context context;
    private List<SemesterTranscriptModel> SemesterTranscriptModels;

    public StudentHistoryAdapter(Context context, List<SemesterTranscriptModel> SemesterTranscriptModels) {
        this.context = context;
        this.SemesterTranscriptModels = SemesterTranscriptModels;
    }

    @Override
    public int getGroupCount() {
        return SemesterTranscriptModels.size();
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return SemesterTranscriptModels.get(groupPosition).getSectionTranscriptModel().size();
    }

    @Override
    public Object getGroup(int groupPosition) {
        return SemesterTranscriptModels.get(groupPosition);
    }

    @Override
    public Object getChild(int groupPosition, int childPosition) {
        return SemesterTranscriptModels.get(groupPosition).getSectionTranscriptModel().get(childPosition);
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    @Override
    public View getGroupView(int groupPosition, boolean b, View convertView, ViewGroup viewGroup) {
        SemesterTranscriptModel semesterModel = ((SemesterTranscriptModel) getGroup(groupPosition));

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.item_semester_transcript_list, null);
        }
        convertView.setBackgroundColor(ContextCompat.getColor(context,R.color.parent_transcript));

        TextView tvName = (TextView) convertView.findViewById(R.id.tv_semesterName);
        TextView tvInfor = (TextView) convertView.findViewById(R.id.tv_semesterInfor);
        tvName.setText(semesterModel.getSemesterName());
        String infor = "credit: " + semesterModel.getCredit() + " || GPA:" + semesterModel.getGPA();
        tvInfor.setText(infor);

        return convertView;
    }

    @Override
    public View getChildView(int groupPosition, int childPosition, boolean b, View convertView, ViewGroup viewGroup) {
        final SectionTranscriptModel sectionTranscript = ((SectionTranscriptModel) getChild(groupPosition, childPosition));

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.item_section_transcript_list, null);
        }
        convertView.setBackgroundColor(ContextCompat.getColor(context,R.color.child_transcript));

        TextView tvSectionID = (TextView) convertView.findViewById(R.id.tvSectionID);
        TextView tvStatus = (TextView) convertView.findViewById(R.id.tvStatus);
        TextView tvInfor = (TextView) convertView.findViewById(R.id.tvSectionInfor);
        tvSectionID.setText(sectionTranscript.getSectionID());
        tvStatus.setText(sectionTranscript.getStatus());
        String infor = "credit: " + sectionTranscript.getCredit() + " || GPA:" + sectionTranscript.getGPA();
        tvInfor.setText(infor);

        convertView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(context, "it's work" , Toast.LENGTH_LONG).show();
            }
        });

        return convertView;
    }

    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return false;
    }
}
