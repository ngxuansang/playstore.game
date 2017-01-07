/// <reference path="../js/vendor/jquery/jquery.js" />
/// <reference path="../js/vendor/bootstrap/bootstrap.min.js" />
var waiting = '<i class="fa fa-spinner fa-spin"></i>';

$('header > .navbar').on('click', '#btn-login', function () {
    $.ajax({
        type: "POST",
        url: "/Account/Login",
        data: $('#frm-login').serialize(),
        beforeSend: function () {
            $('#btn-login').html('<i class="fa fa-spinner fa-spin"></i> Sign in');
        },
        success: function (response) {
            debugger
            var key = response.Key;
            if (key == 1) {
                window.location.reload();
            }
            if (key == undefined) {
                $('.dropdown-container.right').remove();
                $('.header-link.dropdown-link.header-account').append(response);
                $('#btn-login').html('Sign in');
            }
        },
    });
    $('#frm-login').submit(function (event) {
        event.preventDefault();
    });
});