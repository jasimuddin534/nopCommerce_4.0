var owl = $('.owl-carousel');
owl.owlCarousel({
    margin: 10,
    loop: true,
    autoplay: false,
    autoplayTimeout: 4000,
    autoplayHoverPause: true,
    //nav: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
})

var owl2 = $('.owl-nav');
owl2.owlCarousel({
    margin: 10,
    loop: true,
    autoplay: false,
    autoplayTimeout: 4000,
    autoplayHoverPause: true,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
})
/*function text_trim(text_limit) {
    var elem = $(this);         // The element or elements with the text to hide
    var limit = text_limit;        // The number of characters to show
    var str = elem.html();    // Getting the text
    var strtemp = str.substr(0, limit);   // Get the visible part of the string
    str = strtemp + '<span class="hidden-text">' + " ..." + '</span>';  // Recompose the string with the span tag wrapped around the hidden part of it
    elem.html(str);
}*/

$(".center-2 .product-grid .products_box .product-title a").each(function (index, element) {
    var elem = $(this);         // The element or elements with the text to hide
    var limit = 18;        // The number of characters to show
    var str = elem.html();    // Getting the text
    if (elem.html().length > limit) {
        var strtemp = str.substr(0, limit);   // Get the visible part of the string
        str = strtemp + '<span class="hidden-text">' + " ..." + '</span>';  // Recompose the string with the span tag wrapped around the hidden part of it
        elem.html(str);
    } else {
        elem.html(str);
    }
})



//$(".center-2  .product-grid .products_box .description").each(function (index, element) {
//    var elem = $(this);         // The element or elements with the text to hide
//    var limit = 50;        // The number of characters to show
//    var str = elem.html();    // Getting the text
//    if (elem.html().length > limit) {
//        var strtemp = str.substr(0, limit);   // Get the visible part of the string
//        str = strtemp + '<span class="hidden-text">' + "..." + '</span>';  // Recompose the string with the span tag wrapped around the hidden part of it
//        elem.html(str);
//    } else {
//        elem.html(str);
//    }
//})
///*card text limit here*/
//$(".products_box  .card-text").each(function (index, element) {
//    var elem = $(this);         // The element or elements with the text to hide
//    var limit = 60;        // The number of characters to show
//    var str = elem.html();    // Getting the text
//    if (elem.html().length > limit) {
//        var strtemp = str.substr(0, limit);   // Get the visible part of the string
//        str = strtemp + '<span class="hidden-text">' + " ..." + '</span>';  // Recompose the string with the span tag wrapped around the hidden part of it
//        elem.html(str);
//    } else {
//        elem.html(str);
//    } 
//})

///*news text limit here*/
//$(".news-items  .news-item .news-text").each(function (index, element) {
//    var elem = $(this);         // The element or elements with the text to hide
//    var limit = 140;        // The number of characters to show
//    var str = elem.html();    // Getting the text
//    if (elem.html().length > limit) {
//        var strtemp = str.substr(0, limit);   // Get the visible part of the string
//        str = strtemp + '<span class="hidden-text">' + " ..." + '</span>';  // Recompose the string with the span tag wrapped around the hidden part of it
//        elem.html(str);
//    } else {
//        elem.html(str);
//    }
//})

/*Custom Scroll bar js*/
$(document).ready(function () {
    
    $(window).load(function () {
        $(".demo").customScrollbar();
        $("#fixed-thumb-size-demo").customScrollbar({ fixedThumbHeight: 50, fixedThumbWidth: 60 });
    });

    $(".ico-cart").on("mouseenter", function () {
        $(".demo").customScrollbar()
    })
})

/* fixing body_container height*/
var headerHeight = $(".header-menu").height();
$(".body_container").css("margin-top", headerHeight)

//scroll to top
$(window).scroll(function () {
    if ($(this).scrollTop() > 300) {
        $('.scrollup').fadeIn();
    } else {
        $('.scrollup').fadeOut();
    }
});
$('.scrollup').click(function () {
    $("html, body").animate({ scrollTop: 0 }, 1000);
    return false;
});

wow = new WOW().init();