package sample.fstudent.Fragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import sample.fstudent.R;


public class ProfileFragment extends Fragment {
    TextView tv_name;
    TextView tv_id;
    TextView tv_birthday;
    TextView tv_gender;
    TextView tv_address;
    TextView tv_phone;
    TextView tv_email;

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

        return view;
    }


}
