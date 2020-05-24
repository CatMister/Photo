
function Sorting() {
    var margin = 10;
    var div = $(".white-panel");
    var div_W = div[0].offsetWidth + margin;
    var h = [];
    var n = 4;
    for (var i = 0; i < div.length; i++) {
        div_H = div[i].offsetHeight;
        if (i < n) {
            h[i] = div_H;
            div.eq(i).css("top", 0);
            div.eq(i).css("left", i * div_W);
        } else {
            min_H = Math.min.apply(null, h);
            minKey = getarraykey(h, min_H);
            h[minKey] += div_H + margin;
            div.eq(i).css("top", min_H + margin);
            div.eq(i).css("left", minKey * div_W);
        }
    }
};

function getarraykey(s, v) {
    for (k in s) {
        if (s[k] == v) {
            return k;
        }
    }
};
window.onload = function () {
    Sorting();
};
window.onresize = function () {
    Sorting();
};


$("#Buttons").bind("click", function () {
    //$.ajax({
    //    url: "/Tools/DownloadFile",
    //    type: "post",
    //    success: function () {
    //    }
    //});
    window.location.href = "/Tools/DownloadFile";
});


function UpdatePhoto() {
    //console.log($(this).Uid);
    $.ajax({
        type: "POST",
        url: "/Community/UpdateGoodPhoto",
        contentType: "application/json",
        dataType: "json", 
        data: JSON.stringify({ 'Id': 1, 'IsGood': true }),
        success: function (jsonResult) {
           
        }
    });
}