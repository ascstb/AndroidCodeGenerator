$(document).ready(function () {
    $("#txtAppName, #txtPackageName, #txtBaseUrl").blur(function () {
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

function callAPI() {
    var url = "Android.aspx/GenerateAndroidCode";
    var dataRepositories = [];
    $.each($("input[type=checkbox]:checked"), function (key, checkbox) {
        dataRepositories.push(checkbox.value);
    });

    var params = JSON.stringify({
        appName: $("#txtAppName").val(),
        appPackageName: $("#txtPackageName").val(),
        contentTypeActivities: $("#rblContentTypeActivities").prop('checked'),
        dataRepositories: dataRepositories.join(),
        baseUrl: $("#txtBaseUrl").val(),
        model: $("#txtModel").val(),
        jsonString: $("#txtJsonModel").val()
    });

    var result = RunAjax(url, params);

    if (result == undefined || result == null || result.trim().length == 0) {
        swal("No Result");
    } else {
        swal(result);
    }
}