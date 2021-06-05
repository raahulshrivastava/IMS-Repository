
//var _urlPrefix = typeof urlPrefix != 'undefined' ? urlPrefix : "";
//$.ajaxSetup({ cache: false });



function GetSelectIds() {
    var value = "";
    $(".SelectItem:checked").each(function () {
        if ($(this).val() != "MASTER") {
            if (value == "")
                value = $(this).val();
            else
                value += "," + $(this).val();
        } 
    });
    return value;
}


function GetSelectValues(attrtype, sepratror) {
    var value = "";
    var tempval = "";
    var sepval = ",";
    if (sepratror !== undefined && sepratror != "") {
        sepval = sepratror;
    }
    $(".SelectItem:checked").each(function () {
        if ($(this).val() != "MASTER") {
            if (attrtype !== undefined) {
                tempval = $(this).attr(attrtype);
            }
            else {
                tempval = $(this).val();
            }
            if (value == "")
                value = tempval;
            else
                value += sepval + tempval;
        }
    });
    return value;
}


function GetSelectValuesformultipleKey() {
    var value = "";
    var tempval = "";
    var sepval = ",";
    var o = [];
    $(".SelectItem:checked").each(function () {
        if ($(this).val() != "MASTER") {
            tempval = $(this).data('val');
            if (typeof tempval != 'object') {
                try {
                    tempval = JSON.parse(tempval);
                }
                catch (e) {

                }
            }
            o.push(tempval);
        }
    });
    return o;
}


function checkDot(ctl, decimalDigits) {
    ctl.value = trim(ctl.value, ".");
    if (decimalDigits == null)
        decimalDigits = 2;
    if (ctl.value == "")
        return false;
    if (ctl.value == ".")
        ctl.value = "";
    else {
        try {
            ctl.value = parseFloat((ctl.value)).toFixed(decimalDigits);
        } catch (e) {
            ctl.value = "";
        }

    }
}

function checkNumber(ctrl, digitBeforePoint, digitAfterPoint, evt) {

    if (evt == null || evt == undefined)
        evt = window.event;

    var arrVal = ctrl.value.split(".")
    var keyCode;
    if (evt.which) {
        keyCode = evt.which;
    }
    else {
        keyCode = evt.keyCode;
    }
    //alert(keyCode);
    if (keyCode == 8 || keyCode == 9 || keyCode == 35 || keyCode == 36 || keyCode == 37 || keyCode == 38 || keyCode == 39 || keyCode == 40 || keyCode == 46) {
        return true;
    }
    if (digitAfterPoint == 0) {
        if (ctrl.value.length >= digitBeforePoint) {
            setKeyCode(0, evt);
            return false;
        }
    }
    else if (digitAfterPoint > 0) {
        if (arrVal.length == 1) {
            if (arrVal[0].length == digitBeforePoint && keyCode != 46) {
                setKeyCode(0, evt);
                return false;
            }
        }
        else if (arrVal.length == 2) {
            if (keyCode == 46) {
                setKeyCode(0, evt);
                return false;
            }
            if (arrVal[1].length >= digitAfterPoint) {
                setKeyCode(0, evt);
                return false;
            }
        }
    }
    var curLoc = (GetCursorLocation(ctrl))
    var ch = keyCode;

    if (ch == 46 && digitAfterPoint == 0) {
        setKeyCode(0, evt);
        //CallDiv(ctrl.id, "Dot(.) not allowed. Please enter numeric value only.");
        return false;
    }
    else if (ch == 46) {
        return true;
    }
    else if (ch == 45 && curLoc == 0 && ctrl.value.search("-") < 0) {
        return true;
    }
    else if (isNaN(String.fromCharCode(ch)) || ch == 32)//.toString()+String.fromCharCode(ch)
    {
        setKeyCode(0, evt);
        //CallDiv(ctrl.id, "Not a number. Please enter numeric value only.");
        return false;
    }
}
function setKeyCode(code, evt) {
    if (evt.which) {
        evt.which = "undefined";
    }
    else {
        evt.keyCode = code;
    }
}

function GetCursorLocation(CurrentTextBox) {
    var CurrentSelection, FullRange, SelectedRange, LocationIndex = -1;
    if (typeof CurrentTextBox.selectionStart == "number") {
        LocationIndex = CurrentTextBox.selectionStart;
    }
    else if (document.selection && CurrentTextBox.createTextRange) {
        CurrentSelection = document.selection;
        if (CurrentSelection) {
            SelectedRange = CurrentSelection.createRange();
            FullRange = CurrentTextBox.createTextRange();
            FullRange.setEndPoint("EndToStart", SelectedRange);
            LocationIndex = FullRange.text.length;
        }
    }
    return LocationIndex;
}

function trim(str, chars) {
    return ltrim(rtrim(str, chars), chars);
}

function ltrim(str, chars) {
    chars = chars || "\\s";
    return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
}

function rtrim(str, chars) {
    chars = chars || "\\s";
    return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
}
//jQuery.fn.formateMultiselect =
//function () {
//    return this.each(function () {
//        $(this).css("width", "100%").css("text-align", "left").parent(".btn-group").css("width", "100%");
//    });
//};

//jQuery.fn.ForceNumericOnly =
//function () {
//    return this.each(function () {
//        $(this).keydown(function (e) {
//            var key = e.charCode || e.keyCode || 0;
//            // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
//            // home, end, period, and numpad decimal
//            return (
//                key == 8 ||
//                key == 9 ||
//                key == 46 ||
//                key == 110 ||
//                key == 190 ||
//                (key >= 35 && key <= 40) ||
//                (key >= 48 && key <= 57) ||
//                (key >= 96 && key <= 105));
//        });
//    });
//};


//negative numbers are allowed
//jQuery.fn.ForceNumberOnly =
//function () {
//    return this.each(function () {
//        $(this).keydown(function (e) {
//            var key = e.charCode || e.keyCode || 0;
//            // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
//            // home, end, period, and numpad decimal
//            return (
//               key == 8 ||
//                  key == 109 ||
//                   key == 173 ||
//                   key == 189 ||
//                key == 9 ||
//                key == 46 ||
//                key == 110 ||
//                key == 190 ||
//                (key >= 35 && key <= 40) ||
//                (key >= 48 && key <= 57) ||
//                (key >= 96 && key <= 105));
//        });
//    });
//};

//jQuery.fn.ForceIntegerOnly =
//function () {
//    return this.each(function () {
//        $(this).keydown(function (e) {
//            var key = e.charCode || e.keyCode || 0;
//            // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
//            // home, end, period, and numpad decimal
//            return (
//                key == 8 ||
//                key == 9 ||
//                key == 46 ||
//                key == 190 ||
//                (key >= 35 && key <= 40) ||
//                (key >= 48 && key <= 57) ||
//                (key >= 96 && key <= 105));
//        });
//    });
//};


function ProcessResult(response) {
    var objResponse = response;
    if (objResponse && typeof objResponse != 'object') {
        objResponse = $.parseJSON(objResponse);
    }
    ShowMessage(objResponse.MessageType, objResponse.Message);
    if (objResponse.MessageType == "2") {
        bootbox.hideAll()
        $("#SearchForm").submit();
    }
}
//$(".datepicker").on("keydown", function (e) {
//    //alert(e.keyCode);


//    if (e.keyCode == 8 || e.keyCode == 46) {
//        //$(this).val("");
//    }
//    else if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57)) {
//        if ($(this).val().length >= 10 && !(e.keyCode == 9 || e.keyCode == undefined))
//            return false;
//        if ($(this).val().length == 2) {
//            $(this).val($(this).val() + "/");

//        }
//        else if ($(this).val().length == 5)
//        { $(this).val($(this).val() + "/"); }
//        else if ($(this).val().length == 10) {
//            // alert($(this).val().substring(0, 10));
//            $(this).val($(this).val().substring(0, 10));
//            return false;
//        }
//        else
//            return true;
//        //return false;
//    }
//    else if (e.keyCode == 9 || e.keyCode == undefined) {
//        $(this).focusout();
//    }
//    else
//        return false;
//});
//$(".datepicker").on("focusout", function () {

//    var arrDt = $(this).val().split('/');
//    //alert($(this).val() + "\n" +arrDt.length);
//    if (arrDt.length == 3) {
//        try {
//            if (arrDt[2].length < 4 || parseInt(arrDt[1]) > 12) {
//                $(this).val("");
//            }
//            else {
//                //code by pawan 
//                var date = new Date(parseInt(arrDt[2]), parseInt(arrDt[1]) - 1, parseInt(arrDt[0]));
//                if (date.getFullYear() == parseInt(arrDt[2]) && date.getMonth() + 1 == parseInt(arrDt[1]) && date.getDate() == parseInt(arrDt[0])) {
//                    var dt = new Date(parseInt(arrDt[2]), (parseInt(arrDt[1]) - 1), parseInt(arrDt[0]));
//                    //var dt = new Date(arrDt[0] + "-" + getMonthName(parseInt(arrDt[1]) - 1) + "-" + arrDt[2]);
//                    //alert(dt);
//                    $(this).val(arrDt[0] + "-" + getMonthName(parseInt(arrDt[1]) - 1) + "-" + arrDt[2]);

//                } else {
//                    $(this).val("");
//                }

//            }
//        }
//        catch (e) {
//            $(this).val("");
//        }

//    }
//    //else
//    //   
//});
//$(".datepicker").on("keypress", function (e) {
//    if ($(this).val().length == 11) {
//        $(this).attr("maxlength", 11);
//        $(this).attr("title", "Enter date in DD/MM/YYYY format");
//        $(this).attr("placeholder", "DD/MM/YYYY");
//        var arrDt = $(this).val().split('-');
//        if (arrDt.length == 3) {
//            $(this).val(arrDt[0] + "/" + ("00" + (getMonthNumber(arrDt[1]) + 1)).slice(-2) + "/" + arrDt[2]);
//        }
//        else {
//            //$(this).keydown();
//            //$(this).val("");
//        }
//    }
//});



//$(".datepicker").live("keydown", function (e) {
//    if (e.keyCode == 8 || e.keyCode == 46)
//        $(this).val("");
//    else
//        return false;
//});

//$(".datepicker1").on("keydown", function (e) {


//    if (e.keyCode == 8 || e.keyCode == 46)
//        $(this).val("");
//    else
//        return false;
//});

function ReplaceIfBlank(input, defaultText) {
    if (input == "")
        return defaultText;
    else
        return input;
}

function ReplaceIfBlankOrZero(input, defaultText) {
    if (input == "" || input == 0)
        return defaultText;
    else
        return input;
}
function formatFloatData(input) {
    if (input == "" || input == 0)
        return "";
    else
        return input.replace(".00", "");;
}


//$('.num').on('keydown', function (e) {
//    if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode == 8) || (e.keyCode == 9) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 46)) {
//        return true;
//    }
//    return false;
//});

//$('.decimal').on('keydown', function (e) {
//    if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode == 8) || (e.keyCode == 9) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 46) || (e.keyCode == 190) || (e.keyCode == 110)) {
//        if (e.keyCode == 110 || e.keyCode == 190) {
//            if ($(this).val().indexOf('.') >= 0) {
//                return false;
//            }
//        }
//        return true;
//    }
//    return false;
//});

function RefreshSerialNo(CssClass) {
    var i = 1;
    $("." + CssClass).each(function () {
        $(this).html(i);
        i++;
    });
}

function PrintWindow() {
    window.print();
}

// callbackFn : parameter used for callback function need only function name no need to use parenthisis or it's params; usage : callbackFn = "callbackFunction" or "function(){}"
function AttatchMiniFileUploader(Url, divId, BaseUrl, callbackFn) {
    //alert("created");
    var EntityId = '0';
    var apiUrl = Url;


    //  $('#minfileupload') remove this html dom and create again and attach fileupload event 
    //for dispose all attached events to this element for multiple call.
    $('#minfileupload').remove();
    $('<input style="display:none" type="file" id="minfileupload" name="minfileupload">').appendTo($("body"));

    $('#minfileupload').fileupload({
        dataType: "json",
        url: apiUrl,
        limitConcurrentUploads: 1,
        sequentialUploads: true,
        progressInterval: 100,
        add: function (e, data) {
            //data.context = $('<div />').text(data.files[0].name).appendTo('#filelistholder');
            //$('</div><div class="progress"><div class="bar" style="width:0%"></div></div>').appendTo(data.context);
            //data.submit();
            data.context = $('<div />').text(data.files[0].name).appendTo('#filelistholder');
            $('</div><div class="progress"><div class="bar" style="width:0%"></div></div>').appendTo(data.context);

            //Use below lines if you want to restrict selectd file types to be uploaded.
            var fileType = data.files[0].name.split('.').pop().toLowerCase(), allowdtypes = 'jpeg,jpg,png,gif,pdf,doc,docx,xls,xlsx';
            if (allowdtypes.indexOf(fileType) < 0) {
                alert('Invalid file type, aborted. Please upload only jpeg,jpg,png,gif,doc,xls and pdf file types.');
                return false;
            }
            data.submit();
        },
        done: function (e, data) {
            var orgFileName = JSON.parse(data.jqXHR.responseText).orgFileName;
            var fileName = JSON.parse(data.jqXHR.responseText).fileName;
            var Msgtype = JSON.parse(data.jqXHR.responseText).MessageType;
            var MsgDesc = JSON.parse(data.jqXHR.responseText).Message;
            ShowMessage(Msgtype, MsgDesc);
            $("#" + divId).load(BaseUrl, function () {

                //-------------Call Callback function if any-----------------//
                if (typeof callbackFn != 'undefined') {
                    if (toString.call(callbackFn) == "[object Function]") {
                        callbackFn.call();
                    }
                    else if (callbackFn != "") {
                        if (toString.call(callbackFn) == "[object String]") {
                            var mydel = eval(callbackFn);
                            if (toString.call(mydel) == "[object Function]") {
                                mydel.call();
                            }
                        }
                    }
                }

                //--------end of code----------------//
            });



        },
        progressall: function (e, data) {


        },
        progress: function (e, data) {


        }
    });
}

function getMonthNumber(monthName) {
    if (monthName.toLowerCase() == "jan")
        return 0;
    else if (monthName.toLowerCase() == "feb")
        return 1;
    else if (monthName.toLowerCase() == "mar")
        return 2;
    else if (monthName.toLowerCase() == "apr")
        return 3;
    else if (monthName.toLowerCase() == "may")
        return 4;
    else if (monthName.toLowerCase() == "jun")
        return 5;
    else if (monthName.toLowerCase() == "jul")
        return 6;
    else if (monthName.toLowerCase() == "aug")
        return 7;
    else if (monthName.toLowerCase() == "sep")
        return 8;
    else if (monthName.toLowerCase() == "oct")
        return 9;
    else if (monthName.toLowerCase() == "nov")
        return 10;
    else if (monthName.toLowerCase() == "dec")
        return 11;
}
function getMonthName(_monthNumber) {
    var monthNumber = parseInt(_monthNumber);
    if (monthNumber == 12)
        monthNumber = 1;
    if (monthNumber == 0)
        return "Jan";
    else if (monthNumber == 1)
        return "Feb";
    else if (monthNumber == 2)
        return "Mar";
    else if (monthNumber == 3)
        return "Apr";
    else if (monthNumber == 4)
        return "May";
    else if (monthNumber == 5)
        return "Jun";
    else if (monthNumber == 6)
        return "Jul";
    else if (monthNumber == 7)
        return "Aug";
    else if (monthNumber == 8)
        return "Sep";
    else if (monthNumber == 9)
        return "Oct";
    else if (monthNumber == 10)
        return "Nov";
    else if (monthNumber == 11)
        return "Dec";
}
function getDate(dateString) {
    var dt = dateString.split('-');
    return new Date(parseInt(dt[2]), getMonthNumber(dt[1]), parseInt(dt[0]));
}
function MultiSelectChanged(victim) {
    var controlId = $(victim).attr("id");
    var targetID = controlId.replace("MS", "");
    var checkedValues = $(victim).val();
    $("#" + targetID).val(checkedValues);
}

function roundNumber(number, decimals) { // Arguments: number to round, number of decimal places
    var newnumber = new Number(number + '').toFixed(parseInt(decimals));
    return parseFloat(newnumber); // Output the result to the form field (change for your purposes)
}



function DDLpageSizeChanged() {
    $("#PageSize").val($("#DDLpageSize").val());
    FormSubmit($("#SearchForm"));
    //$("#SearchForm").submit();
}



function initdatepickerval() {
    $(".hasDatepicker, .datelabel").each(function () {
        try {
            // Place dateformat.js above this script when it refrenced
            var afterformat_val = $(this).val() != "" ? new Date($(this).val()).format("dd-mmm-yyyy") : "";
            $(this).val(afterformat_val);
            $(this).attr("placeholder", "DD/MM/YYYY");
        }
        catch (e) { }
    });
}

//$(document).ready(function () {
//    initdatepickerval();
//});

// end region

function fnAutoPrintv2(victim) {



    //Get the HTML of div
    var divElements = $('<div />').html($('#classListing table').clone()).html();



    //Get the HTML of whole page
    var oldPage = document.body.innerHTML;

    //Reset the page's HTML with div's HTML only
    document.body.innerHTML =
      "<html><head><title></title></head><body><div style='width:100%;padding:5px;align:center'> <h3>&nbsp;&nbsp;" + $(document).find("title").text() + "</h3></div>" +
      divElements + "</body>";

    //Print Page
    window.print();

    //Restore orignal HTML
    document.body.innerHTML = oldPage;





}

function fnAutoPrint(victim) {

    victim = victim && victim != '' ? victim : 'classListing';
    //Get the HTML of div
    var divElements = $('<div />').html($('#' + victim).children().find("table").first().clone()).html();
    var Style = '<style type="text/css">   .doNotPrint{display:none;}        .table {            border :2px;        }        .table th {            background-color :#87AFC6;        }        </style>';


    var mywindow = window.open('', 'new div', 'height=1000,width=768');

    //<link rel='stylesheet' href='/assets/css/admin/module.admin.stylesheet-complete.min.css' />
    mywindow.document.write("<html><head><title></title></head><body>" + Style + "<div style='width:100%;padding:5px;text-align:center'> <h3>&nbsp;&nbsp;" + $(document).find("title").text() + "</h3></div>" +
   divElements + "</body>");
    mywindow.print();
    mywindow.close();


}

function fnExcelReportAuto(victim) {

    var tab;
    var excludeclass = 'doNotPrint';
    $(".table:not('." + excludeclass + "')").each(function () {
        tab = this;
    })

    var tab_text = "<table><tr><td colspan='5' style='text-align:center'>" + $(document).find("title").text() + "</td></tr></table><table border='2px'><tr bgcolor='#87AFC6'>";

    var textRange; var j = 0;




    for (j = 0 ; j < tab.rows.length ; j++) {
        for (ce = 0; ce < tab.rows[j].cells.length; ce++) {
            try {
                var thiscell = $(tab.rows[j].cells[ce]);
                if ($(thiscell).not('.' + excludeclass + '').length > 0) {
                    tab_text = tab_text + $(thiscell).outerHTML();
                }
            }
            catch (e) {

            }
        }
        tab_text = tab_text + "</tr>";
    }



    tab_text = tab_text + "</table>";

    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table

    tab_text = tab_text.replace(/<a[^>]*>|<\/a>/g, "");//remove if u want links in your table

    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table

    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params



    var ua = window.navigator.userAgent;

    var msie = ua.indexOf("MSIE ");



    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer

    {

        txtArea1.document.open("txt/html", "replace");

        txtArea1.document.write(tab_text);

        txtArea1.document.close();

        txtArea1.focus();

        sa = txtArea1.document.execCommand("SaveAs", true, "report.xls");

    }

    else                 //other browser not tested on IE 11

        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text), 'report');



    return (sa);

}

function fnExcelReport(tableID) {

    var tab;

    $(".export_table").each(function () {
        tab = this;
    })
    var tab_text = "<table><tr><td colspan='5' style='text-align:center'>" + $(document).find("title").text() + "</td></tr></table><table border='2px'><tr bgcolor='#87AFC6'>";


    var textRange; var j = 0;

    if (tableID != undefined && tableID != "") {
        tab = document.getElementById(tableID); // id of table
    }



    for (j = 0 ; j < tab.rows.length ; j++) {

        tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";

        //tab_text=tab_text+"</tr>";

    }



    tab_text = tab_text + "</table>";

    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table

    tab_text = tab_text.replace(/<a[^>]*>|<\/a>/g, "");//remove if u want links in your table

    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table

    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params



    var ua = window.navigator.userAgent;

    var msie = ua.indexOf("MSIE ");



    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer

    {

        txtArea1.document.open("txt/html", "replace");

        txtArea1.document.write(tab_text);

        txtArea1.document.close();

        txtArea1.focus();

        sa = txtArea1.document.execCommand("SaveAs", true, "report.xls");

    }

    else                 //other browser not tested on IE 11

        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text), 'report');



    return (sa);

}


function PrintLetter(div) {

    var prtContent = $(".Letter");//document.getElementById(temp);
    var WinPrint = window.open('', '', 'letf=400px,top=100px,width=800px,height=500px,toolbar=0,scrollbars=1,status=0,');
    WinPrint.document.write($(prtContent).html());
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}


var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
    var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office"          xmlns:x="urn:schemas-microsoft-com:office:excel"         xmlns="http://www.w3.org/TR/REC-html40"><head>        <!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets>        <x:ExcelWorksheet><x:Name>{worksheet}</x:Name>        <x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions>        </x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook>        </xml><![endif]--></head><body>        <table>{table}</table></body></html>'
    var base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
    var format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table);
        var cntrlhtml = $(table).clone();
        $(cntrlhtml).find(".doNotPrint").remove();
        $(cntrlhtml).find("thead tr th").each(function () { $(this).css('background-color', "#87AFC6"); });
        var collen = $(cntrlhtml).find("thead tr th").length;
        var forwraped_print = "<table> <thead><tr><th colspan='" + collen + "'>" + name + "</th></tr></thead><tbody><tr><td>" + $(cntrlhtml).html() + "</td></tr></tbody></table>";

        cntrlhtml = $(forwraped_print).html();
        var ctx = { worksheet: name || 'Worksheet', table: cntrlhtml }
        window.location.href = uri + base64(format(template, ctx))
    }
})();
function fnExcelReportHRMS(tableID) {
    var thistableid = tableID && tableID != '' ? tableID : 'export_table';
    var title = $("#title").text();
    title = title != "" ? title : $(document).find("title").text();
    tableToExcel(thistableid, title);
}

function fnExcelReport_HRMS(tableID, title) {
    var tab;
    title = title || '';

    tableToExcel(tableID, title);
}

// For Disable mode a container and its child control
function InitDisableMode() {
    $(".disable").each(function () {
        try {
            $(this).attr("disabled", "disabled");
            $(this).find(":input, :button, a").each(function () {
                $(this).attr("disabled", "disabled");
            });
        }
        catch (e) { throw e; }
    });
}
// For Readonly mode a container and its child control
function InitNonReadMode() {
    $(".nonread").each(function () {
        try {
            $(this).attr("readonly", true);
            $(this).find(":input, :button, a").each(function () {
                $(this).attr("readonly", true);
            });
        }
        catch (e) { throw e; }
    });
}

// prevent action from DOM can be extend this function
function disableA(e) {
    e.preventDefault();
}

// remove attr from DOM
function RemoveAttrFromVictim(type, victim) {
    try {
        if (type !== undefined && victim !== undefined) {
            $(victim).prop(type, false);
            $(victim).find(":input, :button, a").each(function () {
                $(this).prop(type, false);
                //if ($(this) && $(this).length > 0) {
                //    if ($(this)[0].localName == "a") {
                //        var tempattr = $(this).attr("onclick");
                //        var tempattrstr = "//" + tempattr;
                //        $(this).attr("onclick", tempattr);
                //        $(this).unbind("click");
                //    }
                //}
            });
        }
    }
    catch (e)
    { }
}

// for check leap year
var isLeapYear = function (year) {
    year = parseInt(year);
    if (year % 4 == 0) {
        if (year % 100 != 0) {
            return true;
        }
        else {
            if (year % 400 == 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    return false;
};

// init custom create Jquery function by call this function
var InitJqueryFunction = function () {
    //----------Get Serialize Array for any container control which is further wrap by a form id : __serialform_temp as Model Property 
    $.fn.getSerializeObject = function () {
        var thisid = this;
        var formid = "__serialform_temp";
        $("#" + formid).remove();
        var formbody = $(this).clone(true, true);
        $("body").append($("<form id=" + formid + ">" + $(formbody).html() + "</form>"));
        var getmodel = $("#" + formid).serializeObject();
        return getmodel;
    };

    //----------Get Serialize Array for any container control as Model Property 
    $.fn.getSerializeObjectCntl = function () {
        var thisid = this;
        var getmodel = $(this).find(":input").serializeObject();
        return getmodel;
    };

    //----------Get Serialize Array Object as Model Property 
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    //----------Get Serialize Array Input Names for any container control as Model Property Name
    $.fn.getSerializeInputNameCntl = function () {
        var thisid = this;
        var getmodel = $(this).find(":input").serializeInputName();
        return getmodel;
    };
    //----------Get Serialize Array Object for Input Names as Model Property Name
    $.fn.serializeInputName = function () {
        var o = {};
        var a = this.serializeArray();
        o.AllNames = [];
        $.each(a, function () {
            o.AllNames.push(this.name);
        });
        return o;
    };

    // use this track existig entity list type input control names serialize, add attribute for input in collection for param : defTrackName, if it is not than it use default dataname
    $.fn.getCollectionDataName = function (defTrackName) {
        if (typeof defTrackName == 'undefined' || defTrackName.trim() == "") {
            defTrackName = "name";
        }
        var o = {};
        o.AllNames = [];
        $(this).find(":input").each(function () {
            var thisname = $(this).attr(defTrackName);
            if (thisname != null && thisname != "") {
                var strIndx = thisname.lastIndexOf('.');
                var thisname = thisname.substr(strIndx + 1);
            }
            o.AllNames.push(thisname);
        });
        return o;
    }

    // use this track existig entity list type input control names serialize, add attribute for input in collection for param : defTrackName, if it is not than it use default dataname
    $.fn.getSerializeObjectCntlCustomNaming = function (defName) {
        if (typeof defName == 'undefined' || defName.trim() == "") {
            defName = "name";
        }
        var o = {};
        var a = [];
        $(this).find(":input").each(function () {
            var thisname = $(this).attr(defName);
            if (!thisname) {
                return;
            }
            var tempobj = {};
            tempobj.name = thisname;
            tempobj.value = $(this).val();
            a.push(tempobj);
        });
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    }

    // get controls outer html
    $.fn.outerHTML = function () {

        // IE, Chrome & Safari will comply with the non-standard outerHTML, all others (FF) will have a fall-back for cloning
        return (!this.length) ? this : (this[0].outerHTML || (
          function (el) {
              var div = document.createElement('div');
              div.appendChild(el.cloneNode(true));
              var contents = div.innerHTML;
              div = null;
              return contents;
          })(this[0]));

    }

    // prevent double click except the class exceptDblClick
    $("button, [type=submit], a").not('.exceptDblClick').dblclick(function (e) {
        e.preventDefault();
        e.stopPropagation();
        if (isConsoleExists()) {
            console.log('Prevent double click');
        }
        return false;
    });
}
//$(function () {
//    $('form').submit(function () {
//        $("input[type='submit'], input[type='button']", this)
//          .val("Please Wait...")
//          .attr('disabled', 'disabled');
//        return true;
//    });
//});
function isRegExp(value) {
    return toString.call(value) === '[object RegExp]';
}
// Replace UnderScore from naming convserion of model strongly propety for post appropriate model i.e. Employee_0_FirstName  => Employee[0].FirstName
// also used for ltrim, rtrim with character ReplaceUnderScore(",,A,B,C,,",' ',/^,+|,+$/g,' ',' ').trim();
var ReplaceUnderScore = function (str, replacer, regex, findex, eindex) {
    try {
        var regx = new RegExp("_(.+?)_", "g");///_(.+?)_/g;
        if (regex && isRegExp(regex)) {
            regx = regex;
        }
        var fisrtindex = "[";
        if (findex) {
            fisrtindex = findex;
        }
        var endindex = "].";
        if (eindex) {
            endindex = eindex;
        }
        var rep = "";
        if (!str) {
            return "";
        }
        return str.replace(regx, function ($0, $1) {
            if (replacer) {
                rep = replacer;
            }
            else {
                rep = $1;
            }
            return fisrtindex + rep + endindex;
        });
    }
    catch (e)
    { }
};

// Arrange Serial Number of dynamic add tr in tables for send proper way list bind in list type for ajax send on server auto binding to a complex model type.
// victim -> tableid.
function ReOrgTableListIds(victim, defName) {
    if (typeof defName == 'undefined' || defName.trim() == "") {
        defName = "name";
    }
    var index = 0;
    var i = 0;
    var respush = [];
    var texttores = "";
    var regx = /(\d+)/g;
    $(victim).find('tbody tr').each(function () {
        $(this).find('td :input').each(function () {
            var striner = $(this).attr(defName);
            if (striner) {
                texttores = striner.replace(regx, function ($0, $1) {
                    if (!this) {
                        return "";
                    }
                    return i;
                });
                $(this).attr(defName, texttores);
                $(this).attr("id", texttores);
                respush.push(texttores);
            }
        });
        i++;
    });
    return respush;
}

// Arrange Serial Number of dynamic add collection in a dom collection for send proper way list bind in list type for ajax send on server auto binding to a complex model type.
// victim -> parent collection id.
function ReOrgCollectionListIds(victim, innercollection, defName) {
    if (typeof defName == 'undefined' || defName.trim() == "") {
        defName = "name";
    }
    var index = 0;
    var i = 0;
    var respush = [];
    var texttores = "";
    var regx = /(\d+)/g;
    if (innercollection == null || innercollection == undefined || innercollection == "") {
        return null;
    }
    $(victim).find(innercollection).each(function () {
        $(this).find(':input').each(function () {
            var striner = $(this).attr(defName);
            if (striner) {
                texttores = striner.replace(regx, function ($0, $1) {
                    if (!this) {
                        return "";
                    }
                    return i;
                });
                $(this).attr(defName, texttores);
                $(this).attr("id", texttores);
                respush.push(texttores);
            }
        });
        i++;
    });
    return respush;
}

// Arrange Serial Number of Array/List type collection i.e ['MAIL_0_trim','MAIL_1_trim','MAIL_2_trim','MAIL_5_trim','MAIL_8_trim'] => ['MAIL_0_trim','MAIL_1_trim','MAIL_2_trim','MAIL_3_trim','MAIL_4_trim']
var ReorgSerial = function (arrund) {
    try {
        var i = 0;
        var texttores = "";
        var respush = [];
        var regx = /(\d+)/g;
        if (!$.isArray(arrund)) {
            return null;
        }
        $.each(arrund, function (a, b) {
            //alert(b);
            var striner = b;
            if (b) {
                texttores = striner.replace(regx, function ($0, $1) {
                    if (!this) {
                        return "";
                    }
                    return i;
                });
                respush.push(texttores);
                i++;
            }
        });
        return respush;
    }
    catch (e)
    { }
};

//Override Select all script for table's checkbox except disable mode checkbox
function ForSelectDisableCheckbox() {
    $(".fordisable").on("change", function () {
        try {
            var isdiable = $(this).is(":disabled");
            if (isdiable) {
                $(this).prop("checked", false).parent().removeClass('checked');
                $(this).closest('tr').removeClass('selected');
            }
        }
        catch (e) {
            //alert(e);
        }
    });
}

// Get Multiple Ids element as JSON Object via pass getinobject as "Y" or JSON String via not pass any value for getinobject argument
var getMultipleIdsElement = function (getinobject) {
    try {
        var o = {};
        var reto = {};
        var whichid = {};
        reto["Result"] = [];
        $("[id]").each(function () {
            try {
                var curid = $(this).attr("id");
                if (whichid[curid] !== undefined) {
                }
                else {
                    var len = $("[id=" + curid + "]").length;
                    if (len > 1) {
                        whichid[curid] = len;
                        o["id"] = curid;
                        o["appearance"] = len;
                        reto["Result"].push(o);
                        o = {};
                    }
                }
            }
            catch (e) {

            }
        });
        if (getinobject !== undefined && getinobject.toUpperCase() == "Y") {
            return reto.Result;
        }
        else {
            return JSON.stringify(reto.Result);
        }
    }
    catch (e) {

    }
};

// function is used to reformat date field in json object.
// Pass json object and date field name which is to be change in date field and return json object.
function JsonReformatDateFiled(json, field) {
    var key;
    for (key in json[field]) {
        if (json[field].hasOwnProperty(key)) {
            json[field] = new Date(parseInt(json[field].substr(6)));
        }
    }
    return json;
}

// for remove escapting character
function removeEscapingCharacter(myid) {
    myid = typeof myid != 'undefined' ? (myid || "") : "";
    return myid.replace(/(:|\.|\[|\]|,)/g, "\\$1");
}

//Process result after return back ajax call
function AjaxResultProcess(response, callbackfunction, evaluatecustom, oncomplete, forpageMisc) {
    try {
        eval(evaluatecustom);
        var objResponse = response;
        if (typeof response == 'string') {
            objResponse = $.parseJSON(response);
        }
        if (objResponse == null || typeof objResponse != 'object') {
            throw Exception('Object not found');
        }
        ShowMessage(objResponse.MessageType, objResponse.Message);
        if (objResponse.MessageType == "2") {
            if (typeof (callbackfunction) != 'undefined') {
                if ($.isFunction(callbackfunction)) {
                    callbackfunction.call();
                }
            }
        }
        else {
            if (objResponse.CustomObject != 'undefined') {
                if (objResponse.CustomObject && typeof objResponse.CustomObject == 'object' && forpageMisc) {
                    var datacustommsg = objResponse.CustomObject;
                    if (datacustommsg.hasOwnProperty('ControlId')) {
                        datacustommsg.ControlId = removeEscapingCharacter(datacustommsg.ControlId);
                        if ($("[name='" + datacustommsg.ControlId + "']").length > 0) {
                            $("[name='" + datacustommsg.ControlId + "']").val('');
                            $("[name='" + datacustommsg.ControlId + "']").focus();
                        }
                        else {
                            $("[id='" + datacustommsg.ControlId + "']").val('');
                            $("[id='" + datacustommsg.ControlId + "']").focus();
                        }
                    }
                }
            }
        }
    }
    catch (e) {
        if (isConsoleExists()) {
            console.log("Error Occur => " + e.message);
        }
    }
    finally {
        if (oncomplete && typeof (oncomplete) != 'undefined') {
            if ($.isFunction(oncomplete)) {
                oncomplete.call();
            }
        }
    }
    return response;
}

//For Class num and decimal control style when input its direction from right to left, if blank than no alignment is set means default.
function ForNumDecimalStyle() {
    $(".num,.decimal").each(function () {
        var thisval = $(this).val();
        if (thisval == "") {
            $(this).css("text-align", "");
        }
        else {
            $(this).css("text-align", "right");
        }
    });
    $(".num,.decimal").on("click, keyup", function () {
        var plholder = $(this).attr("placeholder");
        var thisval = $(this).val();
        if (thisval == "") {
            $(this).css("text-align", "");
        }
        else {
            $(this).css("text-align", "right");
        }
    });

    $('.num').on('keydown', function (e) {
        if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode == 8) || (e.keyCode == 9) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 46)) {
            return true;
        }
        return false;
    });

    $('.decimal').on('keydown', function (e) {
        if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode == 8) || (e.keyCode == 9) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 46) || (e.keyCode == 190) || (e.keyCode == 110)) {
            if (e.keyCode == 110 || e.keyCode == 190) {
                if ($(this).val().indexOf('.') >= 0) {
                    return false;
                }
            }
            return true;
        }
        return false;
    });
}

// When Esc Key Press if bootbox model dialog hide.
var ModelCloseOnEsc = function () {
    $(window).on("keyup", function (e) {
        var pressKey = e.which ? e.which : e.keyCode;
        if (pressKey == 27) {
            bootbox.hideAll();
        }
    });
}

// For Draggable Popup
function ModelDialogProp() {
    try {
        $(".movable").draggable();
        $(".movable-header").css("cursor", "move");

        $('.modal-dialog').draggable({
            handle: ".modal-header"
        });
        $(".modal-header").css("cursor", "move");
    }
    catch (e) {

    }
}

// Create a function which is override load event of jquery.
var JSLoadOverride = function () {
    if ($ && $.fn) {
        var _oldLoad = $.fn.load;

        $.fn.load = function (url, data, oldCallback) {
            return $(this).each(function () {
                var obj = $(this),
                    newCallback = function () {
                        if ($.isFunction(oldCallback)) {
                            oldCallback.apply(obj);
                        }
                        //obj.trigger('afterLoad');
                        //if ($.isFunction(initUtility)) {
                        //    initUtility();
                        //}
                        $("#LoadingImage").hide();
                    };

                // you can trigger a before show if you want
                //obj.trigger('beforeLoad');
                $("#LoadingImage").show();
                // now use the old function to show the element passing the new callback
                _oldLoad.apply(obj, [url, data, newCallback]);
            });
        }

    }
};

// Create a function which is override ready event of jquery.
// _oldready for internal variable for store jquery default ready event.
// when _oldready.apply on object we send a newcallback event for call our custom event.
var JSReadyOverride = function () {
    if ($ && $.fn) {
        var _oldready = $.fn.ready;
        $.fn.ready = function (oldCallback) {
            return $(this).each(function () {
                var obj = $(this),
                    newCallback = function () {
                        if ($.isFunction(oldCallback)) {
                            oldCallback.apply(obj);
                        }
                        //obj.trigger('afterReady');
                        //if ($.isFunction(initUtility)) {
                        //    initUtility();
                        //}
                    };

                // you can trigger a before show if you want
                //obj.trigger('beforeReady');

                // now use the old function to show the element passing the new callback
                _oldready.apply(obj, [newCallback]);
            });
        }
    }
};


//Added By Anshul Garg
//region code by Anshul Garg
// This code is use for Formula making in :-
// LDM/CostofLandRule/AddEditCostofLandRule ,, LDM/Permission/AddEditPermissionApplRule ,, LDM/ServiceChargeRule/AddEditServiceChargeRule

function ClearFormula() {
    $("#Rate").val('');
    $("#hdnArrayType").val('');
    $("#hdnRateType").val('');
    $("#Amount").val('');
}
function UndoFormula() {
    var temp = String();
    var temp = $("#hdnArrayType").val();
    //alert(temp);
    if (temp.lastIndexOf('~', temp.length) > 0) {
        temp = temp.substring(0, temp.lastIndexOf('~', temp.length));
        //alert(temp);
    }
    else {
        temp = ""
    }
    $("#hdnArrayType").val(temp);
    var type = $("#hdnArrayType").val();
    //alert(type);
    var str = "";
    type = type.split('~');
    for (var i = 0; i < type.length; i++) {
        if (type[i] != "") {
            str += type[i] + " ";
        }
    }
    str = str.trim();
    $("#hdnRateType").val(str);
    $("#Rate").val(str);
    //alert($("#Rate").val());
}

function ChangeKeyword() {
    var temp = $("#hdnArrayType").val() + "~" + $("#Keyword :selected").text();
    $("#hdnArrayType").val(temp);
    $("#hdnRateType").val($("#hdnRateType").val() + " " + $("#Keyword :selected").text());
    $("#Rate").val($("#hdnRateType").val());
    $("#Keyword").val('');

}

function ChangeAmount() {
    var amt = $("#Amount").val();
    //alert(amt);
    var temp = $("#hdnArrayType").val() + "~" + amt;
    $("#hdnArrayType").val(temp);
    $("#hdnRateType").val($("#hdnRateType").val() + " " + amt);
    $("#Rate").val($("#hdnRateType").val());
    $("#Amount").val('');
}

//$(".btnOperator").click(function () {
//    var temp = $("#hdnArrayType").val() + "~" + $(this).val();
//    $("#hdnArrayType").val(temp);
//    $("#hdnRateType").val($("#hdnRateType").val() + " " + $(this).val());
//    $("#Rate").val($("#hdnRateType").val());
//});
// end region code by Anshul Garg

function isInterger(value) {

    var a = parseInt(value);
    if (isNaN(a)) {
        return false;
    } else {
        return true;
    }

}

function parseIntV2(value, defaultValue) {
    if (isInterger(value))
        return parseInt(value);
    else
        return (defaultValue || 0);

}



function isFloat(value) {

    var a = parseFloat(value);
    if (isNaN(a)) {
        return false;
    } else {
        return true;
    }

}
function parseFloatV2(value, defaultValue) {
    value = value.trim();
    value = value.replace(",", "");

    if (isFloat(value))
        return parseFloat(value);
    else
        return (defaultValue || 0);

}



// ------- form submit using submit button create due to when js library intialize by some other source like popup inner js library than $("form").submit() not work as unobstructive so use this funtion for same use.
var FormSubmit = function (FormId) {
    var searchform = $(FormId);
    $(searchform).find("#__btnsubmit__[type='submit']").remove();
    $("<input type='submit' name='__btnsubmit__' id='__btnsubmit__' value='ResetSearch' style='display:none;'/>").appendTo(searchform);
    $(searchform).find("#__btnsubmit__[type='submit']").trigger('click');
}

// Compare Two object propties
var ObjCompare = function (O1, O2) {
    var issame = true;
    for (t in O1) {
        if (O1[t] != O2[t]) {
            issame = false;
            break;
        }
    }
    return issame;
}

// for window load and unload functionality variable
var formSubmitting = false;
var saveformSerialize = {};
var saveformSerialize_cur = {};
var allforms = $("form");
var alreadPrompted = false,
    timeoutID = 0,
    reset = function () {
        alreadPrompted = false;
        timeoutID = 0;
    };

// set formsubmttting flag befor submit
function setFormSubmitting() {
    //formSubmitting = true;
    if ($.isFunction($("form").valid)) {
        if ($("form").valid()) {
            formSubmitting = true;
        }
    }
    else {
        formSubmitting = true;
    }
    return formSubmitting;
};

// check if any form data is modified or not
function isDirty() {
    var isDrty = false;
    allforms = $("form");
    var i = 0;
    saveformSerialize_cur.FormSerialize = [];
    for (var i = 0; i < allforms.length; i++) {
        saveformSerialize_cur.FormSerialize.push($(allforms[i]).serialize());
    }

    if (saveformSerialize && typeof saveformSerialize == 'object' && saveformSerialize.hasOwnProperty('FormSerialize')) {
        if (saveformSerialize.FormSerialize != undefined) {
            for (var echfrm = 0 ; echfrm < saveformSerialize.FormSerialize.length; echfrm++) {
                if (saveformSerialize.FormSerialize[echfrm] != saveformSerialize_cur.FormSerialize[echfrm]) {
                    isDrty = true;
                    break;
                }
            }
        }
    }

    return isDrty;
}

// for save on load form data at initialize level
function onloadSaveformdata() {
    formSubmitting = false;
    saveformSerialize = {};
    saveformSerialize_cur = {};
    allforms = $("form");
    saveformSerialize.FormSerialize = [];
    for (var i = 0; i < allforms.length; i++) {
        saveformSerialize.FormSerialize.push($(allforms[i]).serialize());

        $(allforms[i]).submit(function () {
            setFormSubmitting();
        });
    }
}

// Miscellaneous function
function MiscFunction() {
    //window.onload = function () {
    //    onloadSaveformdata();
    //    window.addEventListener("beforeunload", attachOnunload);
    //};
    //$(function () {
    //    setTimeout(function () {
    //        onloadSaveformdata();
    //window.removeEventListener("beforeunload", attachOnunload, true);
    //window.addEventListener("beforeunload", attachOnunload, true);
    //    }, 500);
    //});

    return;
    $(function () {
        //setTimeout(function () {
        // for prevent beforeunload attach event
        if ($("body").find(".exceptBeforeunload").length == 0) {
            onloadSaveformdata();
            window.removeEventListener("beforeunload", attachOnunload, true);
            window.addEventListener("beforeunload", attachOnunload, true);
        }
        //}, 100);

        window.onunload = function () {
            clearTimeout(timeoutID);
        };
    });
}

// attach event before window before unload
function attachOnunload(e) {
    if (alreadPrompted) {
        return;
    }
    var confirmationMessage = 'It looks like you have been editing something. ';
    confirmationMessage += 'If you leave before saving, your changes will be lost.';

    if (formSubmitting || !isDirty()) {
        return undefined;
    }
    alreadPrompted = true;
    timeoutID = setTimeout(reset, 100);
    (e || window.event).returnValue = confirmationMessage; //Gecko + IE
    return confirmationMessage; //Gecko + Webkit, Safari, Chrome etc.
}



// for check console is supported or not
function isConsoleExists() {
    if (typeof console != 'undefined') {
        return true;
    }
    else {
        return false;
    }
}

// for check undefined or null
function isUndefinedorNull(val) {
    if (typeof val == 'undefined' || val == null) {
        return true;
    }
    else {
        return false;
    }
}

// for check undefined or null or empty
function isUndefinedorNullorEmpty(val) {
    if (typeof val == 'undefined' || val == null || val == "") {
        return true;
    }
    else {
        return false;
    }
}

// jQuery plugin to prevent double submission of forms   i.e. :  $('form').preventDoubleSubmission();
// If there are AJAX forms that should be allowed to submit multiple times per page load, 
//you can give them a class indicating that, then exclude them from 
//your selector like this: $('form:not(.js-allow-double-submission)').preventDoubleSubmission(); 
jQuery.fn.preventDoubleSubmission = function () {
    $(this).on('submit', function (e) {
        var $form = $(this);

        if ($form.data('submitted') === true) {
            // Previously submitted - don't submit again
            e.preventDefault();
            if (isConsoleExists()) {
                console.log('Prevent multiple submission form');
            }
            return false;
        } else {
            // Mark it so that the next submit can be ignored
            var isformvalid = true;
            if ($.isFunction($("form").valid)) {
                if ($("form").valid()) {
                    isformvalid = true;
                }
                else {
                    isformvalid = false;
                }
            }
            if (isformvalid) {
                $form.data('submitted', true);
                if (isConsoleExists()) {
                    console.log('First time submit');
                }
                return true;
            }
            else {
                $form.data('submitted', false);
                if (isConsoleExists()) {
                    console.log('Form is in invalid stage');
                }
                return false;
            }
        }
    });

    // Keep chainability
    return this;
};

// populate json data to form filed
function populate(frm, data) {
    $.each(data, function (key, value) {
        var $ctrl = $('[name=' + key + ']', frm);
        switch ($ctrl.attr("type")) {
            case "text":
            case "hidden":
                $ctrl.val(value);
                break;
            case "radio": case "checkbox":
                $ctrl.each(function () {
                    if ($(this).attr('value') == value) { $(this).attr("checked", value); }
                });
                break;
            default:
                $ctrl.val(value);
        }
    });
}

// Refresh current tr after take operation
// after process take response for ajx process, 
//rerurn url as for that tr content only if it updated successfully as MessageType : 2, refreshcntl for that tr id which is refreshed
// also callback function after refreshed tr found
function GetRefreshedTr(response, return_geturl, refreshcntl, ispost, callbackFn) {
    var _ispost = ispost != undefined && ispost != null && ispost.toUpperCase() == "Y" ? "POST" : "GET";
    AjaxResultProcess(response, function () {
        $.ajax({
            url: return_geturl,
            type: _ispost,
            success: function (response) {
                if (response != null && response != "") {
                    var retcntrl = $(response).find("#" + refreshcntl).find("td");
                    var index = 1;
                    retcntrl.each(function () {
                        var src_td = $(this);
                        var rep_td = $("#" + refreshcntl).find("td:nth-child(" + index + ")");
                        if (!$(rep_td).hasClass("except")) {
                            $(rep_td).html($(src_td).html());
                        }
                        index++;
                    });

                    //-------------Call Callback function if any-----------------//
                    if (typeof callbackFn != 'undefined') {
                        if (toString.call(callbackFn) == "[object Function]") {
                            callbackFn.call();
                        }
                        else if (callbackFn != "") {
                            if (toString.call(callbackFn) == "[object String]") {
                                try {
                                    var mydel = eval(callbackFn);
                                    if (toString.call(mydel) == "[object Function]") {
                                        mydel.call();
                                    }
                                }
                                catch (e) {
                                    // used for function string call as function in utility.js
                                    parseFunc(callbackFn);
                                }
                            }
                        }
                    }
                }
            },
            error: function () {
                ShowMessage(3, "Internal Server Error, Please try again");
            }
        });
    }, "", "", false);
}

// Put your function in this function and call this when load a partial page or reintilalize all function
var initUtility = function (allowmisc) {
    try {
        InitDisableMode();
        InitNonReadMode();
        ForSelectDisableCheckbox();
        initdatepickerval();
        InitJqueryFunction();
        if ($("#LoadingImage") !== undefined) {
            $("#LoadingImage").ajaxStart(function () { $(this).show(); });
            $("#LoadingImage").ajaxSuccess(function () { $(this).hide(); });
            $("#LoadingImage").ajaxComplete(function () { $(this).hide(); });
        }
        var apply_misc = true; // for switch misc fucntion apply or not.
        if (allowmisc != undefined) {
            apply_misc = allowmisc;
        }
        if (apply_misc) {
            ForNumDecimalStyle();
            ModelCloseOnEsc();
            ModelDialogProp();
            MiscFunction();
            //$.when($(".pace pace-active").show()).then($("#LoadingImage").show());$.when($(".pace pace-active").hide()).then($("#LoadingImage").hide());
        }

        if (typeof RiicoUtility.init != 'undefined') {
            window.Utility = RiicoUtility.init;
        }
        if (typeof RiicoUtility.RejsInit != 'undefined' && typeof RiicoUtility.RejsInit == 'function') {
            window.RejsInit = RiicoUtility.RejsInit.call();
        }
    }
    catch (e) {
        if (isConsoleExists()) {
            console.log("Error Occur => " + e.message);
        }
    }
}


// init initUtility on window, document load, For better availability of initUtility call this of your page
$(function () {
    if (typeof initUtility != 'undefined') {
        if ($.isFunction(initUtility)) {
            initUtility();
        }
    }
});

// parse function string as function
var parseFunc = function (inFuncStr) {
    // trim the string
    try {
        var examineStr = inFuncStr.replace(/^\s+/g, '').replace(/\s+$/g, '');
        var evaluateStr = "";
        var functionname = "__t";
        if (examineStr.indexOf('function') > -1) {
            //if function keyword exists at start
            if (examineStr.indexOf('function') == 0) {
                var tempstr = examineStr.replace(/^\s+/g, '').replace('function', '').replace(/^\s+/g, '');
                var funcName = tempstr.substr(0, tempstr.indexOf('(')).trim();
                if (funcName != "") {
                    functionname += " = " + funcName;
                }
                evaluateStr = "var " + functionname + " = " + examineStr + ";";
            }
                //if function keyword exists at start
            else if (examineStr.indexOf('var') == 0) {
                var tempstr = examineStr.replace('var', '');
                evaluateStr = "var " + functionname + " = " + tempstr + ";";
            }
            var resFunc = eval(evaluateStr);
            if (typeof __t == 'function') {
                __t.call();
                return true;
            }
        }
        return false;
    }
    catch (e) {
        return false;
    }
}
// End code of RiicoUtility

// open enrollment form for employee
function openHRMSEnrollmentLink(empid, loginid) {
    var EmployeeId = empid;
    var currentHst = location.host.toLowerCase();
    var urlPath = typeof thisLink != 'undefined' ? (thisLink || "") : "";
    //if (currentHst == "localhost:10008") {
    //    urlPath = "http://localhost:10007";
    //}
    //else {
    //    urlPath = location.origin.toLowerCase();
    //    var pthName = location.pathname.split('/')[1].toLowerCase();
    //    if (pthName == "riico-hrms") {
    //        urlPath = urlPath + "/riicolive";
    //    }
    //    else {
    //        urlPath = urlPath + "/riico";
    //    }
    //}
    var loginId = loginid;

    //var encrypturl = '@Url.Action("ShowEnrollmentByHRMSLegacy", "Home")' + ;

    urlPath = urlPath + "/Home/ShowEnrollmentByHRMSLegacy";
    urlPath = encodeURI(urlPath);
    var redirectform = $("<form />", { action: urlPath, method: 'post', target: '_blank', enctype: 'multipart/form-data' });
    $(redirectform).append($("<input />", { type: 'hidden', name: 'EmployeeId', value: EmployeeId }));
    $(redirectform).append($("<input />", { type: 'hidden', name: 'LoginId', value: loginId }));
    $(redirectform).submit();
    //window.open(urlPath);
    //<a href="Url.ActionEncrypted("EnrollmentDetail", "Property", new { IndustId = item.IndustrialAreaPropertyId, landpropertyId = item.Id })" class="btn btn-sm btn-success"><i class="fa fa-pencil"></i></a>
}

// open legacy link for employee
function openHRMSLegacyLink(empid, loginid) {
    var EmployeeId = empid;
    var currentHst = location.host.toLowerCase();
    var urlPath = typeof HRMS_AppLink != 'undefined' ? (HRMS_AppLink || "") : "";
    //if (currentHst == "localhost:10007") {
    //    urlPath = "http://localhost:10008";
    //}
    //else {
    //    urlPath = "http://riicolive2.e-connectsolutions.com/RIICO-HRMS"; //location.origin.toLowerCase();
    //    //var pthName = location.pathname.split('/')[1].toLowerCase();
    //    //if (pthName == "riicolive") {
    //    //    urlPath = urlPath + "/riico-hrms";
    //    //}
    //    //else {
    //    //    urlPath = urlPath + "/riico-testhrms";
    //    //}
    //}
    var loginId = loginid;
    urlPath = urlPath + "/Home/ShowHRMSLegacyByEnrollment";
    urlPath = encodeURI(urlPath);
    var redirectform = $("<form />", { action: urlPath, method: 'post', target: '_blank', enctype: 'multipart/form-data' });
    $(redirectform).append($("<input />", { type: 'hidden', name: 'EmployeeId', value: EmployeeId }));
    $(redirectform).append($("<input />", { type: 'hidden', name: 'LoginId', value: loginId }));
    $(redirectform).submit();
    //window.open(urlPath);
}

// create comma seprated all input names with in a form
function fn_ExstingTrackJson(Formid, TrackFiled) {
    var FormObj = $(Formid).serializeInputName();
    if (FormObj != null && typeof FormObj == 'object') {
        if (FormObj.AllNames != null && typeof FormObj.AllNames == 'object' && !!FormObj.AllNames.join) {
            var str_JSON = FormObj.AllNames.join();
            $(Formid).find(TrackFiled).val(str_JSON);
        }
    }
}

// create comma seprated all input names with in a collection
function fn_ExstingTrackJson_forcollection(Formid, TrackFiled) {
    var FormObj = $(Formid).getCollectionDataName();
    if (FormObj != null && typeof FormObj == 'object') {
        if (FormObj.AllNames != null && typeof FormObj.AllNames == 'object' && !!FormObj.AllNames.join) {
            var str_JSON = FormObj.AllNames.join();
            $(Formid).find(TrackFiled).val(str_JSON);
        }
    }
}

// Evaluate script's which is render as html into another div using ajax
function EvalScript(victim) {
    $(victim).find("script").each(function (i) {
        eval($(this).text());
    });
}

// Equivalent Html.Raw of Mvc for get html text from unicode character
function HtmlRaw(uniChar) {
    var temp = $("<div/>").html(uniChar).text();
    return temp;
}



function LongProcessWaitDialog(msg) {
    bootbox.dialog({
        message: "<div id='divModelDoc'><div style='text-align: center; z-index:1000; vertical-align: middle;'><img style='height:50px' src='" + _urlPrefix + "/Content/Images/Ajax-Loader.gif' /><br/><span style='font-weight: bold;'> " + msg + "</span><br/><span style='font-weight: bold;color:red'> ( Note: Please do not close/refresh this window or click on back button on your browser )</span></div><div>", closeButton: false
    });
}


//Added For FCK Editor
function ShowContent(textAreaId) {
    var oEditor = FCKeditorAPI.GetInstance(textAreaId);
    alert(oEditor.GetHTML());
}

function InsertContent(textAreaId, newContent) {
    var oEditor = FCKeditorAPI.GetInstance(textAreaId);
    oEditor.InsertHtml(newContent);
}

function SetContent(textAreaId, newContent) {
    var oEditor = FCKeditorAPI.GetInstance(textAreaId);
    oEditor.SetHTML(newContent);
}

function ClearContent(textAreaId) {
    var oEditor = FCKeditorAPI.GetInstance(textAreaId);
    oEditor.SetHTML("");
}

function GetCombinedDescription(des1, des2, des3) {
    var DescriptionFinal = "";
    if (des1.length <= 125) {
        DescriptionFinal = des3;
        if (DescriptionFinal != "")
            DescriptionFinal += ", " + des2;
        else
            DescriptionFinal = des2;

        if (DescriptionFinal != "")
            DescriptionFinal += ", " + des1;
        else
            DescriptionFinal = des1;

    } else {
        DescriptionFinal = des1;
    }

    return DescriptionFinal;
}


function getMonthNumber_(monthName) {
    if (monthName.toLowerCase() == "jan")
        return 0;
    else if (monthName.toLowerCase() == "feb")
        return 1;
    else if (monthName.toLowerCase() == "mar")
        return 2;
    else if (monthName.toLowerCase() == "apr")
        return 3;
    else if (monthName.toLowerCase() == "may")
        return 4;
    else if (monthName.toLowerCase() == "jun")
        return 5;
    else if (monthName.toLowerCase() == "jul")
        return 6;
    else if (monthName.toLowerCase() == "aug")
        return 7;
    else if (monthName.toLowerCase() == "sep")
        return 8;
    else if (monthName.toLowerCase() == "oct")
        return 9;
    else if (monthName.toLowerCase() == "nov")
        return 10;
    else if (monthName.toLowerCase() == "dec")
        return 11;
}
function isDate(txtDate) {
    if (txtDate == '')
        return false;
    var date2 = txtDate.split("-");
    if (date2 == null)
        return false;

    dtMonth = getMonthNumber_(date2[1]) + 1;
    dtDay = date2[0];
    dtYear = date2[2];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;

}

function VAL(fieldName) {

    var objVictim = $("#" + fieldName);
    var value = "";
    if (objVictim.is("input")) {
        value = $(objVictim).val();
    } else {
        value = $(objVictim).html();
    }

    value = value || "";
    value = value.replace(",", "");
    if (value == "")
        return parseFloat("0");
    else
        return parseFloatV2(value, 0);

}
function SETVAL(fieldName, setValue) {

    setValue = roundNumber(setValue, 2);
    var objVictim = $("#" + fieldName);
    var value = "";
    if (objVictim.is("input")) {
        $(objVictim).val(setValue);
    } else {
        $(objVictim).html(setValue);
    }



}

function truncateDecimals(num, digits) {
    var numS = num.toString(),
        decPos = numS.indexOf('.'),
        substrLength = decPos == -1 ? numS.length : 1 + decPos + digits,
        trimmedResult = numS.substr(0, substrLength),
        finalResult = isNaN(trimmedResult) ? 0 : trimmedResult;

    return parseFloat(finalResult);
}



$('.onlyalphanumeric').on('keypress', function (e) {
    if ($(this).val() == "") {
        if (event.which === 32)
        { return false; }
        else {
            var regex = new RegExp("^[a-zA-Z0-9. \b_-]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    }
    else {
        var regex = new RegExp("^[a-zA-Z0-9. \b_-]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    return true;
});
$('.onlyalphabets').on('keypress', function (e) {
    if ($(this).val() == "") {
        if (event.which === 32)
        { return false; }
        else {
            var regex = new RegExp("^[a-zA-Z. \b_-]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    }
    else {
        var regex = new RegExp("^[a-zA-Z. \b_-]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    return true;
});
$('.onlynumber').on('keypress', function (e) {

    var thisval = $(this).val();
    if (thisval == "") {
        $(this).css("text-align", "");
    }
    else {
        $(this).css("text-align", "right");
    }
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();

        return false;

    }
    return true;
});

$('.onlydecimal').on('keypress', function (e) {

    var thisval = $(this).val();
    if (thisval == "") {
        $(this).css("text-align", "");
    }
    else {
        $(this).css("text-align", "right");
    }
    var regex = new RegExp("^[0-9.]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();

        return false;

    }
    return true;
});

$('.onlydecimalminus').on('keypress', function (e) {

    var thisval = $(this).val();
    if (thisval == "") {
        $(this).css("text-align", "");
    }
    else {
        $(this).css("text-align", "right");
    }
    var regex = new RegExp("^[0-9.-]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();

        return false;

    }
    return true;
});

$('.Specialalphanumeric').on('keypress', function (e) {
    if ($(this).val() == "") {
        if (event.which === 32)
        { return false; }
        else {
            var regex = new RegExp("^[:a-zA-Z0-9.,()/\\\\/ \b_-]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    }
    else {
        var regex = new RegExp("^[:a-zA-Z0-9.,()/\\\\/ \b_-]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    return true;
});

$('.Specialalpha').on('keypress', function (e) {
    if ($(this).val() == "") {
        if (event.which === 32)
        { return false; }
        else {
            var regex = new RegExp("^[:a-zA-Z.,()/\\\\/ \b_-]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    }
    else {
        var regex = new RegExp("^[:a-zA-Z.,()/\\\\/ \b_-]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    return true;
});

$('.Specialnumeric').on('keypress', function (e) {
    if ($(this).val() == "") {
        if (event.which === 32)
        { return false; }
        else {
            var regex = new RegExp("^[:0-9.,()/\\\\/ \b_-]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    }
    else {
        var regex = new RegExp("^[:0-9.,()/\\\\/ \b_-]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
    return true;
});

// end code



$(window).resize(function () {
    showFC($("#btnformfilter"));
});
function GetFullMonthName(Month) {
    var monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"];
    return monthNames[Month];
}

$('.decimaltwodigit').keypress(function (e) {
    var character = String.fromCharCode(e.keyCode)
    var newValue = this.value + character;
    if (isNaN(newValue) || hasDecimalPlace(newValue, 3)) {
        e.preventDefault();
        return false;
    }
});

function hasDecimalPlace(value, x) {
    var pointIndex = value.indexOf('.');
    return pointIndex >= 0 && pointIndex < value.length - x;
}