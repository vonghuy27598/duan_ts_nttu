var card = document.querySelector('.card');
var clickchagne = document.querySelector('.to-after-form');

clickchagne.addEventListener('click', function () {
    var ho = document.getElementById('ho').value;
    var ten = document.getElementById('ten').value;
    var sdt = document.getElementById('sdt').value;
    var email = document.getElementById('email').value;
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (ho == "" || ho == null) {
        alert('Họ sinh viên không được rỗng');
    } else if (ten == '') {
        alert('Tên sinh viên không được rỗng');
    } else if (sdt == '') {
        alert('Số điện thoại không được rỗng');
    } else if (sdt.match('[a-z]') || sdt.match('[A-Z]')) {
        alert('Số điện thoại không hợp lệ');
    } else if (sdt.length < 10) {
        alert('Số điện thoại phải đủ 10 số');
    }
    else if (email == '') {
        alert('Email không được rỗng');
    } else if (!re.test(email)) {
        alert('Email không hợp lệ');
    }
    else {
        card.classList.toggle('is-flipped');
    }


});
var clickBack = document.querySelector(".to-before-form");
clickBack.addEventListener('click', function () {
    card.classList.remove('is-flipped');
});