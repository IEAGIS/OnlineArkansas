$(function () {
    $("#accordion").accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });

    $("#subaccordion").accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });

});

jQuery(document).ready(function ($) {

    $('.lightbox').lightbox();

    $("#map1").click(function () {
        var html = $("<div class='center'><img width='600' height='780' alt='wpeD.jpg (58269 bytes)' src='~/maps/Median_Age_Black_Total_2000_2010.jpg'></div>");

        $.lightbox(html, {
            width: 610,
            height: 790
        });

        return false;
    });
}); 
