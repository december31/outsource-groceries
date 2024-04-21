$(document).ready(function(e){
    $('.search-panel .dropdown-menu').find('a').click(function(e) {
		e.preventDefault();
		var param = $(this).attr("href").replace("#","");
		var concept = $(this).text();
		$('.search-panel span#search_concept').text(concept);
		$('.input-group #search_param').val(param);
    });

    //Check input on DangKy.aspx
    var txtEmail = document.getElementById("inputEmail3");
    var txtPass = document.getElementById("inputPassword3");
    var txtPassR = document.getElementById("inputPasswordR");
    var btnSignUp = document.getElementById("btnSignUp");

    if (txtPassR && txtPass) {
        txtPassR.addEventListener("blur", () => {
            if (txtPass.value == txtPassR.value) {
                btnSignUp.classList.remove("non-active");
            }
            else {
                alert("Mật khẩu không khớp!!!");
            }
        });
    }

    if (btnSignUp && txtEmail && txtPass && txtPassR) {
        btnSignUp.addEventListener("mousemove", () => {
            if (txtEmail.value == "") {
                alert("Bạn chưa nhập Email.");
            } else if (txtPass.value == "") {
                alert("Bạn chưa nhập mật khẩu.");
            } else if (txtPassR.value == "") {
                alert("Bạn chưa nhập lại mật khẩu.");
            } else if (txtPass.value != txtPassR.value) {
                btnSignUp.classList.add("non-active");
            }
        });
    }

    //Check input on DangNhap.aspx

    //Check input on QuanLyTaiKhoan.aspx
    var txtEmail1 = document.getElementById("inputEmail1");
    var txtPass1 = document.getElementById("inputPass1");
    var btnAddAcc = document.getElementById("btnAddAcc");

    if (btnAddAcc && txtEmail1 && txtPass1) {
        btnAddAcc.addEventListener("mousemove", () => {
            if (txtEmail1.value == "") {
                btnAddAcc.classList.add("non-active");
                txtEmail1.focus();
            } else if (txtPass1.value == "") {
                btnAddAcc.classList.add("non-active");
                txtPass1.focus();
            }
        });

        txtPass1.addEventListener("blur", () => {
            if (txtPass1.value != "" && txtEmail1.value != "") {
                btnAddAcc.classList.remove("non-active");
            } else if (txtPass1.value != "" && txtEmail1.value === "") {
                txtEmail1.focus();
            }
        });

        txtEmail1.addEventListener("blur", () => {
            if (txtEmail1.value != "") {
                btnAddAcc.classList.remove("non-active");
            }
        });
    }

    $(".btn-size").click(function(){

        $(".btn-size").removeClass('active');
        $(this).addClass('active');
    });
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result).width(150).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
