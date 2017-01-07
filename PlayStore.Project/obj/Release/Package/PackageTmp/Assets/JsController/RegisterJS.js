/// <reference path="../js/vendor/jquery/jquery.js" />
/// <reference path="../js/vendor/bootstrap/bootstrap.min.js" />

$(document).ready(function () {
    $('#LocationParentID').append('<option value="0">Select city</option>');
    $('#LocationParentID').val(0);
});

$('body').on('change', '#LocationParentID', function () {
    var city_id = parseInt($(this).val());
    $.ajax({
        type: "POST",
        url: "/Account/GetStateListByCity",
        data: { cityID: city_id },
        success: function (response) {
            debugger
            var objects = JSON.parse(response);
            $('#LocationID').empty();
            $('#LocationID').append('<option value="0">Select state</option>');
            for (var i = 0; i < objects.length; i++) {
                $('#LocationID').append('<option value="' + objects[i].ID + '">' + objects[i].LocationName + '</option>');
            }
        }
    });
});