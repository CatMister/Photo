function UpdateGoodDynainic() {
   
    $.ajax({
        type: "POST",
        url: "/Community/UpdateGoodDynainic",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ 'Id': 1, 'IsGood': true }),
        success: function (jsonResult) {

        }
    });
}