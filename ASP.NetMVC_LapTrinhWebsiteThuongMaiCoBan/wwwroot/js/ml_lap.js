// Lấy các checkbox bằng id
var tatca = document.getElementById("checkbox_lap_tatca");
var Asus = document.getElementById("checkbox-lap_asus");
var Lenovo = document.getElementById("checkbox-lap_Lenovo");
var Gigabyte = document.getElementById("checkbox-lap_gigabyte");
var Acer = document.getElementById("checkbox-lap_Acer");
var Surface = document.getElementById("checkbox-lap_surface");
var Macbook = document.getElementById("checkbox-lap_mac");
var HP = document.getElementById("checkbox-lap_hp");
var MSI = document.getElementById("checkbox-lap_msi");
var Dell = document.getElementById("checkbox-lap_Dell");
var Masstel = document.getElementById("checkbox-lap_masstel");
var Chuwi = document.getElementById("checkbox-lap_chuwi");

var lap_giaban_tatca = document.getElementById("checkbox_lap_tatcagia");
var lap_gia1 = document.getElementById("checkbox-lap_gia1");
var lap_gia2 = document.getElementById("checkbox-lap_gia2");
var lap_gia3 = document.getElementById("checkbox-lap_gia3");
var lap_gia4 = document.getElementById("checkbox-lap_gia4");
var lap_gia5 = document.getElementById("checkbox-lap_gia5");

function lap_giaban() {
    if (!lap_gia1.checked && !lap_gia2.checked && !lap_gia3.checked && !lap_gia4.checked && !lap_gia5.checked) {
        lap_giaban_tatca.checked = true;
    }
}

function lap_hangsanxuat() {
    if (!Asus.checked && !Lenovo.checked && !Gigabyte.checked && !Acer.checked && !Surface.checked && !Macbook.checked && !HP.checked && !MSI.checked && !Dell.checked && !Masstel.checked && !Chuwi.checked) {
        tatca.checked = true;
    }
}

function lap_hangsanxuat_check() {
    if (Asus.checked && Lenovo.checked && Gigabyte.checked && Acer.checked && Surface.checked && Macbook.checked && HP.checked && MSI.checked && Dell.checked && Masstel.checked && Chuwi.checked) {
        tatca.checked = true;
        Asus.checked = false;
        Lenovo.checked = false;
        Gigabyte.checked = false;
        Acer.checked = false;
        Surface.checked = false;
        Macbook.checked = false;
        HP.checked = false;
        MSI.checked = false;
        Dell.checked = false;
        Masstel.checked = false;
        Chuwi.checked = false;
    }
}

// Xử lý sự kiện khi người dùng chọn checkbox "Tất cả"
tatca.addEventListener("click", function () {
    if (tatca.checked) {
        Asus.checked = false;
        Lenovo.checked = false;
        Gigabyte.checked = false;
        Acer.checked = false;
        Surface.checked = false;
        Macbook.checked = false;
        HP.checked = false;
        MSI.checked = false;
        Dell.checked = false;
        Masstel.checked = false;
        Chuwi.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
});

// Xử lý sự kiện khi người dùng chọn các checkbox khác ngoại trừ "Tất cả"
Asus.addEventListener("click", function () {
    if (Asus.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Lenovo.addEventListener("click", function () {
    if (Lenovo.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Gigabyte.addEventListener("click", function () {
    if (Gigabyte.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Acer.addEventListener("click", function () {
    if (Acer.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Surface.addEventListener("click", function () {
    if (Surface.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Macbook.addEventListener("click", function () {
    if (Macbook.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

HP.addEventListener("click", function () {
    if (HP.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

MSI.addEventListener("click", function () {
    if (MSI.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Dell.addEventListener("click", function () {
    if (Dell.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
})

Masstel.addEventListener("click", function () {
    if (Masstel.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

Chuwi.addEventListener("click", function () {
    if (Chuwi.checked) {
        tatca.checked = false;
    }
    lap_hangsanxuat();
    lap_hangsanxuat_check();
})

// Xử lý sự kiện khi người dùng chọn checkbox "Tất cả"
lap_giaban_tatca.addEventListener("click", function () {
    if (lap_giaban_tatca.checked) {
        lap_gia1.checked = false;
        lap_gia2.checked = false;
        lap_gia3.checked = false;
        lap_gia4.checked = false;
        lap_gia5.checked = false;
    }
    lap_giaban();
})

// Xử lý sự kiện khi người dùng chọn các checkbox khác ngoại trừ "Tất cả"
lap_gia1.addEventListener("click", function () {
    if (lap_gia1.checked) {
        lap_giaban_tatca.checked = false;
        lap_gia2.checked = false;
        lap_gia3.checked = false;
        lap_gia4.checked = false;
        lap_gia5.checked = false;
    }
    lap_giaban();
})

lap_gia2.addEventListener("click", function () {
    if (lap_gia2.checked) {
        lap_giaban_tatca.checked = false;
        lap_gia1.checked = false;
        lap_gia3.checked = false;
        lap_gia4.checked = false;
        lap_gia5.checked = false;
    }
    lap_giaban();
})

lap_gia3.addEventListener("click", function () {
    if (lap_gia3.checked) {
        lap_giaban_tatca.checked = false;
        lap_gia1.checked = false;
        lap_gia2.checked = false;
        lap_gia4.checked = false;
        lap_gia5.checked = false;
    }
    lap_giaban();
})

lap_gia4.addEventListener("click", function () {
    if (lap_gia4.checked) {
        lap_giaban_tatca.checked = false;
        lap_gia1.checked = false;
        lap_gia2.checked = false;
        lap_gia3.checked = false;
        lap_gia5.checked = false;
    }
    lap_giaban();
})

lap_gia5.addEventListener("click", function () {
    if (lap_gia5.checked) {
        lap_giaban_tatca.checked = false;
        lap_gia1.checked = false;
        lap_gia2.checked = false;
        lap_gia3.checked = false;
        lap_gia4.checked = false;
    }
    lap_giaban();
})
