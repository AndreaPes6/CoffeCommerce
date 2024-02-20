<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="DetailsShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.DetailsShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3 mx-0 ">
        <h1>Product Details</h1>
        <div id="productDetails" runat="server">
        </div>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-success btn-md mt-4" OnClick="btnAddToCart_Click" />
    </div>
</asp:Content>
