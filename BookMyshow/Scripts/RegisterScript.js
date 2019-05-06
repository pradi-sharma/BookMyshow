$(function () {

    $("#name_errors").hide();
    $("#password_errors").hide();
    $("#confirm_password_errors2").hide();
    $("#contacts_errors").hide();
    $("#emails_errors").hide();




    var name_error = false;
    var password_error = false;
    var confirm_password_error = false;
    var contact_error = false;
    var email_error = false;

    $("#username2").focusout(function () {
        check_name_error();
    });
    $("#password2").focusout(function () {
        check_password_error();
    });
    $("#confirmpassword2").focusout(function () {
        check_confirm_password_error();
    });
    $("#contacts").focusout(function () {
        check_contact_error();
    });
    $("#email2").focusout(function () {
        check_email_error();
    });

    function check_name_error() {

        var name = $("#username2").val();
        if (name !== '') {
            $("#name_errors").hide();
            $("#username2").css("border-bottom", "2px solid #34F458");
        } else {
            $("#name_errors").html("Should Contains Character Only");
            $("#name_errors").show();
            $("#username2").css("border-bottom", "2px solid #F90A0A");
            name_error = true;
        }
    }

    function check_password_error() {
        var Password = $("#password2").val();
        var Password_length = Password.length;

        if (Password_length < 8) {
            $("#password_errors").html("Atleast 8 characters");
            $("#password_errors").show();
            $("#password2").css("border-bottom", "2px solid red");

        } else {
            $("#password_errors").hide();
            $("#password2").css("border-bottom", "2px solid green");
            password_error = true;
        }

    }
    function check_confirm_password_error() {
        var Password = $("#password2").val();
        var Retype_Password = $("#confirmpassword2").val();
        if (Password != Retype_Password) {
            $("#confirm_password_errors2").html("Passwords did not matched");
            $("#confirm_password_errors2").show();
            $("#confirmpassword2").css("border-bottom", "2px solid red");
            confirm_password_error = true;
        } else {
            $("#confirm_password_errors2").hide();
            $("#confirmpassword2").css("border-bottom", "2px solid green");

        }
    }

    function check_contact_error() {
        var contact = $("#contacts").val();
        var contact_length = contact.length;

        if (contact_length > 10) {

            $("#contacts_errors").hide();
            $("#contacts").css("border-bottom", "2px solid #34F458");
            contact_error = true;
        } else {
            $("#contacts_errors").html("Enter Contact in proper format");
            $("#contacts_errors").show();
            $("#contacts").css("border-bottom", "2px solid #F90A0A");

        }
    }
    function check_email_error() {
        var Pattern = "[a-zA-Z0-9._%+-]@@+[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
        var email = $("#email2").val();
        if (Pattern.test(email) && email != " ")
        {
            $("#emails_errors").hide();
            $("#email2").css("border-bottom", "2px solid #34F458");
            email_error = true;
        }
        else {
            $("#emails_errors").html("Enter Valid EmailID");
            $("#emails_errors").show();
            $("#email2").css("border-bottom", "2px solid #F90A0A");
            
        }
    }
    $("#submitbtn").click(function () {
        
        name_error = false;
        password_error = false;
        confirm_password_error = false;
        contact_error = false;
        email_error = false;


        check_name_error();
        check_password_error();
        check_confirm_password_error();
        check_contact_error();
        check_email_error();

        if (name_error === false && password_error === false && confirm_password_error === false &&
            contact_error === false && email_error === false) {

            alert("Registration done");
            return true;
        }
        else {
            alert("please fill the form correctly");
            return false;
        }
    })

})