/// <reference path="../../plugins/jquery/jquery-2.2.0.min.js" />
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