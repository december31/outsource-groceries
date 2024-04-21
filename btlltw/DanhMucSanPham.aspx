<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="DanhMucSanPham.aspx.cs" Inherits="btlltw.DanhMucSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script src="JS/script.js" language="javascript" type="text/javascript"></script>
    <div class="container-fluid">
		<div class="row">
			<img src="images/hat4.jpg" width="100%" height="auto" alt="" style="min-height: 300px">
		</div>
	</div>
	<div class="container">
		<div class="row">
			<div class="content">
				<div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
					<h4 style="margin-top: 0px;" onmouseover="move.js"><b>DANH MỤC SẢN PHẨM</b></h4>
					<ul>
						<li  class="alert-info"><a href="">+ Đèn trang trí</a></li>
						<li  class="alert-info"><a href="">+ Ghế ngồi</a></li>
						<li  class="alert-info"><a href="">+ Đồng hồ</a></li>
						<li  class="alert-info"><a href="">+ Bình lọ sứ</a></li>
						<li  class="alert-info"><a href="">+ Đồ để bàn</a></li>
						<li  class="alert-info"><a href="">+ Đèn trang trí</a></li>
					</ul>
					<hr>
                    <div class="filter">
					    <h4 style="margin-top: 0px;"><b>LỌC THEO GIÁ</b></h4>
					    <ul>
						    <li><input type="number" value="Từ" class="form-control" id="cost_1"></li>
						    <li><input type="number" value="Đến" class="form-control" id="cost_2"></li>
						    <li><button onclick="check_loc()" type="button" class="btn btn-default"><i class="fa fa-filter" aria-hidden="true"></i></button></li>
					    </ul>
                    </div>
					<hr>
					<h4 style="margin-top: 0px;"><b>TỪ KHÓA PHỔ BIẾN</b></h4>
					<button type="button" class="btn btn-default key">Tủ</button>
					<button type="button" class="btn btn-default key">Bàn học</button>
					<button type="button" class="btn btn-default key">Đèn</button>
					<button type="button" class="btn btn-default key">Ghế</button>
					<button type="button" class="btn btn-default key">Giường</button>
					<button type="button" class="btn btn-default key">Lọ</button>
				</div>
				<div class="col-xs-15 col-sm-15 col-md-12 col-lg-12" id="listProduct" name="listProduct" runat="server">
					
				</div>

			</div>

		</div>
	</div>
</asp:Content>
