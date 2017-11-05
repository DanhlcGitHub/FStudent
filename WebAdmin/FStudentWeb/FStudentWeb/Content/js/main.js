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

function test() {
    alert("it's work");
}