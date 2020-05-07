function RunAjax(varUrl, varData) {
    var res;

    $.ajax({
        type: "POST",
        url: varUrl,
        data: varData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        cache: false,
        success: function (response) {
            res = response.d;
        },
        failure: function (response) {
            alert("Failure: " + response.d);
        },
        error: function (XMLHttpRequest, success, errorThrown) {
            alert("Error" + XMLHttpRequest.responseText + ' ' + errorThrown)
        }
    });

    return res;
}

function QueryString(name) {
    var url = location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
