$(function () {
    $('td').click(function (e) {
        var t = e.target || e.srcElement;
        var elm_name = t.tagName.toLowerCase();
        if (elm_name == 'input') { return false; }
        var val = $(this).html();
        var code = '<input type="text" id="edit" value="" class="opInput"/>';
        $(this).empty().append(code);
        $('#edit').focus();
        $('#edit').blur(function () {
            var val = $(this).val();
            $(this).parent().empty().html(val);
        })
       
    });
});

$(window).keydown(function () {
    if (event.keyCode == 13) {
        $('#edit').blur();
    }
});