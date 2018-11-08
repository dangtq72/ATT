var selectingLanguage = false;

function selectLanguage() {
	try {
		$('.language-selection > ul > li').last().on("click",
			function () {
				window.cookieLanguage = $(this).attr('data-cookie');
				window.location.href = $(this).attr('data-language');
			});

		$('.language-selection > ul > li > .icon-select-language').first().on("click", function () {
			var optionItem = $('.language-selection > ul > li').last();
			if (optionItem.hasClass('hidden')) {
				selectingLanguage = true;
			} else {
				selectingLanguage = false;
			}
			if (selectingLanguage) {
				$(optionItem).last().removeClass('hidden');
				selectingLanguage = true;
			}
		});
	} catch (err){ }
}

$(document).click(function (e) {
    var ulLanguage = $(".language-selection > ul").first();
    var oppositer = $('.language-selection > ul > li > .icon-select-language').first();
    var optionItem = $('.language-selection > ul > li').last();
    if ((!ulLanguage.is(e.target) && ulLanguage.has(e.target).length === 0)
        || (oppositer.is(e.target) && oppositer.has(e.target).length === 0 && !optionItem.hasClass('hidden') && !selectingLanguage)) {
        $(optionItem).addClass('hidden');
    }

    var container = $("#popup-com-message-home").parent();
    if (!container.is(e.target) && container.has(e.target).length === 0) {
        $("#popup-com-message-home").addClass('hidden');
    }

    var containerAccountInfo = $("#popup-user-info").parent();
    if (!containerAccountInfo.is(e.target) && containerAccountInfo.has(e.target).length === 0) {
        hidePopupUserInfo();
    }
});

// ---------------------------------------    Loading    -----------------------------------------------
function waitForLoading(val) {
    if (val) {
        $('body').append(
            '<div class="loading-container"><div class="loading-opacity"></div><div class="circle-loading"></div><div class="circle-loading-inner"></div></div>');
    } else {
        $('.loading-container').remove();
    }
}

function getCurrentDate() {
    var currentdate = new Date();
    var datetime = currentdate.getDate() + "/" + (currentdate.getMonth() + 1) + "/" + currentdate.getFullYear() + " @ "
        + currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds();
    return datetime;
}

function SpinLoading($create) {
    $create = $create || false;
    if ($create) {
        var _loader = '<div class="load-container"><div class="load-background"><div class="loader"></div><p>Loading...</p></div></div>';
        $('body').append(_loader);
    }
    else {
        $('.load-container').remove();
    }
}

function HourGlassProcessing($create) {
    $create = $create || false;
    if ($create) {
        var _loader = '<div class="load-container"><div class="load-background"><div class="loading"><div class="hourglass"><div class="hourglass-top"><div class="sand-top"></div></div><div class="hourglass-bottom"><div class="sand-bottom"></div></div></div></div><p>Processing...</p></div></div>';
        $('body').append(_loader);
    }
    else {
        $('.load-container').remove();
    }
}


// ---------------------------------------    Input    ----------------------------------------------
function limitMaxlength(el, maxlength) {
    if ($(el).val().length > maxlength) {
        $(el).val($(el).val().substring(0, maxlength));
    }
}

function limitValueInInputNumber(el, minValue) {
    var inputValue = $(el).val();
    if (inputValue !== "") {
        if (isNaN(inputValue) || inputValue / 1 < minValue || inputValue / 1 > 999999999) {
            inputValue = 1;
            $(el).val(inputValue);
        }
        var indexOfDot = (inputValue + "").indexOf(".");
        if (indexOfDot !== -1) {
            $(el).val(inputValue.substr(0, indexOfDot));
        }
    } else {
        $(el).val(inputValue);
    }
}

function reFillWithNotValidNumberInputData(el, defaultValue) {
    var inputValue = $(el).val();
    if (inputValue === "" || isNaN(inputValue) || inputValue / 1 < 0 || inputValue / 1 > 999999999) {
        $(el).val(defaultValue);
    }
}

function limitInputByOnlyNumber(_inputval, _control_id) {
    if (_inputval.indexOf(".") !== -1) {
        while (_inputval.indexOf(".") > -1) {
            _inputval = _inputval.replace(".", "");
        }
    }
    var _temp_input_val = "";
    var _childtemp_input_val = "";
    var _Regex = new RegExp("^[0-9,]+$");
    for (var i = 0; i < _inputval.length - 1; i++) {
        _childtemp_input_val += _inputval[i];
        if (_Regex.test(_childtemp_input_val)) {
            _temp_input_val = _childtemp_input_val;
        }
        else {
            $("input[id=" + _control_id + "]").val(_temp_input_val);
            return;
        }
    }
    if (!_Regex.test(_inputval)) {
        _inputval = _temp_input_val;
    }

    _inputval = _inputval.replace(/[,]/g, "");
    while (_inputval.indexOf(0) === "0" && _inputval.length > 1) {
        _inputval = _inputval.substring(1);
    }
    var ctrl = document.getElementById(_control_id);

    var before_length = ctrl.value.length;
    var key_index = doGetCaretPosition(ctrl);

    var x = _inputval.split(",");
    var x1 = x[0];
    var x2 = x.length > 1 ? x[1] : "";
    var result = x1 + x2;
    $("input[id=" + _control_id + "]").val(result);

    var after_length = document.getElementById(_control_id).value.length;
    setCaretPosition(ctrl, key_index + (parseInt(after_length) - parseInt(before_length)));
}

function inputPositiveInteger(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    var _value = String.fromCharCode(charCode);
    if (!isNaN(_value)) {
        return true;
    }
    evt.preventDefault();
    return false;
}


// ----------------------------------------   Image    -------------------------------------
function imgError(image) {
    image.onerror = "";
    image.src = "/Content/Image/logo.jpg";
    return true;
}

function imgErrorMobile() {
    jQuery("img").one('error', function () {
        jQuery(this).attr("src", "/Content/Image/logo.jpg");
    }).each(function () {
        if (this.complete && !this.naturalHeight && !this.naturalWidth) {
            $(this).triggerHandler('error');
        }
    });
}


// ---------------------------------------    Popup    --------------------------------------
function ShowPopupDialog(divWrapperPopup, Title, pWidth, pHeight, txtIdFocus) {
    pWidth = pWidth || 0;
    pHeight = pHeight || 0;
    txtIdFocus = txtIdFocus || "";

    var _height = pHeight + "px";
    if (pHeight === 0) {
        _height = "auto";
    }
    var _width = pWidth + "px";
    if (pWidth === 0) {
        _width = "700px";
    }
    else if (pWidth === -1) {
        _width = "100%";
    }

    if ($("#" + divWrapperPopup + " .d-popup-header").length > 0) {
        $("#" + divWrapperPopup + " .d-popup-header").remove();
    }
    $("#" + divWrapperPopup + " .d-popup").prepend('<div class="d-popup-header"><div class="popup-title">' + Title + '</div><a onclick="ClosePopupDialog(\'' + divWrapperPopup + '\',true)" class="btn-exit-popup fa fa-remove"></button></div>');
    $("#" + divWrapperPopup + " .d-popup").css({ "height": _height, "width": _width, "min-width": _width });

    $("#" + divWrapperPopup).fadeIn(150).addClass('popup-flex');

    if (txtIdFocus !== "") {
        var idFocus = "#" + txtIdFocus;
        $(idFocus).focus().val($(idFocus).val());
    }
    else {
        $('#' + divWrapperPopup + ' .btn-exit-popup').focus();
    }
    $("body").addClass("hide-scroll");
    $(".d-container").addClass("hide-scroll-mobile");
    return true;
}

function ClosePopupDialog(divWrapperPopup, confirmClose) {
    confirmClose = confirmClose || false;
    if (confirmClose) {
        $("#" + divWrapperPopup).fadeOut(150);
        setTimeout(function () { $("#" + divWrapperPopup).removeClass('popup-flex'); }, 150);
        $("body").removeClass("hide-scroll");
    }
    else {
        $("#" + divWrapperPopup).fadeOut(150);
        setTimeout(function () { $("#" + divWrapperPopup).removeClass('popup-flex'); }, 150);
        $("body").removeClass("hide-scroll");
        $(".d-container").removeClass("hide-scroll-mobile");
    }
}

function CenterPopup(divWrapperPopup) {
    var _windown_h = $(window).height() - 50;
    var _height_ct = $("#" + divWrapperPopup + " .d-popup").height();
    var top = (_windown_h - _height_ct) / 2;
    $("#" + divWrapperPopup).css('margin-top', '0');
    $("#" + divWrapperPopup + " .d-popup").css('margin-top', top + 'px');
}

function ShowPopupDialog_0(divWrapperPopup, Title, pWidth, pHeight, txtIdFocus, contentRatio) {
    pWidth = pWidth || 0;
    pHeight = pHeight || 0;
    contentRatio = contentRatio || 100;
    txtIdFocus = txtIdFocus || "";

    var _height = pHeight + "px";
    if (pHeight === 0) {
        _height = "auto";
    }
    var _width = pWidth + "px";
    var _rightContentWidth = (pWidth * contentRatio / 100 - 40) + "px";
    var _leftContentWidth = (pWidth * (1 - contentRatio / 100)) + "px";
    if (pWidth === 0) {
        _width = "700px";
    }
    else if (pWidth === -1) {
        _width = "100%";
    }

    if ($("#" + divWrapperPopup + " .d-popup-header-0").length > 0) {
        $("#" + divWrapperPopup + " .d-popup-header-0").remove();
    }
    $("#" + divWrapperPopup + " .d-popup").prepend('<div class="div-left-content-popup" style="width:' + _leftContentWidth + '"></div>'
        + '<div class="d-popup-header-0" style="width:' + _rightContentWidth + '"><div class="popup-title">' + Title + '</div><a onclick="ClosePopupDialog(\'' + divWrapperPopup + '\',true)" class="btn-exit-popup fa fa-remove"></button></div>');
    $("#" + divWrapperPopup + " .d-popup").css({ "height": _height, "width": _width, "min-width": _width });

    $("#" + divWrapperPopup).fadeIn(150).addClass('popup-flex');

    if (txtIdFocus !== "") {
        var idFocus = "#" + txtIdFocus;
        $(idFocus).focus().val($(idFocus).val());
    }
    else {
        $('#' + divWrapperPopup + ' .btn-exit-popup').focus();
    }
    $("body").addClass("hide-scroll");
    $(".d-container").addClass("hide-scroll-mobile");
    return true;
}



// ---------------------------------------    Other    ------------------------
$.fn.enterKey = function (fnc) {
    return this.each(function () {
        $(this).keypress(function (ev) {
            ev = window.event || ev;
            var keycode = (ev.keyCode ? ev.keyCode : ev.which);
            if (keycode === '13') {
                fnc.call(this, ev);
            }
        });
    });
}

function toNumber(strNum, strDelemiter) {
    strDelemiter = strDelemiter || ',';
    return strNum.replace(eval('/' + strDelemiter + '/g'), '');
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

// fomat kiểu number có đấu , ở hàng nghìn và có cả phần thập phân
function jsFormatFloatNumber(el, lengthNumber, lengthFloat) {
    // format En-gb 123,456.78
    var _floatSeparator = '.';
    var _thousandSeparator = ',';
    if (window.cookieLanguage == 'VI-VN') {
        // format Vietnam: 123.456,78
        _floatSeparator = ',';
        _thousandSeparator = '.';
    }
    var nStr = $(el).val();
    var _IndexFloat = nStr.indexOf(_floatSeparator);
    var _PhanThapPhan = "";
    var _count_ = 0;
    var _Alltext = "";
    _count_ = (nStr.split(_floatSeparator).length - 1);
    if (_count_ > 1) {
        var Fst = nStr.indexOf(_floatSeparator);
        var Snd = nStr.indexOf(_floatSeparator, Fst + 1);
        nStr = nStr.substring(0, Snd);
    }
    if (_IndexFloat >= 0) {
        _PhanThapPhan = nStr.substring(_IndexFloat, nStr.length);
        if (_PhanThapPhan.length > lengthFloat + 1)
            _PhanThapPhan = _PhanThapPhan.substring(0, _PhanThapPhan.length - 1);
        nStr = nStr.substring(0, _IndexFloat);
    }

    var _Vondieule = "";
    _Vondieule = nStr;
    var _tempvondieule = "";
    var _newtemp = "";
    var _Regex = new RegExp("^[0-9,.]+$");
    _Alltext = _Vondieule + _PhanThapPhan;
    for (var i = 0; i < _Alltext.length; i++) {// cat het nhung ky tu khong phai la so
        _newtemp += _Alltext[i];
        if (_Regex.test(_newtemp)) {
            _tempvondieule = _newtemp;
        }
        else {
            $(el).val(_tempvondieule);
            return;
        }
    }
    if (_Regex.test(_Vondieule))//neu la so thi lay
    {
        _Vondieule = nStr;
    }
    else {
        _Vondieule = _tempvondieule;
    }
    nStr = _Vondieule;
    // cắt toàn bộ số 0 trước trường số
    var re = new RegExp("[" + _thousandSeparator + "]", "g");
    nStr = nStr.replace(re, '');
    while (nStr.indexOf(0) === "0" && nStr.length > 1) {
        nStr = nStr.substring(1);
    }

    var before_length = $(el).val().length; // lấy chiều dài trước khi thay đổi
    var key_index = doGetCaretPosition(el); // lấy vị trí con trỏ hiện tại

    var x = nStr.split(_thousandSeparator);
    var x1 = x[0];
    var x2 = x.length > 1 ? _thousandSeparator + x[1] : "";
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, "$1" + _thousandSeparator + "$2");
    }
    var result = x1 + x2;
    if (nStr.length > lengthNumber)
        result = result.substring(0, result.length - 1);

    $(el).val(result + _PhanThapPhan);

    var after_length = $(el).val().length; // lấy thay đổi chiều dài
    setCaretPosition(el, key_index + (parseInt(after_length) - parseInt(before_length))); // set vị trí con trỏ
}



// format number -> string voi thounsand separator la dau ',', khong co phan thap phan
function formatNumberToStringN1(_number) {
    try {
        if ($.type(_number).toLowerCase() === "number") {
            _number = _number.toFixed(0);
        }

        if (IsValidNumber(_number.replace(/,/g, ""), false) === true) {
            return _number.replace(/,/g, "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        }
        else {
            return _number;
        }
    } catch (e) {
        return _number;
    }
}

function jsgetCurrentDate() {
    var _date = new Date();
    var twoDigitMonth = ((_date.getMonth() + 1) < 10) ? '0' + (_date.getMonth() + 1) : (_date.getMonth() + 1);
    var towDigitDate = (_date.getDate() >= 10) ? (_date.getDate()) : '0' + (_date.getDate());
    //lay ngay theo dinh dang dd/MM/yyyy
    var cur_date = towDigitDate + "/" + twoDigitMonth + "/" + _date.getFullYear();
    return cur_date;
}
//------lấy vị trí hiện tại con trỏ trong textbox----------
function doGetCaretPosition(ctrl) {
    var CaretPos = 0;   // IE Support
    if (document.selection) {
        ctrl.focus();
        var Sel = document.selection.createRange();
        Sel.moveStart('character', -ctrl.value.length);
        CaretPos = Sel.text.length;
    }
    // Firefox support
    else if (ctrl.selectionStart || ctrl.selectionStart === '0')
        CaretPos = ctrl.selectionStart;
    return (CaretPos);
}

//------sét vị trí con trỏ trong textbox----------
function setCaretPosition(ctrl, pos) {
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos, pos);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos);
        range.moveStart('character', pos);
        range.select();
    }
}

// Drag table


//pIdDataTable :ID cua table 
//sử dụng khi scroll ngang table khi cuộn chuột
var dd = null;
var delta = 0;
var ddc = true;

function MouseScrollOnTable(pIdDataTable) {
    dd = document.getElementById(pIdDataTable).parentElement;
    delta = 0;
    ddc = true;

    //FF doesn't recognize mousewheel as of FF 3.x
    var isFirefox = (/Firefox/i.test(navigator.userAgent)) ? true : false;
    var mousewheelevt = isFirefox ? "DOMMouseScroll" : "mousewheel";
    $(dd).on(mousewheelevt, function (event) {
        ddc = true;
        event.preventDefault();
        if (dd.addEventListener) {
            if (isFirefox)
                dd.addEventListener(mousewheelevt, MouseWheelHandler, false);
            else
                dd.addEventListener(mousewheelevt, MouseWheelHandler(event), false);
        }
        else {
            if (isFirefox)
                dd.attachEvent("on" + mousewheelevt, MouseWheelHandler);
            else
                dd.attachEvent("on" + mousewheelevt, MouseWheelHandler(event));
        }
    });

    function MouseWheelHandler(e) {
        while (ddc === true) {
            e = window.event || e;
            // FF doesn't recognize event.wheelDelta = -120. Only event.detail = 3
            var _wheelDelta = e.detail ? e.detail * 40 : -e.wheelDelta;

            delta = dd.scrollLeft + (_wheelDelta / 2);


            var this_height = document.getElementById(pIdDataTable).offsetHeight;
            if (this_height > dd.offsetHeight)
                delta = delta < 0 ? 0 : delta > dd.scrollWidth + 17 - dd.offsetWidth ? dd.scrollWidth + 17 - dd.offsetWidth : delta;
            else
                delta = delta < 0 ? 0 : delta > dd.scrollWidth - dd.offsetWidth ? dd.scrollWidth - dd.offsetWidth : delta;

            $(dd).scrollLeft(delta);
            ddc = false;
        }
    }
}

//   Functions for handle check / uncheck at table list
function reInitArrItemId(arrItemId) {
    if (arrItemId.trim() === "") {
        arrItemId = "|";
    }
    return arrItemId;
}

function setupItemIdValueWhenCheckAll(el, arrItemId, markBy) {
    arrItemId = reInitArrItemId(arrItemId);
    if ($(el).is(':checked')) {
        $(markBy).each(function () {
            $(this).prop("checked", true);
            if (arrItemId.indexOf("|" + $(this).val() + "|") === -1) {
                arrItemId += $(this).val() + "|";
            }
        });
    } else {
        $(markBy).each(function () {
            $(this).prop("checked", false);
            arrItemId = arrItemId.replace("|" + $(this).val() + "|", "|");
        });
    }
    return arrItemId;
}

function setupItemIdValueWhenCheckOne(el, arrItemId, markByAll, markByOne) {
    arrItemId = reInitArrItemId(arrItemId);
    if ($(el).is(':checked')) {
        arrItemId += $(el).val() + "|";
    } else {
        arrItemId = arrItemId.replace("|" + $(el).val() + "|", "|");
    }

    remarkCheckAll(markByAll, markByOne);
    return arrItemId;
}

function remarkCheckAll(markByAll, markByOne) {
    if ($(markByOne).length === $(markByOne + ':checked').length && $(markByOne).length > 0) {
        $(markByAll).prop('checked', true);
    } else {
        $(markByAll).prop('checked', false);
    }
}

function getNumberOfIdInArrChecked(arrItemId) {
    var regM = /\|(?=.*[0-9])/g;
    return (arrItemId.match(regM) || []).length;
}



function showHideComplexControlTag(el) {
    if ($(el).hasClass('hidden-data')) {
        $(el).removeClass('hidden-data');
        $(el).text($(el).text().replace(/▼/g, '▲'));
        $(el).parent().parent().children('div').slideDown(200);
    } else {
        $(el).addClass('hidden-data');
        $(el).text($(el).text().replace(/▲/g, '▼'));
        $(el).parent().parent().children('div').slideUp(200);
    }
}

function logToProductDataMessageInfo(message) {
    try {
        $('#tsd-product-task-log-info').append(message);
    }
    catch (e) { }
}

function clearMessageLogProductData() {
    try {
        $('#tsd-product-task-log-info').html('');
    }
    catch (e) { }
}

function logToGLNMessageInfo(message) {
    try {
        $('#comParty-task-log-info').append(message);
    }
    catch (e) { }
}

function clearMessageLogGLN() {
    try {
        $('#comParty-task-log-info').html('');
    }
    catch (e) { }
}

function logToGCPMessageInfo(message) {
    try {
        $('#comPrefix-task-log-info').append(message);
    }
    catch (e) { }
}

function clearMessageLogGCP() {
    try {
        $('#comPrefix-task-log-info').html('');
    }
    catch (e) { }
}

function createTaskItemTabEditTsdProduct(titleTab, originalTaskTabId) {
    if (!window.canEditTsdProduct) {
        return false;
    }
    window.createEmptyNewTaskItem(titleTab, originalTaskTabId, true);
}

function editTsdProductInfo(el, originalTaskTabId) {
    if (!window.canEditTsdProduct) {
        return false;
    }
    var titleTab = $(el).attr("data-titleTab");
    var menuUrl = $(el).attr("data-url");

    var responseValidForEdit = false;
    var dataResponse;
    $.ajax({
        type: "POST",
        headers: { "cache-control": "no-cache" },
        url: menuUrl,
        data: { comItemId: window._tsdProductIdChecked.replace(/\|/g, ''), taskTabId: (window.taskTabId + 1) },
        async: false,
        //processData: false, contentType: false,
        success: function (data) {
            if (data != null) {
                if (onResponse(data)) {
                    var errorMessage = data['ErrorMessage'];
                    if (errorMessage != undefined) {
                        showError(errorMessage);
                        window.logToProductDataMessageInfo('<p>' + errorMessage + getCurrentDate() + '</p>');
                    } else {
                        responseValidForEdit = true;
                        dataResponse = data;
                    }
                }
            }
        }, error: function (e) {
            console.log(e);
        }
    });

    if (responseValidForEdit) {
        window.createTaskItemTabEditTsdProduct(titleTab, originalTaskTabId);
        $("#div-list-content-" + taskTabId).html(dataResponse);
        $('.chkListTsdProducts').each(function () {
            $(this).prop("checked", false);
        });
        window._tsdProductIdChecked = "";
        window.changeTaskTsdProductStatus();
    }

    return true;
}

function gotoEditTsdProductInfo(comItemId, titleTab, originalTaskTabId, isRefFromComRecord) {
    window.canEditTsdProduct = true;
    var responseValidForEdit = false;
    var dataResponse;
    $.ajax({
        type: "POST",
        headers: { "cache-control": "no-cache" },
        url: '/tsd-product-info/get-view-to-edit-tsd-product',
        data: { comItemId: comItemId, taskTabId: (window.taskTabId + 1) },
        async: false,
        //processData: false, contentType: false,
        success: function (data) {
            if (data != null) {
                if (onResponse(data)) {
                    var errorMessage = data['ErrorMessage'];
                    if (errorMessage != undefined) {
                        showError(errorMessage);
                        window.logToProductDataMessageInfo('<p>' + errorMessage + getCurrentDate() + '</p>');
                    } else {
                        responseValidForEdit = true;
                        dataResponse = data;
                    }
                }
            }
        }, error: function (e) {
            console.log(e);
        }
    });
    if (responseValidForEdit) {
		//if (isRefFromComRecord != undefined && isRefFromComRecord === true) {
		//	try {
		//		$('#li-task-tab-' + originalTaskTabId + ' .icon-close-task-tab').click();
		//	}catch(errRef){}
			
		//}
        window.createTaskItemTabEditTsdProduct(titleTab, originalTaskTabId);
        $("#div-list-content-" + window.taskTabId).html(dataResponse);
    }
    window.canEditTsdProduct = false;
    return true;
}

function getComItemRefFromComRecord(comRecordId) {
	var dataResult = null;
	try {
		$.ajax({
			type: "POST",
			headers: { "cache-control": "no-cache" },
			url: "/tsd-product-info/get-itemstatus-of-comitem-ref-from-comrecord",
			data: {
				comRecordId: comRecordId
			},
			async: false,
			success: function(data) {
				if (data != null) {
					if (onResponse(data)) {
						dataResult = data;
					}
				}
			}
		});
	} catch (err) {
	}
	return dataResult;
}

function getItemStatusOfComItemRefFromComRecord(comRecordId) {
	var dataResult = getComItemRefFromComRecord(comRecordId);
	var isComItemDataValidated = dataResult["result"];
	return isComItemDataValidated;
}

function gotoAddGTIN8FromRefLink(taskTabId, _comRecordId, gtinType, comId) {
    var extentData = { originalTab: taskTabId, comRecordId: _comRecordId, gtinType: gtinType, comId: comId };
    window.createNewTaskItemWithData($('#refLinkTaskAddGTIN8-' + taskTabId), extentData);
}

function initDateTimePicker() {
    try {
        $.datetimepicker.setLocale('vi');
        $('.datetimepicker').datetimepicker({
            timepicker: false,
            format: 'd/m/Y',
            //formatTime: 'H:i',
            formatDate: 'd/m/Y',
            //mask: '29:59 - 39/19/9999',
            mask: '39/19/9999',
            validateOnBlur: false
        });
    } catch (errordatepicker) {}
}

function destroyDateTimePicker() {
    try {
		destroyDateTimePicker();
	}catch(err){}
}

function reInitDateTimePicker() {
	try {
		if ($('.xdsoft_datetimepicker').length > 0) {
			$('.xdsoft_datetimepicker').css('display', 'none');
		}
		if ($('.datetimepicker').length > 0) {
			initDateTimePicker();
		}
	}catch(err){}
}

function showPopupUserInfo() {
    $('#popup-user-info').removeClass('hidden');

    var currentWindowWidth = $(window).width();
    var widthWelcomeTitle = document.getElementById('welcome-title').offsetWidth;
    var marginRightOfPopupUserInfo = currentWindowWidth * 2 / 100 + widthWelcomeTitle;
    $('#popup-user-info').css('right', marginRightOfPopupUserInfo + 'px');
    $('#popup-user-info::before').css('right', marginRightOfPopupUserInfo + 20 + 'px');
}

function hidePopupUserInfo() {
    $('#popup-user-info').addClass('hidden');
}

function clearTextbox(el) {
	$(el).val("");
}

function searchCompany(e, currentTaskTabId) {
	try {
		setTimeout(
			function () {
				textSmartSearchChange(e,
					"#divShowSmartSearchResult" + currentTaskTabId,
					"#txtSmartSearchCompany" + currentTaskTabId,
                    "#txtSmartSearchNumberLiTag" + currentTaskTabId, currentTaskTabId);
			}, 200);
	}
	catch (err) {
	}
}

function textSmartSearchChange(e, tagDivPopUp, tagCompanyName, tagCountLi, currentTaskTabId) {
    var ulTotal = $("#ulSmartSearchResult" + currentTaskTabId).children().length;
    var liTagSelected = null;
    var liIdTagSelected = $(tagCountLi).val().trim() / 1;
	if (liIdTagSelected !== -1 && e.keyCode !== 27) {
		if (e.keyCode === 40 || e.keyCode === 38) {
			if (e.keyCode === 40) {
				if (liIdTagSelected > ulTotal) {
					liIdTagSelected = 1;
				}
				liIdTagSelected = liIdTagSelected + 1;
			} else if (e.keyCode === 38) {
				if (liIdTagSelected === 0) {
					liIdTagSelected = ulTotal + 1;
				}
				liIdTagSelected = liIdTagSelected - 1;
			}
			
			liTagSelected = "#li_" + currentTaskTabId + "_"  + liIdTagSelected;
			$(tagCountLi).val(liIdTagSelected);
			$(liTagSelected).siblings().removeClass("active");
			$(liTagSelected).focus();
			$(liTagSelected).addClass("active");
		}

		if ((e.keyCode === 13 || e.keyCode === 40 || e.keyCode === 38) && $(tagDivPopUp).text() !== "") {
			var hideTagDivPopup = false;
            if (e.keyCode === 13) {
                hideTagDivPopup = true;   
            }
            selectItemInSmartSearchResult(currentTaskTabId, liIdTagSelected, hideTagDivPopup);
			return;
		} else {
			$(tagCountLi).val("1");
		}
	}
    else if(e.keyCode === 27){
        $(tagDivPopUp).attr("style", "visibility: hidden;");
        $(tagDivPopUp).html("");
    }
    var textSearch = $(tagCompanyName).val().trim();
    if (textSearch === "") {
        $(tagDivPopUp).attr("style", "visibility: hidden;");
        $(tagDivPopUp).html("");
        return;
    }
    
    $.ajax({
        type: "POST",
        url: "/smart-search/search-company",
        data: { keySearch: textSearch, taskTabId: currentTaskTabId }, 
        cache: false, dataType: "json", traditional: true,
        success: function (data) {
            if (data != null && data.success && data.div_show_results_search !== "") {
                $(tagDivPopUp).html(data.div_show_results_search);
                $(tagDivPopUp).attr("style", "visibility: visible;");
                $(tagCountLi).val("1");
                $(tagDivPopUp).find("li").first().addClass("active").siblings().removeClass();
                $(tagDivPopUp).find("li").first().focus();
            }
            else {
                $(tagDivPopUp).attr("style", "visibility: hidden;");
                $(tagDivPopUp).html("");
                $(tagCountLi).val("-1");
            }
        }
    });
}

function selectItemInSmartSearchResult(currentTaskTabId, liIdSelected, hideTagDivPopup) {
	var tagLiSelected = "#li_" + currentTaskTabId + "_"  + liIdSelected;
	var tagCompanyName = "#txtSmartSearchCompany" + currentTaskTabId;
	var tagDivPopUp = "#divShowSmartSearchResult" + currentTaskTabId;
	var textOfSpanInLiSelected = $(tagLiSelected + " > span").map(function() {
		return this.id;
	}).get();
	if (textOfSpanInLiSelected != null && textOfSpanInLiSelected !== "") {
		$(tagCompanyName).val($(tagLiSelected).text());
		$(tagCompanyName).attr("data-companyname", $(tagLiSelected).text());
		$(tagCompanyName).attr("data-companyid", $(tagLiSelected).find("span").attr("data-companyid"));
        $(tagLiSelected).focus();
    }
	if (hideTagDivPopup) {
        $(tagDivPopUp).attr("style", "visibility: hidden;");
    }
}

function setValueForControlDateTimePicker(el, value) {
    if (value === null || value === '' || value === window.maskDateTime_N0 ) {
        $(el).val(window.maskDateTime_N0);
    }
}
function CompareTime(time1, time2) {
    var regex = new RegExp(':', 'g');
    if (parseInt(time1.replace(regex, '')) <= parseInt(time2.replace(regex, ''))) {
        return true;
    } else {
        return false;
    }
}

function CompareDate(date1, date2) {
    var dateArr1 = date1.split('/');
    var month1 = parseInt(dateArr1[1]) - 1;
    var myDate1 = new Date(dateArr1[2], month1, dateArr1[0], 0, 0, 0, 0);
    var dateArr2 = date2.split('/');
    var month2 = parseInt(dateArr2[1]) - 1;
    var myDate2 = new Date(dateArr2[2], month2, dateArr2[0], 0, 0, 0, 0);
    if (myDate1 > myDate2) {
        return false;
    }
    return true;
}



