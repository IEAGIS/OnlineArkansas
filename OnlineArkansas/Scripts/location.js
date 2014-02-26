jQuery(document).ready(function ($) {
    $('.lightbox').lightbox();

    $("#ualrmap").click(function () {
        var html = $("<div class='center'><img width='600' height='870' alt='wpeD.jpg (58269 bytes)' src='img/campusbuildingmap2013.jpg'></div>");

        $.lightbox(html, {
            width: 610,
            height: 880
        });

        return false;
    });
});