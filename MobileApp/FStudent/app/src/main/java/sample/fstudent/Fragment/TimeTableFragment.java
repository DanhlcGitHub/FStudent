package sample.fstudent.Fragment;

import android.content.res.Configuration;
import android.graphics.Color;
import android.graphics.drawable.LayerDrawable;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.text.Html;
import android.text.Spanned;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewTreeObserver;
import android.widget.GridLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import sample.fstudent.R;
import sample.fstudent.Repository.SectionSchedule;

public class TimeTableFragment extends Fragment {
    private List<SectionSchedule> dataLists;
    private SectionSchedule[] sectionList;
    private int[] defaultColor = {R.color.tt_1, R.color.tt_2, R.color.tt_3, R.color.tt_4, R.color.tt_5,
            R.color.tt_6, R.color.tt_7};
    HashMap<String, Integer> colorMap;
    private int pageIndex = 0;
    TextView[] myViews;
    private int numOfCol = 4;
    private int numOfRow = 7;
    private boolean isLandscapeMode = false;


    GridLayout myGridLayout;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Bundle bundle = this.getArguments();
        Configuration config = getResources().getConfiguration();
        if (config.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            initDataLand(bundle);
            isLandscapeMode = true;
        } else {
            initData(bundle);
        }

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.timetable_fragment, container, false);


        myGridLayout = (GridLayout) view.findViewById(R.id.mygrid);
        myGridLayout.setColumnCount(numOfCol);
        myGridLayout.setRowCount(numOfRow);

        myViews = (TextView[]) new TextView[numOfCol * numOfRow];
        for (int yPos = 0; yPos < numOfRow; yPos++) {
            for (int xPos = 0; xPos < numOfCol; xPos++) {
                TextView tView = new TextView(getActivity());
                tView.setTextColor(Color.parseColor("#FFFFFF"));


                if (yPos == 0 & xPos != 0) {// day of week row
                    tView.setBackgroundColor(getResources().getColor(R.color.hotPink));
                    String header = "Mon";
                    header = getHeader(xPos);
                    tView.setText(header);
                } else if (xPos == 0 & yPos != 0) {// slot column
                    tView.setBackgroundColor(getResources().getColor(R.color.hotPink));
                    tView.setText("Slot:" + yPos);
                } else if (xPos == 0 && yPos == 0) {// null cell
                    tView.setBackgroundColor(getResources().getColor(R.color.hotPink));
                } else {
                    tView.setBackgroundColor(getResources().getColor(R.color.iron));
                    SectionSchedule sec = sectionList[yPos * numOfCol + xPos];
                    if (sec != null) {
                        Spanned html = Html.fromHtml(
                                "<b>" + sec.getSectionId() + "</b> <br/> " + sec.getRoom() + ""
                        );
                        tView.setText(html);
                        tView.setBackgroundColor(getResources().getColor(colorMap.get(sec.getSectionId())));
                    }
                }

                tView.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        Toast.makeText(getActivity(), "tada", Toast.LENGTH_SHORT).show();
                    }
                });

                myViews[yPos * numOfCol + xPos] = tView;

                myGridLayout.addView(tView);
            }
        }

        //myGridLayout.getViewTreeObserver().addOnPreDrawListener(new );
        final ViewTreeObserver obs = myGridLayout.getViewTreeObserver();
        final ViewTreeObserver.OnGlobalLayoutListener treeListener = new ViewTreeObserver.OnGlobalLayoutListener() {

            @Override
            public void onGlobalLayout() {
                final int null_cell_width = 100;
                final int null_cell_height = 50;

                final int MARGIN = 2;

                int pWidth = myGridLayout.getWidth();
                int pHeight = myGridLayout.getHeight();
                int numOfCol = myGridLayout.getColumnCount();
                int numOfRow = myGridLayout.getRowCount();
                int w = (pWidth - null_cell_width) / (numOfCol - 1);
                int h = (pHeight - null_cell_height) / (numOfRow - 1);

                for (int yPos = 0; yPos < numOfRow; yPos++) {
                    for (int xPos = 0; xPos < numOfCol; xPos++) {
                        GridLayout.LayoutParams params =
                                (GridLayout.LayoutParams) myViews[yPos * numOfCol + xPos].getLayoutParams();
                        if (yPos == 0 & xPos != 0) {// day of week row
                            params.width = w - 2 * MARGIN;
                            params.height = null_cell_height;
                        } else if (xPos == 0 & yPos != 0) {// slot column
                            params.width = null_cell_width;
                            params.height = h - 2 * MARGIN;
                        } else if (xPos != 0 && yPos != 0) {//normal cell
                            params.width = w - 2 * MARGIN;
                            params.height = h - 2 * MARGIN;
                        } else if (xPos == 0 && yPos == 0) {//null cell
                            params.width = null_cell_width;
                            params.height = null_cell_height;
                        }
                        params.setMargins(MARGIN, MARGIN, MARGIN, MARGIN);

                        myViews[yPos * numOfCol + xPos].setLayoutParams(params);
                    }
                }
                myGridLayout.getViewTreeObserver().removeGlobalOnLayoutListener(this);
            }
        };
        obs.addOnGlobalLayoutListener(treeListener);

        return view;
    }

    private void initData(Bundle bundle) {
        dataLists = new ArrayList<>();
        sectionList = (SectionSchedule[]) new SectionSchedule[numOfCol * numOfRow];
        pageIndex = bundle.getInt("pageIndex");
        String jsonData = bundle.getString("data");
        dataLists = (ArrayList<SectionSchedule>) fromJson(jsonData,
                new TypeToken<ArrayList<SectionSchedule>>() {
                }.getType());


        for (int i = dataLists.size() - 1; i >= 0; i--) {
            int dayOfWeek = getDateOfWeek(dataLists.get(i).getDate());
            if (pageIndex == 0) {
                if (dayOfWeek > 4) {
                    dataLists.remove(i);
                }
            } else if (pageIndex == 1) {
                if (dayOfWeek <= 4) {
                    dataLists.remove(i);
                }
            }
        }

        setupColorMap();

        for (SectionSchedule item : dataLists) {
            int yPos = 0;
            int xPos = 0;
            int dayOfWeek = getDateOfWeek(item.getDate());
            if (dayOfWeek <= 4) {
                xPos = dayOfWeek - 2 + 1;// monday will be column = 2 - 2 + 1 = 1 ; + 1 because slot need one column
            } else {
                xPos = dayOfWeek - 5 + 1;
            }
            yPos = item.getSlot();
            sectionList[yPos * numOfCol + xPos] = item;
        }

        //myViews[yPos*numOfCol + xPos] = tView;
    }

    private void initDataLand(Bundle bundle) {
        dataLists = new ArrayList<>();
        numOfCol = 7;
        numOfRow = 7;

        sectionList = (SectionSchedule[]) new SectionSchedule[numOfCol * numOfRow];

        String jsonData = bundle.getString("data");
        dataLists = (ArrayList<SectionSchedule>) fromJson(jsonData,
                new TypeToken<ArrayList<SectionSchedule>>() {
                }.getType());

        setupColorMap();

        for (SectionSchedule item : dataLists) {
            int yPos = 0;
            int xPos = 0;
            int dayOfWeek = getDateOfWeek(item.getDate());
            xPos = dayOfWeek - 2 + 1;// monday will be column = 2 - 2 + 1 = 1 ; + 1 because slot need one column
            yPos = item.getSlot();
            sectionList[yPos * numOfCol + xPos] = item;
        }

        //myViews[yPos*numOfCol + xPos] = tView;
    }

    private int getDateOfWeek(Date date) {
        Calendar c = Calendar.getInstance();
        c.setTime(date);
        int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);
        return dayOfWeek;
    }

    private void setupColorMap() {
        colorMap = new HashMap<String, Integer>();
        for (int i = 0; i < dataLists.size(); i++) {
            SectionSchedule sec = dataLists.get(i);
            if (colorMap.containsKey(sec.getSectionId())) {
                // Okay, there's a key but the value is null
            } else {
                colorMap.put(sec.getSectionId(), defaultColor[colorMap.size()]);
            }
        }
    }

    public String getHeader(int xPos) {
        String header = "Mon";
        if (isLandscapeMode == true) {
            switch (xPos) {
                case 1:
                    header = "Mon";
                    break;
                case 2:
                    header = "Tues";
                    break;
                case 3:
                    header = "Wed";
                    break;
                case 4:
                    header = "Thurs";
                    break;
                case 5:
                    header = "Fri";
                    break;
                case 6:
                    header = "Sat";
                    break;
            }
        } else {
            if (pageIndex == 0) {
                switch (xPos) {
                    case 1:
                        header = "Mon";
                        break;
                    case 2:
                        header = "Tues";
                        break;
                    case 3:
                        header = "Wed";
                        break;
                }
            } else if (pageIndex == 1) {
                switch (xPos) {
                    case 1:
                        header = "Thurs";
                        break;
                    case 2:
                        header = "Fri";
                        break;
                    case 3:
                        header = "Sat";
                        break;
                }
            }
        }
        return header;
    }

    public static Object fromJson(String jsonString, Type type) {
        return new Gson().fromJson(jsonString, type);
    }
}
