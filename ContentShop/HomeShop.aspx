<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="HomeShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.HomeShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg w-75 m-auto my-5">
        <div class="d-flex justify-content-between">
            <h5 style="margin-top: 100px;">Explore</h5>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>

        </div>
        

        <div id="contentHtml" runat="server" class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 row-cols-xl-5 g-3">
        </div>

    </div>

</asp:Content>
