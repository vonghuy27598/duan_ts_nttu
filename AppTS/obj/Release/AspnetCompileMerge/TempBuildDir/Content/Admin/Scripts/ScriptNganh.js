   
       function Onsuccess(obj) {
           $('#row_'+obj).remove();
           
       }
function DeleteFail() {
    alert("Xóa thất bại ! Ngành hiện tại đang có sinh viên !");
}
var id_nganh ="";
var active="";
function editNganh(obj){
           
          
    $('#tennganh_'+obj).addClass("active");
    if($('#tennganh_'+obj).hasClass("active")){
        $('#icon_edit_'+obj).attr("src","/Content/Admin/img/icon_accept.png");
        $('#icon_edit_'+obj).attr("onclick","save("+obj+")");
        $('#icon_edit_'+obj).attr("id","icon_accept_"+obj);             
        var tennganh = $('#tennganh_'+obj).html();
                 
        $('#tennganh_'+obj).html("")
        $('#tennganh_'+obj).append("<input type='text' value='"+tennganh+"'/>"); 
        var searchInput =  $('#tennganh_'+obj).closest('tr').find("input");

          
        var strLength = searchInput.val().length * 2;

        searchInput.focus();
        searchInput[0].setSelectionRange(strLength, strLength);
               
    }
           
}
                  
      
       
              
           
       
       
function save(obj){
    if($('#tennganh_'+obj).hasClass("active")){
        var confirmChange = confirm("Bạn có muốn thay đổi không?");
        if(confirmChange ==true)
        {
            $('#tennganh_'+obj).closest('tr').find("input").each(function(){
                var tennganh = (this.value);
                var id_nganh = obj;
                $.ajax({
                    url: "UpdateNganh",
                    data: { id_nganh: id_nganh,tennganh:tennganh },                              
                    type: "POST",                              
                });

                $('#tennganh_'+obj).html(tennganh);  
            });                        
            $('#icon_accept_'+obj).attr("src","/Content/Admin/img/icon_edit.png");
            $('#icon_accept_'+obj).attr("onclick","editNganh("+obj+")");
            $('#icon_accept_'+obj).attr("id","icon_edit_"+obj);
                        

        }          
    }
                   
}
       

