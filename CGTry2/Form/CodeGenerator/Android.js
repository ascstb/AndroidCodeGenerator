$(document).ready(function () {
    $("#txtAppName, #txtPackageName").blur(function () {
        if ($(this).val().length == 0) {
            $(this).parent().parent().addClass("has-error");
        } else {
            $(this).parent().parent().removeClass("has-error");
        }

        validateButton()
    });

    $("#txtAppName").change(function () {
        $("#txtPackageName").val("com.example." + $(this).val().toLowerCase());
    });

    $("#btnGenerate").click(function () {
        callAPI();
    });
});

function validateButton() {
    if ($(".has-error").length > 0) {
        $("#btnGenerate").addClass("disabled");
    } else {
        $("#btnGenerate").removeClass("disabled");
    }
}

function validForm() {
    var txtAppName = $("#txtAppName");
    var txtPackageName = $("#txtPackageName");
    var rblContentTypeActivities = $("#rblContentTypeActivities");
    var rblContentTypeFragments = $("#rblContentTypeFragments");
}

function callAPI() {
    var url = "Android.aspx/GenerateAndroidCode";

    var params = JSON.stringify({
        appName: $("#txtAppName").val(),
        appPackageName: $("#txtPackageName").val(),
        contentTypeActivities: $("#rblContentTypeActivities").prop('checked')
    });

    var result = RunAjax(url, params);

    if (result == undefined || result == null || result.trim().length == 0) {
        alert("No Result");
    } else {
        alert(result);
    }
}