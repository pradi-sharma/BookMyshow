
function RegisterValidate() {
    var username = document.getElementById("username2").value;
    var password = document.getElementById("password2").value;
    var confirmpassword = document.getElementById("confirmpassword2").value;
    var contactno = document.getElementById("contactno").value;
    var email2 = document.getElementById("email2").value;

    var cont_pattr = /^[6-9]\d{9}$/;
    var pass_pattern = /^(?=.*[0-9])(?=.*[!#$%^&*])[a-zA-Z0-9!#$%^&*]{8,16}$/;
 //   var resaddress_pattern = /^[a-zA-Z0-9\s,'-]*$/;
    var email_pattern = /[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}/;

    if (username == "" && password == "" && confirmpassword == "" && contactno == "" && email2 == "") {
        document.getElementById("uname_errors").innerHTML = "*UserName Number is required";
        document.getElementById("rpassword_errors").innerHTML = "*Password is required";
        document.getElementById("rconfirm_password_errors2").innerHTML = "*Confirm password is required";
        document.getElementById("contacts_errors").innerHTML = "*Contact number is required";
        document.getElementById("remails_errors").innerHTML = "*Email ID is required";
        return false;
    }

    if (username =="") {
        document.getElementById("uname_errors").innerHTML = "*Contact Number is required";
        return false;
    }
    document.getElementById("uname_errors").innerHTML = "";
    if (!cont_pattr.test(contactno)) {
        
        document.getElementById("contacts_errors").innerHTML = "*Contact Should be in proper format";
        return false;
    }
    document.getElementById("contacts_errors").innerHTML = "";


    if (password == "") {
        document.getElementById("rpassword_errors").innerHTML = "*Password is required";
        return false;
    }

    document.getElementById("rpassword_errors").innerHTML = "";
   



    if (email2 == "") {
        document.getElementById("remails_errors").innerHTML = "*Email ID is required";
        return false;
    }

    if (!email_pattern.test(email2)) {
        document.getElementById("remails_errors").innerHTML = "*Email ID should be in proper format";
        return false;
    }

    else {

        return true;
    }
}
