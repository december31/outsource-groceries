<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="DangNhap.aspx.cs" Inherits="btlltw.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="z-index: -2;background-color: #EBE7E7;">
			<div class="row">
				<div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
					
				</div>
				<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
					<div class="noidangnhap box effect5">
						<center><h3><b>Đăng Nhập</b></h3></center>
						
						<center><form>
							<div class="form-group row">
								<label for="inputEmail3" class="col-sm-2 col-form-label">Tài khoản</label>
								<div class="col-sm-10">
									<input type="email" class="form-control" id="inputEmail4" placeholder="Email" name="txtEmail">
								</div>
							</div>
							<div class="form-group row">
								<label for="inputPassword3" class="col-sm-2 col-form-label">Mật khẩu</label>
								<div class="col-sm-10">
									<input type="password" class="form-control" id="inputPassword4" placeholder="Password" name="txtPass">
								</div>
							</div>
							<div class="form-group row">
								<div class="col-sm-12 ">
									<br>
									<center> <button type="submit" class="btn btn-success" value="true" name="btnLogin" id="btnLogin">Đăng Nhập</button></center>
									<br>
									<center><label><a href="" style="color:blue">Quên mật khẩu ?</a></label></center>

									<center><label>Chưa có tài khoản đăng ký tại<a href="DangKy.aspx" style="color: blue"> đây !</a></label></center>

								</div>

							</div>
						</form>
						</center>
					</div>
				</div>
				<div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
					
				</div>
			</div>
		</div>
</asp:Content>