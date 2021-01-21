function Onsuccess(obj) {
    $('#row_' + obj).remove();

}
function DeleteFail() {
    alert("Xóa thất bại ! Ngành hiện tại đang có sinh viên !");
}
var id_nganh = "";
var active = "";
function editNganh(obj) {


    $('#icon_edit_' + obj).attr("src", "/Content/Admin/img/icon_accept.png");
    $('#icon_edit_' + obj).attr("onclick", "save(" + obj + ")");
    $('#icon_edit_' + obj).attr("id", "icon_accept_" + obj);
    var tennganh = $('#tennganh_' + obj).html();

    $('#tennganh_' + obj).html("")
    $('#tennganh_' + obj).append("<input type='text' value='" + tennganh + "'/>");
    var searchInput = $('#tennganh_' + obj).closest('tr').find("input");


    var strLength = searchInput.val().length * 2;

    searchInput.focus();
    searchInput[0].setSelectionRange(strLength, strLength);

}

function save(obj) {

    var confirmChange = confirm("Bạn có muốn thay đổi không?");
    if (confirmChange == true) {
        $('#tennganh_' + obj).closest('tr').find("input").each(function () {
            var tennganh = (this.value);
            var id_nganh = obj;
            $.ajax({
                url: "UpdateChuyenNganh",
                data: { id_chuyennganh: id_nganh, tenchuyennganh: tennganh },
                type: "POST",
            });

            $('#tennganh_' + obj).html(tennganh);
        });
        $('#icon_accept_' + obj).attr("src", "/Content/Admin/img/icon_edit.png");
        $('#icon_accept_' + obj).attr("onclick", "editNganh(" + obj + ")");
        $('#icon_accept_' + obj).attr("id", "icon_edit_" + obj);


    }


}




//Modal thêm mới chuyên ngành

// Get the modal
var modal = document.getElementById("myModal");
// Get the button that opens the modal
var btn = document.getElementById("myBtnChuyenNganh");
function addChuyenNganh() {    
    $('#themmoi').prop('disabled', true);
    btn.click()
}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];


if (btn != null) {
    btn.onclick = function () {       
        modal.style.display = "block";
    }
}


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

    
});