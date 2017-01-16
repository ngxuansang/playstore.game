/// <reference path="../../plugins/jquery/jquery-2.2.0.min.js" />
function getListAnimate() {
    $.ajax({
        type: "GET",
        url: "/PageSetting/ListAnimte",
        success: function (response) {
            $('.combobox_animate').append(response);
            $('.combobox_animate').val('disabled');
        }
    });
}

function DisplayNormalControl() {
    $('div[class="row"][data-view-control="rdo"]').empty();
    $('div[class="row"][data-view-control="rdo"]').attr('data-control', 'normal_control');
    $.ajax({
        type: "GET",
        url: "/PageSetting/NormalControl",
        success: function (response) {
            $('div[class="row"][data-view-control="rdo"]').html(response);
        }
    });
}

function createCarouselObject(_basic, _option, _layout) {
    $.ajax({
        type: "POST",
        url: "/PageSetting/Create",
        data: { basicCarousel: JSON.stringify(_basic), option: _option, layout: JSON.stringify(_layout) },
        dataType: "json",
        success: function (response) {
            switch (response.IsError) {
                case 0:
                    swal("Carousel is created", response.Messages, "success");
                    break;
                case 1:
                    swal("Failed", response.Messages, "error");
                    break;
            }
        }
    });
}

$(document).ready(function () {
    DisplayNormalControl();
});

$('body').on('click', 'button[data-button="detail"]', function () {
    $('#tab_carousel_detail').removeClass('disabled');
    $('#tab_carousel_detail').addClass('active');
    $('#detail_carousel').css('display', 'block');
    $('.indicator').css('right', '352.667px');
    $('.indicator').css('left', '352.667px');

    $('#tab_carousel_view').addClass('disabled');
    $('#tab_carousel_create').addClass('disabled');

    $('#create_carousel').css('display', 'none');
    $('#carousel_view').css('display', 'none');
});

$('#detail_carousel').on('click', '#btn_save', function () {
    window.location.reload();
});

$('#detail_carousel').on('click', '#btn_close', function () {
    window.location.reload();
});

$('#frm_create').on('click', '#btn_create', function (event) {
    var image_url = $('#ImagePath').val();
    var sort_order = $('#SortOrder').val();
    var begin_date = $('#BeginDate').val();
    var end_date = $('#EndDate').val();
    var is_display = $('#IsEnabled').prop('checked');

    var _basicCarouselJson = { ImagePath: image_url, SortOrder: sort_order, BeginDate: begin_date, EndDate: end_date, IsEnabled: is_display };
    var _option = $('div[class="row"][data-view-control="rdo"]').attr('data-control');

    switch (_option) {
        case 'caption_control':
            var title1 = $('#title1').val();
            var title1_animate = $('#title1_animate').val();
            var delay_title1 = $('#delay_title1').val();
            var title1_isBold = $('#IsBold_title1').prop('checked');
            var title1_isItalic = $('#IsItalic_title1').prop('checked');

            var title2 = $('#title2').val();
            var title2_animate = $('#title2_animate').val();
            var delay_title2 = $('#delay_title2').val();
            var title2_isBold = $('#IsBold_title2').prop('checked');
            var title2_isItalic = $('#IsItalic_title2').prop('checked');

            var title3 = $('#title3').val();
            var title3_animate = $('#title3_animate').val();
            var delay_title3 = $('#delay_title3').val();
            var title3_isBold = $('#IsBold_title3').prop('checked');
            var title3_isItalic = $('#IsItalic_title3').prop('checked');

            var buttonTitle = $('#button_title').val();
            var buttonTitle_link = $('#button_link').val();

            var caption_delay_time = $('#caption_delay_time').val();
            var caption_animate = $('#caption_animate').val();

            var _layout = {
                Titles: [
                    { Title: title1, Animate: title1_animate, Delay: delay_title1, IsBold: title1_isBold, IsItalic: title1_isItalic },
                    { Title: title2, Animate: title2_animate, Delay: delay_title2, IsBold: title2_isBold, IsItalic: title2_isItalic },
                    { Title: title3, Animate: title3_animate, Delay: delay_title3, IsBold: title3_isBold, IsItalic: title3_isItalic }
                ],
                Button: { Title: buttonTitle, Link: buttonTitle_link },
                CaptionFrame: { Animate: caption_animate, Delay: caption_delay_time }
            };
            //var _layout = {
            //    Title1: title1,
            //    Title1Animate: title1_animate,
            //    Title1Delay: delay_title1,
            //    Title1Bold: title1_isBold,
            //    Title1Italic: title1_isItalic,

            //    Title2: title2,
            //    Title2Animate: title2_animate,
            //    Title2Delay: delay_title2,
            //    Title2Bold: title2_isBold,
            //    Title2Italic: title2_isItalic,

            //    Title3: title3,
            //    Title3Animate: title3_animate,
            //    Title3Delay: delay_title3,
            //    Title3Bold: title3_isBold,
            //    Title3Italic: title3_isItalic,

            //    ButtonTitle: buttonTitle,
            //    ButtonAnimate: buttonTitle_animate,
            //    ButtonDelay: delay_buttonTitle,

            //    CaptionAnimate: caption_delay_time,
            //    CaptionDelay: caption_animate
            //};
            console.log(_layout);
            createCarouselObject(_basicCarouselJson, _option, _layout);
            break;
        case 'normal_control':
            console.log(_option);
            break;
    }
});

$('body').on('change', '#IsCaptionContainer', function () {
    if ($(this).prop('checked')) {
        $('#dropdown_caption_animate').removeClass('hiddendiv');
    }
    else {
        console.log($(this).prop('checked'));
        $('#dropdown_caption_animate').addClass('hiddendiv');
    }
});

$('body').on('change', '#IsEnabled', function () {
    if ($(this).prop('checked')) {
        $(this).parent().find('i[class="material-icons left"]').css('color', '#80cbc4');
    }
    else {
        $(this).parent().find('i[class="material-icons left"]').css('color', '#757575');
    }
});

$('body').on('change', '#rdo_inner_caption:checked', function () {
    $('div[class="row"][data-view-control="rdo"]').empty();
    $('div[class="row"][data-view-control="rdo"]').attr('data-control', 'caption_control');
    $.ajax({
        type: "GET",
        url: "/PageSetting/InnerCaptionControl",
        success: function (response) {
            $('div[class="row"][data-view-control="rdo"]').html(response);
            ///initial animate combobox animate
            getListAnimate();
        }
    });
});

$('body').on('change', '#rdo_normal:checked', function () {
    DisplayNormalControl();
});

$('body').on('change', '#combobox_layout', function () {
    var class_name = $(this).val();
    var data_range = parseInt($(this).find('option[value="' + class_name + '"]').attr('data-range'));
    var data_button = parseInt($(this).find('option[value="' + class_name + '"]').attr('data-button'));

    $.ajax({
        type: "GET",
        url: "/PageSetting/RenderControl",
        data: { className: class_name, range: data_range, button: data_button },
        success: function (response) {
            $('#selected_type').html(response);
            ///initial animate combobox animate
            getListAnimate();
        }
    });
});