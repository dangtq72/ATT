function xcaptchaSetCaptchaImage(solutionUrl, imageUrl) {
    $.ajaxSetup({ cache: false });
    $.get(solutionUrl, null,
        function (data) {
            var src = imageUrl + data;
            $('#-xcaptcha-hidden').val(data);
            $('#-xcaptcha-image').attr("src", src);
        }
    );
}

//$('#-xcaptcha-refresh').click(function (evt) {
//    //var charCode = (evt.which) ? evt.which : event.keyCode;
//    var txtU = $('#UserName').val();
//    var txtP = $('#Password').val();
//    var txtC = $('#Attempt').val();
//    if (txtU.length <= 0 || txtP.length <= 0 || txtC.length <= 0)
//        xcaptchaChangeCaptchaImage();
//    return false;
//});