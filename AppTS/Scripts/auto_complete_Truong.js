var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#truong").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "ListNameTruong",
                    dataType: "json",
                    data: {
                        a: request.term
                    },
                    success: function (res) {
                        response(res.data.slice(0, 10));
                        
                    }
                });
            }, focus: function (event, ui) {
                event.preventDefault();
                
                $(this).val(ui.item.label);
               
                return false;
            },
            select: function (event, ui) {
                event.preventDefault();
                $("#truong").val(ui.item.label);

                return false;
            }
           
        })
    .autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
          .append("<div>" + item.label + "</div>")
          .appendTo(ul);
    };
    }
}

common.init();
