﻿/// <reference path="../../plugins/jquery/jquery-2.2.0.min.js" />
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
            var _layout = {
                Titles: [
                    { Title: $('#title1').val(), Animate: $('#title1_animate').val(), Delay: $('#delay_title1').val(), IsBold: $('#IsBold_title1').prop('checked'), IsItalic: $('#IsItalic_title1').prop('checked'), Style: $('#title1').attr('data-class') },
                    { Title: $('#title2').val(), Animate: $('#title2_animate').val(), Delay: $('#delay_title2').val(), IsBold: $('#IsBold_title2').prop('checked'), IsItalic: $('#IsItalic_title2').prop('checked'), Style: $('#title2').attr('data-class') },
                    { Title: $('#title3').val(), Animate: $('#title3_animate').val(), Delay: $('#delay_title3').val(), IsBold: $('#IsBold_title3').prop('checked'), IsItalic: $('#IsItalic_title3').prop('checked'), Style: $('#title3').attr('data-class') }
                ],
                Button: { Title: $('#button_title').val(), Link: $('#button_link').val() },
                CaptionFrame: { Animate: $('#caption_animate').val(), Delay: $('#caption_delay_time').val() }
            };

            createCarouselObject(_basicCarouselJson, _option, _layout);
            break;
        case 'normal_control':
            var layout_selected = $('#selected_type').attr('data-selected');
            switch (layout_selected) {
                case 'text2':
                    var _layout = {
                        Titles: [
                            { Title: $('#title1').val(), Animate: $('#title1_animate').val(), Delay: $('#delay_title1').val(), IsBold: $('#IsBold_title1').prop('checked'), IsItalic: $('#IsItalic_title1').prop('checked'), Style: $('#title1').attr('data-class') },
                            { Title: $('#title2').val(), Animate: $('#title2_animate').val(), Delay: $('#delay_title2').val(), IsBold: $('#IsBold_title2').prop('checked'), IsItalic: $('#IsItalic_title2').prop('checked'), Style: $('#title2').attr('data-class') },
                            { Title: $('#title3').val(), Animate: $('#title3_animate').val(), Delay: $('#delay_title3').val(), IsBold: $('#IsBold_title3').prop('checked'), IsItalic: $('#IsItalic_title3').prop('checked'), Style: $('#title3').attr('data-class') },
                            { Title: $('#title4').val(), Animate: $('#title4_animate').val(), Delay: $('#delay_title4').val(), IsBold: $('#IsBold_title4').prop('checked'), IsItalic: $('#IsItalic_title4').prop('checked'), Style: $('#title4').attr('data-class') },
                            { Title: $('#title5').val(), Animate: $('#title5_animate').val(), Delay: $('#delay_title5').val(), IsBold: $('#IsBold_title5').prop('checked'), IsItalic: $('#IsItalic_title5').prop('checked'), Style: $('#title5').attr('data-class') }
                        ],
                        Button: null
                    };
                    createCarouselObject(_basicCarouselJson, _option, _layout);
                    break;
                case 'text3':
                    var _layout = {
                        Titles: [
                            { Title: $('#title1').val(), Animate: $('#title1_animate').val(), Delay: $('#delay_title1').val(), IsBold: $('#IsBold_title1').prop('checked'), IsItalic: $('#IsItalic_title1').prop('checked'), Style: $('#title1').attr('data-class') },
                            { Title: $('#title2').val(), Animate: $('#title2_animate').val(), Delay: $('#delay_title2').val(), IsBold: $('#IsBold_title2').prop('checked'), IsItalic: $('#IsItalic_title2').prop('checked'), Style: $('#title2').attr('data-class') },
                            { Title: $('#title3').val(), Animate: $('#title3_animate').val(), Delay: $('#delay_title3').val(), IsBold: $('#IsBold_title3').prop('checked'), IsItalic: $('#IsItalic_title3').prop('checked'), Style: $('#title3').attr('data-class') },
                            { Title: $('#title4').val(), Animate: $('#title4_animate').val(), Delay: $('#delay_title4').val(), IsBold: $('#IsBold_title4').prop('checked'), IsItalic: $('#IsItalic_title4').prop('checked'), Style: $('#title4').attr('data-class') },
                            { Title: $('#title5').val(), Animate: $('#title5_animate').val(), Delay: $('#delay_title5').val(), IsBold: $('#IsBold_title5').prop('checked'), IsItalic: $('#IsItalic_title5').prop('checked'), Style: $('#title5').attr('data-class') }
                        ],
                        Button: { Title: $('#button_title').val(), Animate: $('#button_animate').val(), Delay: $('#delay_time_button').val(), Link: $('#button_link').val() }
                    };
                    createCarouselObject(_basicCarouselJson, _option, _layout);
                    break;
                case 'text4':
                    var _layout = {
                        Titles: [
                            { Title: $('#title1').val(), Animate: $('#title1_animate').val(), Delay: $('#delay_title1').val(), IsBold: $('#IsBold_title1').prop('checked'), IsItalic: $('#IsItalic_title1').prop('checked'), Style: $('#title1').attr('data-class') },
                            { Title: $('#title2').val(), Animate: $('#title2_animate').val(), Delay: $('#delay_title2').val(), IsBold: $('#IsBold_title2').prop('checked'), IsItalic: $('#IsItalic_title2').prop('checked'), Style: $('#title2').attr('data-class') },
                            { Title: $('#title3').val(), Animate: $('#title3_animate').val(), Delay: $('#delay_title3').val(), IsBold: $('#IsBold_title3').prop('checked'), IsItalic: $('#IsItalic_title3').prop('checked'), Style: $('#title3').attr('data-class') }
                        ],
                        Button: { Title: $('#button_title').val(), Animate: $('#button_animate').val(), Delay: $('#delay_time_button').val(), Link: $('#button_link').val() }
                    };
                    createCarouselObject(_basicCarouselJson, _option, _layout);
                    break;
            }
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
    $('#selected_type').attr('data-selected', $(this).val());
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

$('body').on('click', 'button[data-button="save"]', function () {
    var _carousel_id = parseInt($(this).attr('data-object-id'));
    var _beginDate = $('#begin_date-' + _carousel_id).val();
    var _endDate = $('#end_date-' + _carousel_id).val();
    var isEnabled = $('#checkbox-' + _carousel_id).prop('checked');
    var _sortOrder = $('#sort_order-' + _carousel_id).val();
    var _img_source = $('#img-' + _carousel_id).attr('src');
    var data = {
        ID: _carousel_id,
        ImagePath: _img_source,
        BeginDate: _beginDate,
        EndDate: _endDate,
        IsEnabled: isEnabled,
        SortOrder: _sortOrder
    };
    $.ajax({
        type: "POST",
        url: "/PageSetting/UpdateCarousel",
        data: { json: JSON.stringify(data) },
        dataType: "json",
        success: function (response) {
            switch (response.IsError) {
                case 0:
                    swal("Carousel is updated", response.Messages, "success");
                    break;
                case 1:
                    swal("Update Failed", response.Messages, "error");
                    break;
            }
        }
    });
});

$('body').on('change', '.img_change_event', function () {
    var carousel_id = parseInt($(this).attr('data-object-id'));
    $('#img-' + carousel_id).attr('src', $(this).val());
});