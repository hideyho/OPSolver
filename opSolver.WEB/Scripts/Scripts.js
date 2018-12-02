document.body.onload = function () {
    setTimeout(function () {
        var preloader = document.getElementById('page-preloader');
        if (!preloader.classList.contains('preloader-done')) {
            preloader.classList.add('preloader-done');
        }
    }, 500);
}
$('a[href^="#"]').click(function () {
    var margin = -100;
    var target = $(this).attr('href');
    $('html, body').animate({ scrollTop: $(target).offset().top }, 800);
    return false;
});

var scrolled;
if ($('header').is('#index')) {
    window.onscroll = function () {
        scrolled = window.pageYOffset || document.documentElement.scrollTop;
        if (scrolled > 200) {
            $("nav").addClass("whiteNav");
        }
        if (200 > scrolled) {
            $("nav").removeClass("whiteNav");
        }
    }
}
else {
    $("nav").addClass("whiteNav");
}