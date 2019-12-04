$(document).ready(function () {
    //alert('ok');
});
var Hotel =
{
    SearchHotel: function () {
        if ($("#ddlDestination :selected").val() != 0 && $("#txtNoOfNights").val() != "") {
            
            $("#btnSearch").val("Searching..");
            $("#btnSearch").attr("disabled", true);

            if (!isNaN($("#txtNoOfNights").val())) {
                if ($("#txtNoOfNights").val() > 0) {
                    if ($("#txtNoOfNights").val().length <= 8) {
                        var Html = "<tr><th>Hotel Name</th><th>Board Type</th><th> Rate Type </th> <th> Rate </th></tr>";
                        $.ajax({
                            url: FetchHotelUrl,
                            data: { destinationId: $("#ddlDestination :selected").val(), nights: $("#txtNoOfNights").val() },
                            method: "GET",
                            success: function (data) {
                                $("#btnSearch").val("Search Hotel");
                                $("#btnSearch").removeAttr("disabled");
                                if (data.length > 0) {
                                    for (var i = 0; i < data.length; i++) {

                                        for (var j = 0; j < data[i].boardType.length; j++) {
                                            Html += "<tr>";
                                            Html += "<td>" + data[i].hotelName + "</td>";
                                            Html += "<td>" + data[i].boardType[j] + "</td>";
                                            Html += "<td>" + data[i].rateType[j] + "</td>";
                                            Html += "<td>" + data[i].rate[j] + "</td>";
                                            Html += "</tr>";

                                        }
                                    }
                                    $("#tblHotelData").html(Html);
                                }
                                else {
                                    Html += "<tr><td colspan=3 align='center'>No Record Found</td></tr>";
                                    $("#tblHotelData").html(Html);
                                }
                            },
                            error: function (jqXHR, exception) {
                                $("#btnSearch").val("Search Hotel");
                                $("#btnSearch").removeAttr("disabled");
                            },

                        });
                    }
                    else {
                        alert('max length exceeded for no of nights');
                        $("#btnSearch").val("Search Hotel");
                        $("#btnSearch").removeAttr("disabled");
                    }
                }
                else {
                   
                    alert('please give a numeric input greater than 0');
                    $("#btnSearch").val("Search Hotel");
                    $("#btnSearch").removeAttr("disabled");
                }
            }
            else {
                alert('please give a numeric input');
                $("#btnSearch").val("Search Hotel");
                $("#btnSearch").removeAttr("disabled");
            }
        }
        else {
            alert('please provide all data');
        }
    }
}