// Get the modal
var modal = document.getElementById("myModal");
// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var id_gv = "";
function clickView(obj) {
    id_gv = obj;
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
            url: "ChiTietGVDoanhNghiep",
            data: { ID_GV: id_gv },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.status != null) {
                    $.each(response.status, function () {
                        $('#HOGV').val(response.status.HOGV)
                        $('#TENGV').val(response.status.TENGV)
                        if (response.status.GIOITINH) {
                            $('#rNam').prop('checked', true);
                        } else {
                            $('#rNu').prop('checked', true);
                        }

                        function formattedDateFromJson(jsonDate) {
                            var d = new Date(parseInt(jsonDate.substr(6)));
                            return d.getFullYear() + '-' + ("0" + (d.getMonth() + 1)).slice(-2) + '-' + ("0" + d.getDate()).slice(-2);
                        }


                        $('#NGAYSINH').val(formattedDateFromJson(response.status.NGAYSINH));
                        $('#SDT').val(response.status.SDT);
                        $('#EMAIL').val(response.status.EMAIL);
                        $('#HOCVI').val(response.status.HOCVI);
                        $('#DIACHI').val(response.status.DIACHI);
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
    var confirmXoa = confirm("Bạn có muốn xóa giảng viên này không?");
    if (confirmXoa) {
        var confirmXoa2 = confirm("Lưu ý dữ liệu sẽ bị xóa khỏi hệ thống vĩnh viễn! Xin vui lòng cân nhắc trước khi xóa !");
        if (confirmXoa2) {
            $.ajax({
                url: 'deleteGV',
                data: { ID_GV: id_gv },
                datatype: "json",
                type: 'POST',
                success: function (result) {
                    modal.style.display = "none";
                    $('#row_' + id_gv).remove();
                }
            });
        }


    }

}




// When the user clicks on <span> (x), close the modal
span.onclick = function () {

    modal.style.display = "none";

    modaladd.style.display = "none";
}

var span2 = document.getElementsByClassName("close")[1];
span2.onclick = function () {



    modaladd.style.display = "none";
}

window.onclick = function (event) {
    if (modal != null) {
        if (modal.style.display == "block") {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        } else if (modaladd.style.display == "block") {
            if (event.target == modaladd) {
                modaladd.style.display = "none";
            }
        }
    } else {
        if (modaladd.style.display == "block") {
            if (event.target == modaladd) {
                modaladd.style.display = "none";
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

    if ($('#ngaysinh').val() == "") {
        $('#capnhat').prop('disabled', true);
    }
    $('.checkGioiTinh').change(function () {
        $('#capnhat').prop('disabled', false);
    });
});


//Modal thêm giảng viên

var modaladd = document.getElementById("myModalAddGiangVien");
// Get the button that opens the modal
var btnadd = document.getElementById("myBtnAddGiangVien");
function addGiangVienKhoa() {
    $('#themmoi').prop('disabled', true);
    btnadd.click()
}

if (btnadd != null) {


    btnadd.onclick = function () {
        modaladd.style.display = "block";

    }
}

$(document).ready(function () {
    $('#themmoi').prop('disabled', true);

    $(':input').keyup(function () {
        if ($(this).val() != '') {
            $('#themmoi').prop('disabled', false);
        } else {
            $('#themmoi').prop('disabled', true);
        }
    });
    $(':input').change(function () {
        if ($(this).val() != '') {
            $('#themmoi').prop('disabled', false);
        } else {
            $('#themmoi').prop('disabled', true);
        }
    });

    if ($('#ngaysinh').val() == "") {
        $('#themmoi').prop('disabled', true);
    }
    $('.checkGioiTinh').change(function () {
        $('#themmoi').prop('disabled', false);
    });
});