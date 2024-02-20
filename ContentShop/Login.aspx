<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CoffeCommerce.ContentShop.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header" style="background-color: #0C141A;">
                        <h5 class="card-title text-light">Login</h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="TxtUsername" class="form-label">Username</label>
                            <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="TxtPassword" class="form-label">Password</label>
                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3 d-flex justify-content-center">
                            <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn btn-card rounded-pill" OnClick="BtnLogin_Click" />
                        </div>
                        <div class="mb-3 d-flex justify-content-center">
                            <asp:Label ID="LblErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
