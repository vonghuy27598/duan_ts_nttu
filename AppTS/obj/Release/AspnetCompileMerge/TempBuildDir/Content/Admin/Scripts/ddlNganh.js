var ddl = {
    init: function () {

        ddl.khoiTaoSuKien();
    },
    //Dropdown list change
    //Đổ dữ liệu theo ngành


    khoiTaoSuKien: function () {
        $('#dropdownlist_chon').change(function () {
            var select = this.options[this.selectedIndex].value;
            if (select == "")
                location.reload();
            else {
                $.ajax({
                    url: "ChangeSinhVienTheoNganh",
                    data: { ID_NGANH: select },
                    datatype: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.status != null) {
                            $(".table-bordered").find("tr:gt(0)").remove();

                            var contentTable = "";

                            $.each(response.status, function () {
                                var row = "$('#row_" + this.ID_SANPHAM + "').remove()";
                                var gt;
                                if (this.GIOITINH)
                                    gt = "Nam";
                                else
                                    gt = "Nữ";
                                contentTable += '<tr id=row_' + this.ID_HS + '><td>' + this.ID_HS + '</td> <td>' + this.HOHS + '</td> <td>' + this.TENHS + '</td> <td>' + gt + '</td> <td>' + formattedDateFromJson(this.NGAYSINH) + '</td><td>' + this.SDT + '</td><td>' + this.EMAIL + '</td><td>' + this.DIACHI + '</td><td >' + this.TENCHUYENNGANH + '</td><td width="4%"><img src="/Content/Admin/img/icon_view.png" width="90%" onclick="clickView(' + this.ID_HS + ')" /></td></tr>'
                            });

                            $('.table_change').append(contentTable);
                        }

                    }

                });
            }

            function formattedDateFromJson(jsonDate) {
                var d = new Date(parseInt(jsonDate.substr(6)));
                return ("0" + d.getDate()).slice(-2) + '/' + ("0" + (d.getMonth() + 1)).slice(-2) + '/' + d.getFullYear();
            }
        });
    }
}
ddl.init();





