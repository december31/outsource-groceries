<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="GioHang.aspx.cs" Inherits="btlltw.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
			<div class="row">
				<img src="images/hat4.jpg" width="100%" height="auto" alt="" style="min-height: 300px">
			</div>
		</div>
		<div class="container">
			<center><h3>GIỎ HÀNG</h3></center>
			<br>
			<div class="row">
				<div class="col-xs-12 col-sm-12 col-md-8 col-lg-8" id="listCart" runat="server">
					    
				</div>	
				<div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
					<div class="thongtindonhang box effect2">
						<p><b>Địa điểm:</b> 96 Định Công - Thanh Xuân - Hà Nội</p>
						<hr>
						<h4>Thông tin đơn hàng</h4>
						<div class="row">
							<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
								<p id="txtTongsp" runat="server"></p>
							</div>
							<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 text-right">
								<p id="txtTongTien" runat="server"></p>
							</div>

							<div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
								<input type="text" class="form-control" placeholder="Nhập mã giảm giá...">
							</div>
							<div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
								<button class="btn btn-success">ÁP DỤNG</button>
							</div>
						</div>
						<hr>
						<div class="row">
							<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
								<p>Tổng cộng: </p>	
							</div>	
							<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 text-right">
								<p style="color:red" id="txtThanhTien" runat="server"></p>
							</div>
							<center><button class="btn btn-warning" style="width: 90%">Xác nhận đơn hàng</button></center>
						</div>
					</div>
				</div>
			</div>
		</div>
</asp:Content>