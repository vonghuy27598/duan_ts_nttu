
function getBotResponse() {
	var rawText = $("input:text").val().trim();
	var userHtml = '<p class="text-right"><img src="/Content/static/messenger.png" height="31" width="27">&nbsp;&nbsp;<span class="bg-success text-white rounded p-1" style="">' + rawText + '</span></p>';
	 
	$("input:text").val("");
	$("#chatbox").append(userHtml);
	document.getElementById('formInput').scrollIntoView({
		block : 'start',
		behavior : 'smooth'
	});
	$.get("/get", {
		msg : rawText
	}).done(function(data) {
	    var botHtml = '<p class="text-left"><img src="/Content/static/chatbot.jpg" height="31" width="27">&nbsp;&nbsp;<span class="bg-info text-white rounded p-1" style=" ">' + data + '</span></p>';
		$("#chatbox").append(botHtml);
		document.getElementById('formInput').scrollIntoView({
			block : 'start',
			behavior : 'smooth'
		});
	});
}
    

$(document).ready(function () {
   
    $("input:submit").click(function () {
        if ($("input:text").val().trim() != "") {
            getBotResponse();
            $("#chatbox").append('<p class="text-left"><img src="/Content/static/chatbot.jpg" height="31" width="27">&nbsp;&nbsp;<span class="bg-info text-white rounded p-1" style=" ">Trường Đại Học Nguyễn Tất Thành</span></p>');
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;           
        }
        $("input:text").focus();
    });
    $("input:text").keypress(function (e) {
        if (e.which == 13 && $("input:text").val().trim() != "") {
            getBotResponse();
            $("#chatbox").append('<p class="text-left"><img src="/Content/static/chatbot.jpg" height="31" width="27">&nbsp;&nbsp;<span class="bg-info text-white rounded p-1" style=" ">Trường Đại Học Nguyễn Tất Thành</span></p>');
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;
        }
    });
    $("input:text").click(function (e) {
       
            
            var elem = document.getElementById('chatbox');
            elem.scrollTop = elem.scrollHeight;
        
    });
});




    


