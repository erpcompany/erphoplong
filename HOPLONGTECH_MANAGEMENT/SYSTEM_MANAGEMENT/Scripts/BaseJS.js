function setCookie(c_name, value, exdays) { var exdate = new Date(); exdate.setDate(exdate.getDate() + exdays); var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString()); document.cookie = c_name + "=" + c_value; }
function getCookie(c_name) { var i, x, y, ARRcookies = document.cookie.split(";"); for (i = 0; i < ARRcookies.length; i++) { x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("=")); y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1); x = x.replace(/^\s+|\s+$/g, ""); if (x == c_name) { return unescape(y); } } }
function ShowResponseTime() {
    var tg = getCookie('TimeExecute');
    var timeExecute = parseFloat(tg);
    timeExecute = timeExecute / 1000;
    $("#divResponseTime").html('<span class="separator">|</span>&nbsp;&nbsp;' + timeExecute.toFixed(2) + ' sec');
};
(function (b) { b.fn.bPopup = function (n, p) { function t() { b.isFunction(a.onOpen) && a.onOpen.call(c); k = (e.data("bPopup") || 0) + 1; d = "__bPopup" + k; l = "auto" !== a.position[1]; m = "auto" !== a.position[0]; i = "fixed" === a.positionStyle; j = r(c, a.amsl); f = l ? a.position[1] : j[1]; g = m ? a.position[0] : j[0]; q = s(); a.modal && b('<div class="bModal ' + d + '"></div>').css({ "background-color": a.modalColor, height: "100%", left: 0, opacity: 0, position: "fixed", top: 0, width: "100%", "z-index": a.zIndex + k }).each(function () { a.appending && b(this).appendTo(a.appendTo) }).animate({ opacity: a.opacity }, a.fadeSpeed); c.data("bPopup", a).data("id", d).css({ left: !a.follow[0] && m || i ? g : h.scrollLeft() + g, position: a.positionStyle || "absolute", top: !a.follow[1] && l || i ? f : h.scrollTop() + f, "z-index": a.zIndex + k + 1 }).each(function () { a.appending && b(this).appendTo(a.appendTo); if (null != a.loadUrl) switch (a.contentContainer = b(a.contentContainer || c), a.content) { case "iframe": b('<iframe scrolling="no" frameborder="0"></iframe>').attr("src", a.loadUrl).appendTo(a.contentContainer); break; default: a.contentContainer.load(a.loadUrl) } }).fadeIn(a.fadeSpeed, function () { b.isFunction(p) && p.call(c); u() }) } function o() { a.modal && b(".bModal." + c.data("id")).fadeOut(a.fadeSpeed, function () { b(this).remove() }); c.stop().fadeOut(a.fadeSpeed, function () { null != a.loadUrl && a.contentContainer.empty() }); e.data("bPopup", 0 < e.data("bPopup") - 1 ? e.data("bPopup") - 1 : null); a.scrollBar || b("html").css("overflow", "auto"); b("." + a.closeClass).on("click." + d); b(".bModal." + d).on("click"); h.unbind("keydown." + d); e.unbind("." + d); c.data("bPopup", null); b.isFunction(a.onClose) && setTimeout(function () { a.onClose.call(c) }, a.fadeSpeed); return !1 } function u() { e.data("bPopup", k); b("." + a.closeClass).on("click." + d, o); a.modalClose && b(".bModal." + d).on("click", o).css("cursor", "pointer"); (a.follow[0] || a.follow[1]) && e.bind("scroll." + d, function () { q && c.stop().animate({ left: a.follow[0] && !i ? h.scrollLeft() + g : g, top: a.follow[1] && !i ? h.scrollTop() + f : f }, a.followSpeed) }).bind("resize." + d, function () { if (q = s()) j = r(c, a.amsl), a.follow[0] && (g = m ? g : j[0]), a.follow[1] && (f = l ? f : j[1]), c.stop().each(function () { i ? b(this).css({ left: g, top: f }, a.followSpeed) : b(this).animate({ left: m ? g : g + h.scrollLeft(), top: l ? f : f + h.scrollTop() }, a.followSpeed) }) }); a.escClose && h.bind("keydown." + d, function (a) { 27 == a.which && o() }) } function r(a, b) { var c = (e.width() - a.outerWidth(!0)) / 2, d = (e.height() - a.outerHeight(!0)) / 2 - b; return [c, 20 > d ? 20 : d] } function s() { return e.height() > c.outerHeight(!0) + 20 && e.width() > c.outerWidth(!0) + 20 } b.isFunction(n) && (p = n, n = null); var a = b.extend({}, b.fn.bPopup.defaults, n); a.scrollBar || b("html").css("overflow", "hidden"); var c = this, h = b(document), e = b(window), k, d, q, l, m, i, j, f, g; this.close = function () { a = c.data("bPopup"); o() }; return this.each(function () { c.data("bPopup") || t() }) }; b.fn.bPopup.defaults = { amsl: 50, appending: !0, appendTo: "body", closeClass: "bClose", content: "ajax", contentContainer: null, escClose: !0, fadeSpeed: 250, follow: [!0, !0], followSpeed: 500, loadUrl: null, modal: !0, modalClose: !0, modalColor: "#000", onClose: null, onOpen: null, opacity: 0.3, position: ["auto", "auto"], positionStyle: "absolute", scrollBar: !0, zIndex: 9997 } })(jQuery);
var _handlerOK;
var _handlerYes;
var _handlerNo;
var _file_report = "/Content/Reports/Output/";
var _file_phieuin = "/Content/PhieuIn/";
var _file_hoichan = "/Content/HoiChan/";
var _file_dutru = "/Content/PhieuIn/PhieuDuTru/";
var _file_BHYT_rar = "/Content/BHYTFileRar/";
var _file_anhthuoc = "/Content/AnhThuoc/";
var _baseUrl = $("#config_ApiUrl").val();
var _webUrl = $("#config_WebUrl").val();
var _domain = $("#config_Doamin").val();
var _userid = $('#IdBacSy').val();
var _benhvienid = $('#idBenhVien').val();
var _khoaid = $('#idKhoa').val();
var _khoid = $('#idKho').val();
var _phongid = $('#idPhong').val();
var _groupid = $('#idGroup').val(); 
var _sChucDanh = $('#sChucDanh').val();
var _idEmpty = '00000000-0000-0000-0000-000000000000';
var _idKhoDuocNgoaiTru = '7a88d026-668a-417b-a24c-f84d93a772a9';
///////c
var defaults = {
    duration: 3000,
    klass: "flesh",
    blinkDuration: 400
};
$.fn.flesh = function (msg, usrOptions, css) {
    var timeout;
    var options;
    if ($.type(usrOptions) === "number") {
        timeout = usrOptions;
        options = defaults;
    }
    else {
        options = $.extend({}, defaults, usrOptions);
        timeout = options.duration;
    }

    return this.each(function () {
        var $fleshElem = $(this);
        $fleshElem.on("click", function () {
            $(this).fadeOut("slow");
        });
        if (msg) {
            if ("flash-modal" == $fleshElem.attr("id") || $fleshElem.hasClass("flesh-modal"))
                $fleshElem.html("<span class='flash-dialog'><span class='dialog-content'>" + msg + "<a class=\"fright\">x</a></span></span>");
            else
                $fleshElem.text(msg);
        }
        /*format its css*/
        var _lastCss = $fleshElem.attr("class");
        if (_lastCss == null || _lastCss == '')
            $fleshElem.attr("class", css == null ? options.klass : "flesh " + css);
        /*show it*/
        $fleshElem.fadeIn("slow");

        var to = $fleshElem.data("__timeout");
        if (to) {
            clearTimeout(to);
        }
        to = setTimeout(function () {
            $fleshElem.fadeOut("slow");
        }, timeout);
        $fleshElem.data("__timeout", to);
    });
};

/////////

function confirmPopup(title, warning, handlerYes, handlerNo) {
    $("#confirmPopup").remove();

    _handlerYes = handlerYes;
    _handlerNo = handlerNo;
    var sBuild = '<div id="confirmPopup" class="popup" style="display: none;">';
    sBuild += "<h4>" + title + "</h4>";
    sBuild += '<div class="popup_content" style="text-align:center;" >';
    sBuild += "<p>" + warning + "</p><br />";
    sBuild += '<span><a onclick="confirmYes();" href="javascript:void(0)" id="btnOK" class="twitt-button twitt-save-button twitt-button-medium"><span class=" "><span class=" "><span class="btn btn-primary" autofocus="true" style="width: 70px;">Có</span></span></span></a></span>';
    sBuild += '<span style="margin-left:5px;"><a onclick="confirmNo();" href="javascript:void(0)" class="twitt-button twitt-cancel-button twitt-button-medium"><span class=" "><span class=" "><span class="btn btn-default">Không</span></span></span></a></span>';
    sBuild += '</div></div>';
    $('body').append(sBuild);
    $("#confirmPopup").bPopup();
    $("#btnOK").focus();
}

function confirmYes() {
    $("#confirmPopup").bPopup().close();
    $("#confirmPopup").remove();
    _handlerYes();
}

function confirmNo() {
    $("#confirmPopup").bPopup().close();
    $("#confirmPopup").remove();
    _handlerNo();
}

function ShowMessage(msg, duration) {
    $('#info-modal').flesh(msg, duration);
}

function ShowError(msg, duration) {
    $('#error-modal').flesh(msg, duration);
}

function alertPopup(title, message) {
    $("#alertPopup").remove();
    var sBuild = '<div id="alertPopup" class="popup" style="display: none;">';
    sBuild += "<h4>" + title + "</h4>";
    sBuild += '<div class="popup_content" style="text-align:center;" >';
    sBuild += "<p>" + message + "</p><br />";
    sBuild += '<span style="margin-left:5px;"><a onclick="alertClose();" href="javascript:void(0)" id="btnOK" class="twitt-button twitt-cancel-button twitt-button-medium btn btn-warning" style="width: 100px"><span class=" "><span class=" "><span class=" ">Ok</span></span></span></a></span>';
    sBuild += '</div></div>';
    $('body').append(sBuild);
    $("#alertPopup").bPopup();
    $("#btnOK").focus();
}
var KyTu = ["aeouidy", "áàạảãâấầậẩẫăắằặẳẵ", "éèẹẻẽêếềệểễ",
    "óòọỏõôốồộổỗơớờợởỡ", "úùụủũưứừựửữ", "íìịỉĩ", "đ", "ýỳỵỷỹ"]
var ReplaceKyTu = function (str) {
    for (var i = 1; i < KyTu.length; i++) {
        for (var j = 0; j < KyTu[i].length; j++) {
            str = str.replace(KyTu[i][j], KyTu[0][i - 1]);
        }
    }
    return str;
}
function alertClose() {
    $("#alertPopup").bPopup().close();
    $("#alertPopup").remove();
}

function GetlstPage(pageTotal, pageIndex, functionLoad) {
    var str = '';
    if (pageTotal > 1) {
        // Button previous
        if (pageIndex > 1)
            str = str + '<li class="paginate_button previous" data-ng-click="' + functionLoad + '(1)"><a> << </a></li>';
        else
            str = str + '<li class="paginate_button previous disabled"><a > << </a></li>';
        // Các Button giữa
        if (pageTotal <= 9) {
            for (var i = 1; i < pageTotal + 1; i++) {
                if (pageIndex == i) {
                    str = str + '<li class="paginate_button active"><a >' + i + '</a></li>';
                }
                else {
                    str = str + '<li class="paginate_button " data-ng-click="' + functionLoad + '(' + i + ')"><a >' + i + '</a></li>'
                }
            }
        }
        else // Neu co nhieu hon 9 page
        {
            if (pageIndex > 1 && pageIndex < pageTotal) {
                if (pageIndex - 4 > 1) str = str + '<li class="paginate_button "><a>...</a></li>';
                for (var i = pageIndex - 4; i < pageIndex + 5; i++) {
                    if (i > 0 && i <= pageTotal) {
                        if (i == pageIndex)
                            str = str + '<li class="paginate_button active"><a >' + pageIndex + '</a></li>';
                        else
                            str = str + '<li class="paginate_button " data-ng-click="' + functionLoad + '(' + i + ')"><a>' + i + '</a></li>';
                    }
                }
                if (pageIndex + 4 < pageTotal) str = str + '<li class="paginate_button "><a>...</a></li>';
            }
            else if (pageIndex == 1) {
                str = str + '<li class="paginate_button active"><a >' + pageIndex + '</a></li>';
                for (var i = pageIndex + 1; i < pageIndex + 9; i++) {
                    if (i <= pageTotal) {
                        str = str + '<li class="paginate_button " data-ng-click="' + functionLoad + '(' + i + ')"><a >' + i + '</a></li>';
                    }
                }
                if (pageIndex + 8 < pageTotal) str = str + '<li ><a>...</a></li>';
            }
            else if (pageIndex == pageTotal) {
                if (pageIndex - 8 > 1) str = str + '<li class="paginate_button "><a>...</a></li>';
                for (var i = pageIndex - 8; i < pageIndex; i++) {
                    if (i > 0) {
                        str = str + '<li class="paginate_button " data-ng-click="' + functionLoad + '(' + i + ')"><a>' + i + '</a></li>';
                    }
                }
                str = str + '<li class="paginate_button active"><a>' + pageIndex + '</a></li>';
            }
        }

        if (pageIndex < pageTotal)
            str = str + '<li class="paginate_button next" data-ng-click="' + functionLoad + '(' + pageTotal + ')"><a> >> </a></li>';
        else
            str = str + '<li class="paginate_button next disabled"><a> >> </a></li>';
    }
    return str;
};

//$(document).ready(function () {
//    var myObj = $.deparam.querystring();
//    // Thêm vào các attribute của link query param viewas
//    // Để thay đổi thông tin của CurrentUser cho những Request MVC
//    if (myObj.viewas) {
//        $("#body-content a").querystring({
//            'viewas': myObj.viewas,
//            'viewasidkhoa': myObj.viewasidkhoa,
//            'viewasidcanbo': myObj.viewasidcanbo,
//            'viewasname': myObj.viewasname
//        });
//        $('#idKhoa').val(myObj.viewasidkhoa);
//        $('#IdBacSy').val(myObj.viewasidcanbo);
//        $('#viewasname').html(myObj.viewasname);
//        $('#viewas-noti').show();
//        $('.navbar').addClass('navbar-fixed-top');
//        $('.navbar').removeClass('navbar-static-top');
//        $('#page-wrapper').css('margin-top', '37px');
//    }
//    else {
//        $('#viewas-noti').hide();
//        $('.navbar').addClass('navbar-static-top');
//        $('.navbar').removeClass('navbar-fixed-top');
//        $('#page-wrapper').css('margin-top', '0px');
//    }
//});

// sum theo column trong list
Array.prototype.sum = function (prop) {
    var total = 0
    for (var i = 0, _len = this.length; i < _len; i++) {
        total += this[i][prop]
    }
    return total
}