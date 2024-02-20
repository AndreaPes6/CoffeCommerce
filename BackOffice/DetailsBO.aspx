<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="DetailsBO.aspx.cs" Inherits="CoffeCommerce.BackOffice.DetailsBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 ms-3">Product Details Back Office</h1>
    <div class="container my-3 mx-0 ">
        <div class="text-end">
            <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
        </div>

        <div id="productDetails" runat="server">
        </div>
    </div>
</asp:Content>
