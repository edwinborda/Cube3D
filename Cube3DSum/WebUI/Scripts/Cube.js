$(document).ready(function () {
    $("#query").change(function () {
        var pieces = jQuery("textarea#query").val().split('\n');
        if (pieces.length > $("#NumOperaciones").val())
        {
            alert("You've exceeded the number of the operations ");
            return false;
        }
        Id = $("#Id").val();
        q = pieces[pieces.length-1];
        if (!validatequery(q)) {
            alert('Incorrect syntax, please write the following structure "UPDATE x y z w  or  QUERY x1 y1 z1 x2 y2 z2 " ');
            return false;
        }
        $.ajax({
            url: "/Cube/EnterQuery",
            type: "POST",
            data:{query:q,matrixId:Id},
            dataType: "json",
            success: function (d) {
                if(d > -1)
                    jQuery("textarea#output").append(d);
            }
        });
    });
    $("#TamMatriz").change(function () {
        len = $(this).val();
        $.ajax({
            url: "/Cube/GetMatrix",
            type: "POST",
            data: { length: len },
            dataType: "json",
            success: function (d) {
                $("#Id").val(d.Id);
                $("#NumOperaciones").val(d.NumOperaciones+"\n");
            }
        });

    });
});

function validatequery(query)
{
    var result=false;
    var reU = /^UPDATE\s?\d{1}\s?\d{1}\s?\d{1}\s?\d{2}$/;
    var reQ = /^QUERY\s?\d{1}\s?\d{1}\s?\d{1}\s?\d{1}\s?\d{1}\s?\d{1}$/;
    if(reU.test(query))
        result=true;
    else if(reQ.test(query))
        result=true
    return result;
}