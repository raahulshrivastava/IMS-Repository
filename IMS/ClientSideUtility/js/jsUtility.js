$(document).ready(function () {
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

});

