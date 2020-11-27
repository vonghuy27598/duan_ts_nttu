// Get the modal
var modal = document.getElementById("myModal");
// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var id_sv = "";
function clickView(obj) {
    id_sv = obj;
    $('#capnhat').prop('disabled', true);
    if (btn != null) {
        btn.click()
    }
    
}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal
if (btn != null) {


    btn.onclick = function () {
        $.ajax({
            url: "ChiTietSV",
            data: { ID_SV: id_sv },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.status != null) {
                    $.each(response.status, function () {
                        $('#Ho').val(response.status.HOHS)
                        $('#Ten').val(response.status.TENHS)
                        if (response.status.GIOITINH) {
                            $('#rNam').prop('checked', true);
                        } else {
                            $('#rNu').prop('checked', true);
                        }

                        function formattedDateFromJson(jsonDate) {
                            var d = new Date(parseInt(jsonDate.substr(6)));
                            return d.getFullYear() + '-' + ("0" + (d.getMonth() + 1)).slice(-2) + '-' + ("0" + d.getDate()).slice(-2);
                        }


                        $('#ngaysinh').val(formattedDateFromJson(response.status.NGAYSINH));
                        $('#sdt').val(response.status.SDT);
                        $('#email').val(response.status.EMAIL);
                        //$('#nganh').val(response.status.TENNGANH);
                        $('#diachi').val(response.status.DIACHI);
                        $("#dropdownlist").val('' + response.status.ID_CHUYENNGANH + '');

                        //$('select>option:eq(' + response.status.ID_NGANH+ ')').attr('selected', true);
                    });
                }


            }

        });



        modal.style.display = "block";

    }
}

function xoaNV() {
    var confirmXoa = confirm("Bạn có muốn xóa sinh viên này không?");
    if (confirmXoa) {
        var confirmXoa2 = confirm("Lưu ý dữ liệu sẽ bị xóa khỏi hệ thống vĩnh viễn! Xin vui lòng cân nhắc trước khi xóa !");
        if (confirmXoa2) {
            $.ajax({
                url: 'deleteSV',
                data: { ID_SV: id_sv },
                datatype: "json",
                type: 'POST',
                success: function (result) {
                    modal.style.display = "none";
                    $('#row_' + id_sv).remove();
                }
            });
        }


    }

}




// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (modal != null) {
        if (modal.style.display == "block") {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }
}

$(document).ready(function () {
    $('#capnhat').prop('disabled', true);
    $('#btn_Change').prop('disabled', true);
    $(':input').keyup(function () {
        if ($(this).val() != '') {
            $('#capnhat').prop('disabled', false);
        } else {
            $('#capnhat').prop('disabled', true);
        }
    });
    $(':input').change(function () {
        if ($(this).val() != '') {
            $('#capnhat').prop('disabled', false);
        } else {
            $('#capnhat').prop('disabled', true);
        }
    });

    if ($('ngaysinh').val() == "") {
        $('#capnhat').prop('disabled', true);
    }
    $('.checkGioiTinh').change(function () {
        $('#capnhat').prop('disabled', false);
    });
});