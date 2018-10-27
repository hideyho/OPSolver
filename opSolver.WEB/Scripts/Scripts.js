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

$('#page_btn').click(function () {
    $('a#page_btn').addClass("active");
});

new fullpage('#fullpage', {
    navigation: true,
    responsiveWidth: 700,
    anchors: ['home', 'about-us', 'contact'],
    parallax: true,
    onLeave: function (origin, destination, direction) {
        console.log("leaving section" + origin.index);
    },
})
