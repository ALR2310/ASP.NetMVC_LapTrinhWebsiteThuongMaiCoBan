// Lấy các checkbox bằng id
var tat_ca_checkbox = document.getElementById("checkbox_tatcagia");
var checkbox_gia1 = document.getElementById("checkbox-gia1");
var checkbox_gia2 = document.getElementById("checkbox-gia2");
var checkbox_gia3 = document.getElementById("checkbox-gia3");
var checkbox_gia4 = document.getElementById("checkbox-gia4");
var checkbox_gia5 = document.getElementById("checkbox-gia5");

// Lấy các checkbox bằng id
var dt_tatca = document.getElementById("checkbox_tatca");
var samsung = document.getElementById("checkbox_samsung");
var xiaomi = document.getElementById("checkbox-Xiaomi");
var vivo = document.getElementById("checkbox-Vivo");
var dt_masstel = document.getElementById("checkbox-Masstel");
var iphone = document.getElementById("checkbox-Iphone");
var oppo = document.getElementById("checkbox-OPPO");
var realme = document.getElementById("checkbox-Realme");
var dt_asus = document.getElementById("checkbox-Asus");
var nokia = document.getElementById("checkbox-Nokia");

function dienthoai_giaban() {
    if (!checkbox_gia1.checked && !checkbox_gia2.checked && !checkbox_gia3.checked && !checkbox_gia4.checked && !checkbox_gia5.checked) {
        tat_ca_checkbox.checked = true;
    }
}

function dt_hangsanxuat() {
    if (!samsung.checked && !xiaomi.checked && !vivo.checked && !dt_masstel.checked && !iphone.checked && !oppo.checked && !realme.checked && !dt_asus.checked && !nokia.checked) {
        dt_tatca.checked = true;
    }
}

function dt_hangsanxuat_check() {
    if (samsung.checked && xiaomi.checked && vivo.checked && dt_masstel.checked && iphone.checked && oppo.checked && realme.checked && dt_asus.checked && nokia.checked) {
        dt_tatca.checked = true;
        samsung.checked = false;
        xiaomi.checked = false;
        vivo.checked = false;
        dt_masstel.checked = false;
        iphone.checked = false;
        oppo.checked = false;
        realme.checked = false;
        dt_asus.checked = false;
        nokia.checked = false;
    }
}


// Xử lý sự kiện khi người dùng chọn checkbox "Tất cả"
tat_ca_checkbox.addEventListener("click", function () {
    if (tat_ca_checkbox.checked) {
        checkbox_gia1.checked = false;
        checkbox_gia2.checked = false;
        checkbox_gia3.checked = false;
        checkbox_gia4.checked = false;
        checkbox_gia5.checked = false;
    }
});

// Xử lý sự kiện khi người dùng chọn các checkbox khác ngoại trừ "Tất cả"
checkbox_gia1.addEventListener("click", function () {
    if (checkbox_gia1.checked) {
        tat_ca_checkbox.checked = false;
        checkbox_gia2.checked = false;
        checkbox_gia3.checked = false;
        checkbox_gia4.checked = false;
        checkbox_gia5.checked = false;
    }
    dienthoai_giaban();
});

checkbox_gia2.addEventListener("click", function () {
    if (checkbox_gia2.checked) {
        tat_ca_checkbox.checked = false;
        checkbox_gia1.checked = false;
        checkbox_gia3.checked = false;
        checkbox_gia4.checked = false;
        checkbox_gia5.checked = false;
    }
    dienthoai_giaban();
});

checkbox_gia3.addEventListener("click", function () {
    if (checkbox_gia3.checked) {
        tat_ca_checkbox.checked = false;
        checkbox_gia1.checked = false;
        checkbox_gia2.checked = false;
        checkbox_gia4.checked = false;
        checkbox_gia5.checked = false;
    }
    dienthoai_giaban();
});

checkbox_gia4.addEventListener("click", function () {
    if (checkbox_gia4.checked) {
        tat_ca_checkbox.checked = false;
        checkbox_gia1.checked = false;
        checkbox_gia2.checked = false;
        checkbox_gia3.checked = false;
        checkbox_gia5.checked = false;
    }
    dienthoai_giaban();
});

checkbox_gia5.addEventListener("click", function () {
    if (checkbox_gia5.checked) {
        tat_ca_checkbox.checked = false;
        checkbox_gia1.checked = false;
        checkbox_gia2.checked = false;
        checkbox_gia3.checked = false;
        checkbox_gia4.checked = false;
    }
    dienthoai_giaban();
});

// Xử lý sự kiện khi người dùng chọn checkbox "Tất cả"
dt_tatca.addEventListener("click", function () {
    if (dt_tatca.checked) {
        samsung.checked = false;
        xiaomi.checked = false;
        vivo.checked = false;
        dt_masstel.checked = false;
        iphone.checked = false;
        oppo.checked = false;
        realme.checked = false;
        dt_asus.checked = false;
        nokia.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

// Xử lý sự kiện khi người dùng chọn các checkbox khác ngoại trừ "Tất cả"
samsung.addEventListener("click", function () {
    if (samsung.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

xiaomi.addEventListener("click", function () {
    if (xiaomi.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

vivo.addEventListener("click", function () {
    if (vivo.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

dt_masstel.addEventListener("click", function () {
    if (dt_masstel.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

iphone.addEventListener("click", function () {
    if (iphone.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

oppo.addEventListener("click", function () {
    if (oppo.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

realme.addEventListener("click", function () {
    if (realme.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

dt_asus.addEventListener("click", function () {
    if (dt_asus.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});

nokia.addEventListener("click", function () {
    if (nokia.checked) {
        dt_tatca.checked = false;
    }
    dt_hangsanxuat();
    dt_hangsanxuat_check();
});
