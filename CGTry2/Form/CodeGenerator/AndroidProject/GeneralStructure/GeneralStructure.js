$(document).ready(function () {
    setAppNameChange();

    $("#btnGenerate").click(function () {
        callAPI();
    });
});

function setAppNameChange() {
    $("#txtAppName").change(function () {
        var txtPackageName = $("#txtPackageName");
        var tempPackage = txtPackageName.val().toLowerCase();
        var split = tempPackage.split(".");
        var result = "";

        for (let i = 0; i < split.length - 1; i++) {
            result += split[i] + ".";
        }

        result += $(this).val().toLowerCase();
        txtPackageName.val(result);
    });
}

function callAPI() {
    var url = "GeneralStructure.aspx/GenerateProjectStructure";
    
    var params = JSON.stringify({
        appName: $("#txtAppName").val(),
        appPackageName: $("#txtPackageName").val(),
        securityType: $("#rblSecurityType").prop('checked')
    });

    var result = RunAjax(url, params);

    if (result == undefined || result == null || result.trim().length == 0) {
        swal("No Result");
    } else {
        swal(result);
    }
}