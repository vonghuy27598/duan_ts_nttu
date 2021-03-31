
function getBotResponse() {
	var rawText = $("input:text").val().trim();
	var userHtml = '<p class="text-right"><img src="/Content/static/messenger.png" height="31" width="27">&nbsp;&nbsp;<span class="bg-success text-white rounded p-1" style="">' + rawText + '</span></p>';
	 
	$("input:text").val("");
	$("#chatbox").append(userHtml);
	document.getElementById('formInput').scrollIntoView({
		block : 'start',
		behavior : 'smooth'
	});
	$.ajax({
	    url: "ChatBotResponse",
	    data: { text: rawText },
	    datatype: "json",
	    type: "POST",
	    success: function (response) {
	        if (response.status != null)
	        {
	            if (response.status != "0")
	            {
	                var botHtml = '<p class="text-left"><img src="/Content/static/chatbot.jpg" height="31" width="27">&nbsp;&nbsp;<span class="bg-info text-white rounded p-1" style=" ">' + response.status + '</span></p>';
	                $("#chatbox").append(botHtml);
	                document.getElementById('formInput').scrollIntoView({
	                    block: 'start',
	                    behavior: 'smooth'
	                });
	                var elem = document.getElementById('chatbox');
	                elem.scrollTop = elem.scrollHeight;
	            } else {
	                var botHtml = '<p class="text-left"><img src="/Content/static/chatbot.jpg" height="31" width="27">&nbsp;&nbsp;<span class="bg-info text-white rounded p-1" style=" ">Hiện câu trả lời chưa có trên hệ thống. Tư vấn viên sẽ trả lời cho bạn sau. Thành thật xin lỗi.</span></p>';
	                $("#chatbox").append(botHtml);
	                document.getElementById('formInput').scrollIntoView({
	                    block: 'start',
	                    behavior: 'smooth'
	                });
	                var elem = document.getElementById('chatbox');
	                elem.scrollTop = elem.scrollHeight;
	                $.ajax({
	                    url: "saveQuestion",
	                    data: { text: rawText },
	                    datatype: "json",
	                    type: "POST",
	                    success: function (kq) {
	                        
	                    }
	                });
	            }
	           
	        }       
	    }
	});
	
	
}
    

$(document).ready(function () {
   
    $("input:submit").click(function () {
        if ($("input:text").val().trim() != "") {
            getBotResponse();
            
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;           
        }
        $("input:text").focus();
    });
    $("input:text").keypress(function (e) {
        if (e.which == 13 && $("input:text").val().trim() != "") {
            getBotResponse();
           
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;
        }
    });
    $("input:text").click(function (e) {             
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;
        
    });
});




    


