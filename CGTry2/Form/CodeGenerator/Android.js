$(document).ready(function () {
    //API parameters
    var url = "Android.aspx/Hi";
    var params = "";
    var result = RunAjax(url, params);

    if (result == undefined || result == null || result.trim().length == 0) {
        alert("No Result");
    } else {
        alert(result);
    }
});