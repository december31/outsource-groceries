<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="QuanLyMatHang.aspx.cs" Inherits="btlltw.QuanLy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
		<div class="row">
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				<div class="them-mat-hang box effect5">
					<center><h3><b>Mặt Hàng</b></h3></center>
						
					<center>
					<form>
						<div class="form-group row">
							<label for="inputTen1" class="col-sm-2 col-form-label">Tên mặt hàng</label>
							<div class="col-sm-10">
								<input type="text" class="form-control" id="inputTen1" placeholder="Tên Hàng" name="txtTen">
							</div>
						</div>
						<div class="form-group row">
							<label for="inputGia1" class="col-sm-2 col-form-label">Giá</label>
							<div class="col-sm-10">
								<input type="number" class="form-control" id="inputGia1" placeholder="100000" name="txtGia">
							</div>
						</div>
						<div class="form-group row">
							<label for="inputGia1" class="col-sm-2 col-form-label">Giảm giá</label>
							<div class="col-sm-10">
								<input type="number" class="form-control" id="inputGia2" placeholder="100" name="txtGiamgia">
							</div>
						</div>
						<div class="form-group row">
							<label for="inputAnh1" class="col-sm-2 col-form-label">Ảnh</label>
							<div class="col-sm-10">
                                <asp:FileUpload ID="inputAnh1" runat="server" name="myImage" CssClass="form-control" />
                                <asp:Button ID="btnUpLoad" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="btn btn-basic"/>
                                <asp:Image ID="Image1" runat="server" Width="150px" />
							</div>
						</div>
						<div class="form-group row">
							<div class="col-sm-12 ">									
								<br>
								<center> 
                                    <asp:button text="Thêm" runat="server" CssClass="btn btn-success" ID="btnAddProd" OnClick="btnThem_Click"/>
								</center>
							</div>

						</div>
					</form>
					</center>
				</div>
			</div>
		</div>
		<div class="list-product box effect3" id="listProduct" name="listProduct" runat="server"></div>
	</div>
</asp:Content>
