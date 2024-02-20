<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CoffeCommerce.ContentShop.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="mb-3">
            <label for="PlaceholderContent_TxtUsername" class="form-label">Username</label>
            <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="PlaceholderContent_TxtPassword" class="form-label">Password</label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="BtnLogin_Click"/>
    </div>
</asp:Content>
