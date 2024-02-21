<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="DetailsBO.aspx.cs" Inherits="CoffeCommerce.BackOffice.DetailsBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="fw-bold fw-light txt-lbladd mt-2">Product Details Back Office</h1>

        <div class="row justify-content-start mt-3 mb-3">

            <div class="col-auto">
                <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
            </div>

            <div class="col-auto">
                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            </div>

        </div>

        <div id="productDetails" runat="server">
        </div>



    </div>
</asp:Content>
