package sample.fstudent.Utility;


import sample.fstudent.R;

public class TabMessage {
    public static String get(int menuItemId, boolean isReselection) {
        String message = "";

        switch (menuItemId) {
            case R.id.tab_schedule:
                message += "schedule";
                break;
            case R.id.tab_transcript:
                message += "transcript";
                break;
            case R.id.tab_news:
                message += "news";
                break;
            case R.id.tab_profile:
                message += "profile";
                break;
            case R.id.tab_food:
                message += "food";
                break;
        }

        if (isReselection) {
            message += " WAS RESELECTED! YAY!";
        }

        return message;
    }
}
