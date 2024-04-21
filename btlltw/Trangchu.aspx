<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="Trangchu.aspx.cs" Inherits="btlltw.Trangchu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
		<div class="row">
			<div id="myCarousel" class="carousel slide" data-ride="carousel">
				<!-- Indicators -->
				<ol class="carousel-indicators">
					<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
					<li data-target="#myCarousel" data-slide-to="1"></li>
					<li data-target="#myCarousel" data-slide-to="2"></li>
				</ol>
				<!-- Wrapper for slides -->
				<div class="carousel-inner">
					<div class="item active">
						<img src="images/home1-slider1.jpg" alt="Chania">
						<div class="carousel-caption" style="color: black;margin-right:40%;margin-bottom: 11%">
							<h1 style="font-size: 70px;">Tết nguyên đán</h1>
							<p>Hàng ngàn sản phẩm giảm giá 50%</p>
							<button type="button" class="btn btn-basic" style="border: 1px solid black">Mua sắm ngay</button>
						</div>
					</div>
					<div class="item">
						<img src="images/home1-slider2.jpg" alt="Chicago">
						<div class="carousel-caption" style="color: black;margin-right:40%;margin-bottom: 17%">
							<h1 style="font-size: 70px;">Ngày lễ Valentine</h1>
							<p>Nhận vourcher cực khủng lên đến 20 triệu</p>
							<button type="button" class="btn btn-basic" style="border: 1px solid black">Mua sắm ngay</button>
						</div>
					</div>
					<div class="item">
						<img src="images/home1-slider3.jpg" alt="New York">
						<div class="carousel-caption" style="color: black;margin-right:40%;margin-bottom: 17%">
							<h1 style="font-size: 70px">Ngày 8/3</h1>
							<p>Bốc thăm trúng thưởng ô tô</p>
							<button type="button" class="btn btn-basic" style="border: 1px solid black">Mua sắm ngay</button>
						</div>
					</div>
				</div>
				<!-- Left and right controls -->
				<a class="carousel-control" href="#myCarousel" data-slide="prev">
					<span class="sr-only">Previous</span>
				</a>
				<a class="carousel-control" href="#myCarousel" data-slide="next">
					<span class="sr-only">Next</span>
				</a>
			</div>
		</div>
	</div>
</div>
<div class="container-fluid">
	<div class="row">
		<div class="col-xs-4 col-sm-4 col-md-4 col-lg-4 three">
			<img src="images/home1-banner1-1.jpg" width="100%" alt="">
		</div>
		<div class="col-xs-4 col-sm-4 col-md-4 col-lg-4 three">
			<img src="images/home1-banner1-2.jpg" width="100%" alt="">
		</div>
		<div class="col-xs-4 col-sm-4 col-md-4 col-lg-4 three">
			<img src="images/home1-banner1-3.jpg" width="100%" alt="">
		</div>
	</div>
</div>
<div id="main-content">
    <div class="container">
	    <center><h2>SẢN PHẨM MỚI</h2></center>
	    <center><p>Xu hướng năm 2019</p></center>
	    <div class="row" id="listNewProduct" runat="server">
		    
	    </div>
    </div>
    <div class="container">
	    <div class="row" style="margin-top:40px;margin-bottom: 40px">
		    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
			    <div class="anhproduct">
				    <img src="images/Banner-2l.jpg" width="100%" alt="">
			    </div>
			    <div class="shopnowl">
				    <button type="button" class="btn btn-default">Mua sắm ngay</button>
			    </div>
		    </div>
		    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
			    <div class="anhproduct">
				    <img src="images/Banner_2r.jpg" width="100%" alt="">
			    </div>
			    <div class="shopnowr">
				    <button type="button" class="btn btn-default">Mua sắm ngay</button>
			    </div>
		    </div>
	    </div>
    </div>
    <div class="container">
	    <div class="row" style="margin: 50px;">
		    <center><h2>Sản Phẩm Nổi Bật</h2></center>
		    <center><p>Được săn đón nhiều nhất năm 2019</p></center>
	    </div>
	    <div class="row" id="listBestProduct" runat="server">
		    
        </div>
    </div>
</div>
<hr>
<div class="container-fluid">
	<div class="container">
		<div class="row">
			<div class="theodoi">
				<center>
					<h2>Theo dõi gian hàng</h2>
					<p>Hãy để lại email chúng tôi sẽ cập nhật những mặt hàng mới nhất tới địa chỉ email của bạn</p>
					<div class="col-xs-3"></div>
					<div class="col-xs-6">
						<div class="input-group">
							<input type="text" class="form-control" placeholder="Nhập email của bạn" style="height: 50px">
							<span class="input-group-btn">
								<button type="button" style="height: 50px;width: 70px" class="btn btn-success">Go</button>
							</span>
						</div>
					</div>
					<div class="col-xs-3"></div>
				</center>
			</div>
		</div>
	</div>
</div>
</asp:Content>
