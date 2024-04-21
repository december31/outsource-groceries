<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="GioiThieu.aspx.cs" Inherits="btlltw.GioiThieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
			<div class="row">
				<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
					<div class="gopy box effect2" style="border: 1px #ddd solid;padding: 20px;border-radius: 10px;">
					<div class="row" style="padding: 30px">
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<h3><b><i class="fa fa-map-marker" aria-hidden="true"></i>
 Địa Chỉ</b></h3>
							<p>96 Định Công - Thanh Xuân - Hà Nội</p>
							<h3><b><i class="fa fa-envelope-o" aria-hidden="true"></i>
Email</b></h3>
							<p>LienHe@gmail.com</p>
							<p>Hotro@gmail.com</p>
						</div>
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<h3><b><i class="fa fa-phone" aria-hidden="true"></i>
 Điện Thoại</b></h3>
							<p>012312311</p>
							<h3><b><i class="fa fa-clock-o" aria-hidden="true"></i>
 Thời gian mở cửa</b></h3>
							<p>T2 - T6 : 08:00 - 20:00</p>
							<p>T7 - CN : 13:00 - 22:00</p>
							<p></p>
						</div>
					</div>
				</div>
				<br>
			</div>
				<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
					<div class="gopy box effect2" style="border: 1px #ddd solid;padding: 15px;border-radius: 10px;">
					<div class="row">
						<center><h2><b>Góp Ý</b></h2></center>
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<div class="form-group">
								<label for="usr">Họ và tên:</label>
								<input type="text" class="form-control" id="usr">
							</div>
						</div>
						<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							<div class="form-group">
								<label for="usr">Địa chỉ Email:</label>
								<input type="email" class="form-control" id="usr">
							</div>
						</div>
					
						<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
							<div class="form-group">
								<label for="exampleFormControlTextarea1">Lời Góp Ý</label>
								<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
							</div>
						</div>
						<center><button class="btn btn-warning" width="100%">Gửi</button></center>
					</div>
					</div>
				</div>
				</div>
			</div>
</asp:Content>
