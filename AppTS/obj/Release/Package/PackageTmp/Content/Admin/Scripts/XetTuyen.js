
$(document).ready(function () {
    $("#dropdownlist_chonkhoinganh option[value='']").attr('disabled', 'disabled')
    $("#dropdownlist_chonkhoinganh").change(function () {
        var id_khoinganh = this.value;
        $("#dropdownlist_chontennganh").empty();
        $("#dropdownlist_chontennganh").removeAttr("disabled");
        $("#dropdownlist_chontohop").empty();
        $("#dropdownlist_chontohop").removeAttr("disabled");
        $(".allownumericwithdecimal").removeAttr("disabled");
        getTenNganh(id_khoinganh);
           
            
    });
    $("#dropdownlist_chontennganh").change(function () {
        var id_chuyennganh = this.value;

        $("#dropdownlist_chontohop").empty();
        $("#dropdownlist_chontohop").removeAttr("disabled");
        getToHop(id_chuyennganh);
            

    });
    $("#dropdownlist_chontohop").on("change",function () {
        var to_hop = this.value;
        getMonTheoToHop(to_hop);
           
    });

});
   
function getTenNganh(id_khoinganh) {
    $.ajax({
        url: "getTenNganh",
        data: { id_khoinganh: id_khoinganh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {

                   
                $.each(response.status, function () {
                    var ten_nganh = this.TENCHUYENNGANH;
                    var id_chuyennganh = this.ID_CHUYENNGANH
                    var ma_nganh = this.MANGANH;

                    if ($("#dropdownlist_chontennganh option").length <= 0) {
                        var to_hop = this.TOHOP;
                        var array_tohop = to_hop.split(',');
                        $.each(array_tohop, function (index, item) {
                            $("#dropdownlist_chontohop").append("<option value='" + item + "'>" + item + "</option>");

                        })
                    }
                    $("#dropdownlist_chontennganh").append("<option value='" + id_chuyennganh + "'>" + ten_nganh + " - " + ma_nganh + "</option>");
                    if ($("#dropdownlist_chontohop").val() != null || $("#dropdownlist_chontohop").val() != "")
                    {
                        getMonTheoToHop($("#dropdownlist_chontohop").val());
                    }
                });

            }
        }
    });
}
function getToHop(id_chuyennganh) {
    $.ajax({
        url: "getToHop",
        data: { id_chuyennganh: id_chuyennganh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                $.each(response.status, function () {
                    var to_hop = this.TOHOP;
                    var array_tohop = to_hop.split(',');
                    $.each(array_tohop, function (index, item) {
                        $("#dropdownlist_chontohop").append("<option value='"+item+"'>" + item + "</option>");

                    })
                });
                if ($("#dropdownlist_chontohop").val() != null || $("#dropdownlist_chontohop").val() != "") {
                    getMonTheoToHop($("#dropdownlist_chontohop").val());
                }
            }
        }
    });
}
function getMonTheoToHop(to_hop)
{
    var tentohop = to_hop.trim();
    $.ajax({
        url: "getMon_ToHop",
        data: { to_hop: tentohop },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                $.each(response.status, function () {
                    $("#th_1").text(this.MON1);
                    $("#th_2").text(this.MON2);
                    $("#th_3").text(this.MON3);
                })
                       
            }
        }
    });
}
    
$("#admission").click(function()
{
    var hoten = $("#hoten").val();
    var truong = $("#truong").val();
    var diachi = $("#diachi").val();
    var sdt = $("#sdt").val();
    var email = $("#email").val();
    var diemmon_1 =$("#mon1").val();
    var diemmon_2 = $("#mon2").val();
    var diemmon_3 = $("#mon3").val();
    var tenmon_1 = $("#th_1").text();
    var tenmon_2 = $("#th_2").text();
    var tenmon_3 = $("#th_3").text();
    if(hoten.length<=0)
    {
        alert("Vui lòng nhập họ tên ");
        $("#hoten").focus();
       
    }
    else if(diachi.length<=0)
    {
        alert("Vui lòng nhập địa chỉ ");
        $("#diachi").focus();
       

    }
    else if (truong.length <= 0) {
        alert("Vui lòng nhập tên trường cấp 3 ");
        $("#truong").focus();
       

    }
    else if (sdt.length == 0) {
        alert("Vui lòng nhập số điện thoại ");
        $("#sdt").focus();
        
    }
    else if (sdt.length <10){
        alert("Số điện thoại vui lòng nhập đủ 10 số ");
        $("#sdt").focus();
      
    }
    else if(email.length <=0)
    {
        alert("Vui lòng nhập địa chỉ email ");
        $("#email").focus();
        
    }
    else if(!IsEmail(email))
    {
        alert("Email chưa đúng định dạng");
        $("#email").focus();
        
    }
    else if($("#dropdownlist_chonkhoinganh").val() == null)
    {
                
        alert("Vui lòng chọn khối ngành ");
    }
    else if(diemmon_1.length <= 0)
    {
        alert("Vui lòng nhập điểm môn " + tenmon_1);
        $("#mon1").focus();
       
    }
    else if(diemmon_2.length <= 0)
    {
        alert("Vui lòng nhập điểm môn " + tenmon_2);
        $("#mon2").focus();       
    }
    else if (diemmon_3.length <= 0)
    {
        alert("Vui lòng nhập điểm môn " + tenmon_3);
        $("#mon3").focus();      
    } else {          
        if (diemmon_1 < 0 || diemmon_1 > 10)
        {
            alert("Điểm môn " + tenmon_1 + " phải từ 0 đến 10");
            $("#mon1").focus();
        }   
        else if(diemmon_2 < 0 || diemmon_2 > 10)
        {
            alert("Điểm môn " + tenmon_2 + " phải từ 0 đến 10");
            $("#mon2").focus();
        }          
        else if (diemmon_3 < 0 || diemmon_3 > 10)
        {
            alert("Điểm môn " + tenmon_3 + " phải từ 0 đến 10");
            $("#mon3").focus();
        }           
        else {
            var tongdiem = parseFloat(diemmon_1) + parseFloat(diemmon_2) + parseFloat(diemmon_3);

            $.ajax({
                url: "submit_XetTuyen",
                data: { tongdiem: tongdiem,mon1:parseFloat(diemmon_1),mon2:parseFloat(diemmon_2),mon3:parseFloat(diemmon_3),hoten:hoten,diachi:diachi,truong:truong,sdt:sdt,email:email },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    
                }
            });
            if(tongdiem >= 18)
            {
                Swal.fire({
                    title: 'Thông báo.',
                    text:'Bạn đã trúng tuyển vào Trường Đại học Nguyễn Tất Thành với số điểm: '+tongdiem +'. Ngành học: '+$("#dropdownlist_chontennganh option:selected").text()+'',
                           
                    width: 600,
                    padding: '3em',                            
                    confirmButtonText: 'Tiếp tục',
                              
  
                }).then((result) => {
                    Swal.fire({
                        text:'Trường Đại học Nguyễn Tất Thành sẽ liên hệ bạn để hướng dãn làm thủ tục nhập học.',
                        width: 600,
                        padding: '3em',                            
                        confirmButtonText: 'Đồng ý',

                    }).then((result) => {
                        if (result.isConfirmed) {
                                location.reload();
            }
        })
                       
                });
                       
} else {
                    Swal.fire({
                    text:'Rất tiếc! Bạn không đạt yêu cầu.',
                    width: 600,
                    padding: '3em',                            
                    confirmButtonText: 'Đồng ý',

                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                    }
                    })
}
               
}
}
})

function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if(!regex.test(email)) {
        return false;
    }else{
        return true;
    }
}       