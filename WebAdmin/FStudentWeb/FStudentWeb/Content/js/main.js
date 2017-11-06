function checkLogin() {
    var username = document.getElementById("username_id");
    var password = document.getElementById("password_id");
    console.log(username.value);
    $.ajax({
        url: 'CheckLogin',
        type: 'POST',
        contentType: 'application/json;',
        data: JSON.stringify({ username: username.value, password: password.value }),
        success: function (valid) {
            if (valid.valid) {
                window.location.replace("Index");
            } else {
                alert("Wrong username or password!");
            }
        }
    });
}

function UpdateGrade(currentButton,sectionID) {
    var studentID = document.getElementById("studentID");
    var sectionID = sectionID;
    var grade = currentButton.parentElement.previousElementSibling.childNodes[0].value;
    $.ajax({
        url: 'UpdateGrade',
        type: 'POST',
        contentType: 'application/json;',
        data: JSON.stringify({ studentID: studentID.value, sectionID: sectionID,GPA : grade }),
        success: function (valid) {
            if (valid.valid) {
                //window.location.replace("Index");
                location.reload();
            } else {
                alert("Can't update!");
            }
        }
    });
}

function test() {
    alert("it's work");
}