<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout.Master" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="btlltw.QuanLyTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
		<div class="row">
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				<div class="them-mat-hang box effect5">
					<center><h3><b>Tài Khoản</b></h3></center>
						
					<center>
					<form>
						<div class="form-group row">
							<label for="inputEmail1" class="col-sm-2 col-form-label">Email</label>
							<div class="col-sm-10">
								<input type="email" class="form-control" id="inputEmail1" placeholder="exam@gmail.com" name="txtEmail">
							</div>
						</div>
						<div class="form-group row">
							<label for="inputPass1" class="col-sm-2 col-form-label">Password</label>
							<div class="col-sm-10">
								<input type="password" class="form-control" id="inputPass1" placeholder="Password" name="txtPass">
							</div>
						</div>
						<div class="form-group row">
							<div class="col-sm-12 ">									
								<br>
								<center> <button type="submit" class="btn btn-success" value="true" name="btnThem" id="btnAddAcc">Thêm</button></center>
							</div>

						</div>
					</form>
					</center>
				</div>
			</div>
		</div>
		<div class="list-account box effect3">
			<div class="row">
				<asp:Table ID="table" runat="server" CssClass="table table-hover">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell runat="server">ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Email</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Pass</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Chức năng</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
				</asp:Table>
			</div>
		</div>
	</div>
</asp:Content>