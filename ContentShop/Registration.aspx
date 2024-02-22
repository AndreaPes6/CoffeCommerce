<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CoffeCommerce.ContentShop.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header" style="background-color: #0C141A;">
                        <h2 class="card-title text-light fs-4 m-0">Sign In</h2>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="TxtUserName" class="form-label">Username</label>
                            <asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control " ></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="TxtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="TxtPassword" class="form-label">Password</label>
                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="TxtProfilePicture" class="form-label">URL dell'immagine del profilo</label>
                            <asp:TextBox ID="TxtProfilePicture" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3 d-flex justify-content-center">
                            <asp:Button ID="BtnRegister" runat="server" Text="Sign in" CssClass="btn btn-card rounded-pill me-3" OnClick="BtnRegister_Click" />
                            <asp:Button ID="BtnBackToLogin" runat="server" Text="Return to Login" CssClass="btn btn-card rounded-pill" OnClick="BtnBackToLogin_Click" />
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
