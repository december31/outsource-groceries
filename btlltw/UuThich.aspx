<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/layout.Master" CodeBehind="UuThich.aspx.cs" Inherits="btlltw.UuThich" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
			<div class="row">
				<img src="images/hat4.jpg" width="100%" height="auto" alt="" style="min-height: 300px">
			</div>
		</div>
		<div class="container">
			<center><h3>DANH MỤC ƯA THÍCH</h3></center>
			<br>
			<div class="row">
				<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
					<div class="chontatca">
						<label class="checkbox-inline"><input type="checkbox" value="">Chọn tất cả</label>
					</div>
					<div class="chitietdondathang box effect3">
						<div class="row">
							<div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
								<label class="checkbox-inline"><input type="checkbox" value=""><img src="images/abc (1).png" height="auto" width="100%" alt=""></label>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
								<h4>Bát gỗ hoa văn giả vân gỗ cực sang trọng</h4>
								<div class="">
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>		
									<i class="fa fa-star-half-o" aria-hidden="true"></i>
									<i class="fa fa-star-o" aria-hidden="true"></i>
								</div>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
								<h4 style="color: orange">84.000đ</h4>
								<del>148.000đ</del>
								<h5>-43%</h5>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
								<button class="btn btn-warning"><i class="fa fa-shopping-basket" aria-hidden="true"></i> Mua ngay</button>
								<button class="btn btn-basic"><i class="fa fa-trash" aria-hidden="true"></i> Xóa</button>
							</div>
						</div>
					</div>
					<div class="chitietdondathang box effect3">
						<div class="row">
							<div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
								<label class="checkbox-inline"><input type="checkbox" value=""><img src="images/abc (2).png" width="100%" height="" alt=""></label>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
								<h4>Cặp chảo rán làm từ inox cực bền bỉ</h4>
								<div class="">
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>		
									<i class="fa fa-star-half-o" aria-hidden="true"></i>
									<i class="fa fa-star-o" aria-hidden="true"></i>
								</div>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
								<h4 style="color: orange">99.000đ</h4>
								<del>188.000đ</del>
								<h5>-49%</h5>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
								<button class="btn btn-warning"><i class="fa fa-shopping-basket" aria-hidden="true"></i> Mua ngay</button>
								<button class="btn btn-basic"><i class="fa fa-trash" aria-hidden="true"></i> Xóa</button>
							</div>
						</div>
					</div>
				</div>	
			</div>
		</div>
</asp:Content>
