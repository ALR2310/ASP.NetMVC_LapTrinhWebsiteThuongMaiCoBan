//Hãng sản xuất
var pc_hsx_tatca = document.getElementById("checkbox_pc_tatca");
var pc_hsx_epower = document.getElementById("checkbox-pc_epower");
var pc_hsx_imac = document.getElementById("checkbox-pc_imac");
var pc_hsx_macmini = document.getElementById("checkbox-pc_Macmini");
var pc_hsx_lenovo = document.getElementById("checkbox-pc_lenovo");
var pc_hsx_hp = document.getElementById("checkbox-pc_hp");
var pc_hsx_asus = document.getElementById("checkbox-pc_asus");

//Nhu Cầu
var nc_tatca = document.getElementById("checkbox_pc_nhucau_tatca");
var nc_gamming = document.getElementById("checkbox-pc_nhucau1");
var nc_dohoa = document.getElementById("checkbox-pc_nhucau2");
var nc_vanphong = document.getElementById("checkbox-pc_nhucau3");

//Giá bán
var gb_tatca = document.getElementById("checkbox_pc_tatcagia");
var gb_gia1 = document.getElementById("checkbox-pc_gia1");
var gb_gia2 = document.getElementById("checkbox-pc_gia2");
var gb_gia3 = document.getElementById("checkbox-pc_gia3");
var gb_gia4 = document.getElementById("checkbox-pc_gia4");
var gb_gia5 = document.getElementById("checkbox-pc_gia5");
var gb_gia6 = document.getElementById("checkbox-pc_gia6");

//#region Giá bán
function pc_giaban() {
    if (!gb_gia1.checked && !gb_gia2.checked && !gb_gia3.checked && !gb_gia4.checked && !gb_gia5.checked && !gb_gia6.checked) {
        gb_tatca.checked = true;
    }
}

gb_tatca.addEventListener("click", function () {
    if (gb_tatca.checked) {
        gb_gia1.checked = false;
        gb_gia2.checked = false;
        gb_gia3.checked = false;
        gb_gia4.checked = false;
        gb_gia5.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia1.addEventListener("click", function () {
    if (gb_gia1.checked) {
        gb_tatca.checked = false;
        gb_gia2.checked = false;
        gb_gia3.checked = false;
        gb_gia4.checked = false;
        gb_gia5.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia2.addEventListener("click", function () {
    if (gb_gia2.checked) {
        gb_tatca.checked = false;
        gb_gia1.checked = false;
        gb_gia3.checked = false;
        gb_gia4.checked = false;
        gb_gia5.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia3.addEventListener("click", function () {
    if (gb_gia3.checked) {
        gb_tatca.checked = false;
        gb_gia1.checked = false;
        gb_gia2.checked = false;
        gb_gia4.checked = false;
        gb_gia5.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia4.addEventListener("click", function () {
    if (gb_gia4.checked) {
        gb_tatca.checked = false;
        gb_gia1.checked = false;
        gb_gia2.checked = false;
        gb_gia3.checked = false;
        gb_gia5.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia5.addEventListener("click", function () {
    if (gb_gia5.checked) {
        gb_tatca.checked = false;
        gb_gia1.checked = false;
        gb_gia2.checked = false;
        gb_gia3.checked = false;
        gb_gia4.checked = false;
        gb_gia6.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})

gb_gia6.addEventListener("click", function () {
    if (gb_gia6.checked) {
        gb_tatca.checked = false;
        gb_gia1.checked = false;
        gb_gia2.checked = false;
        gb_gia3.checked = false;
        gb_gia4.checked = false;
        gb_gia5.checked = false;
    }
    pc_giaban();
    pc_giaban_check();
})
//#endregion

//#region Nhu Cầu
function pc_nhucau() {
    if (!nc_gamming.checked && !nc_dohoa.checked && !nc_vanphong.checked) {
        nc_tatca.checked = true;
    }
}

function pc_nhucau_check() {
    if (nc_gamming.checked && nc_dohoa.checked && nc_vanphong.checked) {
        nc_tatca.checked = true;
        nc_gamming.checked = false;
        nc_dohoa.checked = false;
        nc_vanphong.checked = false;
    }
}

nc_tatca.addEventListener("click", function () {
    if (nc_tatca.checked) {
        nc_gamming.checked = false;
        nc_dohoa.checked = false;
        nc_vanphong.checked = false;
    }
    pc_nhucau();
    pc_nhucau_check();
})

nc_gamming.addEventListener("click", function () {
    if (nc_gamming.checked) {
        nc_tatca.checked = false;
    }
    pc_nhucau();
    pc_nhucau_check();
})

nc_dohoa.addEventListener("click", function () {
    if (nc_dohoa.checked) {
        nc_tatca.checked = false;
    }
    pc_nhucau();
    pc_nhucau_check();
})

nc_vanphong.addEventListener("click", function () {
    if (nc_vanphong.checked) {
        nc_tatca.checked = false;
    }
    pc_nhucau();
    pc_nhucau_check();
})
//#endregion

//#region Hãng sản xuất
//Kiểm tra
function pc_hsx() {
    if (!pc_hsx_epower.checked && !pc_hsx_imac.checked && !pc_hsx_macmini.checked && !pc_hsx_lenovo.checked && !pc_hsx_hp.checked && !pc_hsx_asus.checked) {
        pc_hsx_tatca.checked = true;
    }
}

function pc_hsx_check() {
    if (pc_hsx_epower.checked && pc_hsx_imac.checked && pc_hsx_macmini.checked && pc_hsx_lenovo.checked && pc_hsx_hp.checked && pc_hsx_asus.checked) {
        pc_hsx_tatca.checked = true;
        pc_hsx_epower.checked = false;
        pc_hsx_imac.checked = false;
        pc_hsx_macmini.checked = false;
        pc_hsx_lenovo.checked = false;
        pc_hsx_hp.checked = false;
        pc_hsx_asus.checked = false;
    }
}



pc_hsx_tatca.addEventListener("click", function () {
    if (pc_hsx_tatca.checked) {
        pc_hsx_epower.checked = false;
        pc_hsx_imac.checked = false;
        pc_hsx_macmini.checked = false;
        pc_hsx_lenovo.checked = false;
        pc_hsx_hp.checked = false;
        pc_hsx_asus.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_epower.addEventListener("click", function () {
    if (pc_hsx_epower.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_imac.addEventListener("click", function () {
    if (pc_hsx_imac.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_macmini.addEventListener("click", function () {
    if (pc_hsx_macmini.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_lenovo.addEventListener("click", function () {
    if (pc_hsx_lenovo.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_hp.addEventListener("click", function () {
    if (pc_hsx_hp.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

pc_hsx_asus.addEventListener("click", function () {
    if (pc_hsx_asus.checked) {
        pc_hsx_tatca.checked = false;
    }
    pc_hsx();
    pc_hsx_check();
})

//#endregion


