<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="DangKy.aspx.cs" Inherits="btlltw.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="z-index: -2;background-color: #EBE7E7;">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
            </div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <div class="noidangnhap dangky box effect5">
                    <center>
                        <h3>
                            <b>Đăng Ký</b>
                        </h3>
                    </center>
                    <form>
                        <div class="form-group row">
                            <label for="inputEmail3" class="col-sm-2 col-form-label">Tài khoản</label>
                            <div class="col-sm-10">
                                <input type="email" class="form-control" id="inputEmail3" placeholder="Email" name="txtEmail">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword3" class="col-sm-2 col-form-label">Mật khẩu</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" id="inputPassword3" placeholder="Password" name="txtPass">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPasswordR" class="col-sm-2 col-form-label">Nhập lại mật khẩu</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" id="inputPasswordR" placeholder="Re Password">
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPasswordR" class="col-sm-2 col-form-label">Giới tính</label>
                            <div class="col-sm-6 row">
                                <input name="radioGen" type="radio" value="male" id="radioNam">Nam
                                <input name="radioGen" type="radio" value="female" id="radioNu">Nữ
                            </div>
                        </div>
                        <!-- <div class="form-group row">
                            <center><label for="capcha" class="col-sm-6 col-form-label alert-success" style="height: 40px;padding: 10px;width: 100px">Capcha</label></center>
                            <div class="col-sm-6">
                                <input type="text" class="form-control" id="capcha" placeholder="Nhập Capcha">
                            </div>
                        </div> -->
                        <div class="form-group row">
                            <div class="col-sm-12 ">
                                <br>
                                <center>
                                    <button type="submit" class="btn btn-success non-active" name="btnSignUp" value="true" id="btnSignUp">Đăng Ký</button>
                                </center>
                                <br>
                                <center>
                                    <label>
                                        <a href="" style="color:blue">Quên mật khẩu ?</a>
                                    </label>
                                </center>

                                <center>
                                    <label>Đã có tài khoản đăng nhập tại<a href="DangNhap.aspx" style="color: blue"> đây !</a></label>
                                </center>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
            </div>
        </div>
    </div>
</asp:Content>
