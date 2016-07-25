$(document).ready(function () {
    $("#query").change(function () {
        Id = $("#Id").val();
        q = $("#query").val();
        $.ajax({
            url: "/Cube/EnterQuery",
            type: "POST",
            data:{query:q,matrixId:Id},
            dataType: "json",
            success: function (d) {
                $("#output").val(d);
            }
        });
    });
});