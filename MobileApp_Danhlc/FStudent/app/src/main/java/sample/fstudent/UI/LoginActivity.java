package sample.fstudent.UI;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;

import sample.fstudent.Common.Constant;
import sample.fstudent.R;
import sample.fstudent.Service.StudentReceiver;
import sample.fstudent.Service.StudentService;

public class LoginActivity extends AppCompatActivity implements StudentReceiver.Receiver {
    private static final String TAG = "LoginActivity";
    private static final int REQUEST_SIGNUP = 0;
    private int loginStatus = 0;
    public StudentReceiver mReceiver;

    EditText _emailText;
    EditText _passwordText;
    Button btnLogin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_login);

        getIDs();
        setEventListener();
        callGetSemesterService();
    }

    public void getIDs(){
        btnLogin = (Button) findViewById(R.id.btn_login);
        _emailText = (EditText) findViewById(R.id.input_email);
        _passwordText = (EditText) findViewById(R.id.input_password);
    }

    public void setEventListener(){
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Intent k = new Intent(LoginActivity.this, HomeActivity.class);
                //startActivity(k);
                //login();
                callLoginService();
            }
        });
    }

    public void login() {
        Log.d(TAG, "Login");

        if (!validate()) {
            onLoginFailed();
            return;
        }

        btnLogin.setEnabled(false);

        final ProgressDialog progressDialog = new ProgressDialog(LoginActivity.this,
                R.style.AppTheme_Dark_Dialog);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Authenticating...");
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
                }, 500);
    }

    @Override
    public void onBackPressed() {
        // disable going back to the MainActivity
        moveTaskToBack(true);
    }

    public void onLoginSuccess() {
        btnLogin.setEnabled(true);
        Constant.StudentID = _emailText.getText().toString();
        Intent k = new Intent(LoginActivity.this, HomeActivity.class);
        startActivity(k);
    }

    public void onLoginFailed() {
        Toast.makeText(getBaseContext(), "Login failed", Toast.LENGTH_LONG).show();

        btnLogin.setEnabled(true);
    }

    public boolean validate() {
        boolean valid = true;

        String email = _emailText.getText().toString();
        String password = _passwordText.getText().toString();

        if (email.isEmpty()) {
            _emailText.setError("enter a valid email address");
            valid = false;
        } else {
            _emailText.setError(null);
        }

        if (password.isEmpty() || password.length() < 4 || password.length() > 10) {
            _passwordText.setError("between 4 and 10 alphanumeric characters");
            valid = false;
        } else {
            _passwordText.setError(null);
        }

        if(loginStatus < 0){
            valid = false;
        }

        return valid;
    }

    @Override
    public void onReceiveResult(int resultCode, Bundle resultData) {
        switch (resultCode) {
            case Constant.STATUS_RUNNING:
                //show progress
                //progressDialog.show();
                break;
            case Constant.STATUS_FINISHED:
                String status = resultData.getString("loginStatus");
                String semesterID = resultData.getString("semesterID");
                if(status!=null) {
                    loginStatus = Integer.parseInt(status);
                    login();
                }else if(semesterID!=null){
                    Constant.CurrentSemester = Integer.parseInt(semesterID);
                }
                break;
            case Constant.STATUS_ERROR:
                // handle the error;
                break;
        }
    }

    public void callLoginService(){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getBaseContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "studentLoginService");
        String s = _emailText.getText().toString();
        intent.putExtra("StudentID", _emailText.getText().toString());
        intent.putExtra("Password", _passwordText.getText().toString());

        getBaseContext().startService(intent);
    }

    public void callGetSemesterService(){
        mReceiver = new StudentReceiver(new Handler());
        mReceiver.setReceiver(this);

        final Intent intent = new Intent(Intent.ACTION_SYNC, null, getBaseContext(), StudentService.class);
        intent.putExtra("receiver", mReceiver);
        intent.putExtra("command", "PostGetCurrentSemester");

        getBaseContext().startService(intent);
    }
}
