$("#signinCreate").click(function () {
    var sdt = $("#sdt").val();
    var matkhau = $("#matkhau").val();

    if (sdt.length <= 0) {
        alert("Vui lòng nhập số điện thoại ");
        $("#sdt").focus();

    }
    else if (matkhau.length <= 0) {
        alert("Vui lòng nhập mật khẩu ");
        $("#matkhau").focus();
    }
    else {
        $.ajax({
            url: "submit_DangNhap",
            data: { sdt: sdt, matkhau: matkhau },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.success == 1) {
                    $("#dong").click();
                    $("#dong").click();                  
                }
                else {
                    alert(response.message);
                   
                }
            }
        });
    }
});