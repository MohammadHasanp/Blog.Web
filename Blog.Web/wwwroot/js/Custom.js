$(document).ready(function () {
    LoadCkEditor4();
    $.ajax({

        url: "/index/PopularPost",
        type: "get"
    }).done(function (data) {
        $("#Popular_post").html(data);
    });
});


function LoadCkEditor4() {

    if (!document.getElementById("ckeditor4"))
        return;

    $("body").append("<script src='/ckeditor4/ckeditor/ckeditor.js'></script>");

    CKEDITOR.replace('ckeditor4',
        {
            customConfig: '/ckeditor4/ckeditor/config.js'
        });
}
function ChangePage(pageid) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;
    search_params.set('PageID', pageid);
    url.search = search_params.toString();
    var new_url = url.toString();

    window.location.replace(new_url);
}