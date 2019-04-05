

function validate() {



    if ($("[pass]").val() == "") {

        $("#vsSummary").html("Enter the password");
        $("#vsSummary").css("display", "block");
    }

   else if ($("[pass]").val() !== $("[passconfirm]").val()) {


        $("#vsSummary").html("password dosent much");
        $("#vsSummary").css("display", "block");
    }
    else {
        $("#ChangePasswordForm").submit();
    }


};