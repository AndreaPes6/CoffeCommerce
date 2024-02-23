﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="DetailsBO.aspx.cs" Inherits="CoffeCommerce.BackOffice.DetailsBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="fw-bold fw-light txt-lbladd mt-2">Product Details Back Office</h1>
    <div class="container m-0 p-0">


        <div class="row justify-content-start mt-3 ">
            <div id="productDetails" runat="server">
            </div>

            <div class="col-auto">
                <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-primary me-3" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            </div>



        </div>

        



    </div>
</asp:Content>
