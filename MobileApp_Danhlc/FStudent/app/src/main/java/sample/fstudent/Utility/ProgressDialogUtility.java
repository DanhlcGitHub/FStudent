package sample.fstudent.Utility;

import android.app.ProgressDialog;
import android.content.Context;

import sample.fstudent.R;
import sample.fstudent.UI.LoginActivity;

/**
 * Created by gmtco on 10/16/2017.
 */

public class ProgressDialogUtility {

    public void showProgressDialog(Context context,String message){
       /* final ProgressDialog progressDialog = new ProgressDialog(context,
                R.style.AppTheme_Dark_Dialog);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage(message);
        progressDialog.show();

        String email = _emailText.getText().toString();
        String password = _passwordText.getText().toString();

        // TODO: Implement your own authentication logic here.

        new android.os.Handler().postDelayed(
                new Runnable() {
                    public void run() {
                        // On complete call either onLoginSuccess or onLoginFailed
                        onLoginSuccess();
                        // onLoginFailed();
                        progressDialog.dismiss();
                    }
                }, 500);*/
    }
}
