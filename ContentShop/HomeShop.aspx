<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="HomeShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.HomeShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg w-75 m-auto my-5">
        <div class="d-flex justify-content-between align-items-center mb-5">
            <h5 id="tltCategory" runat="server">All Products</h5>
            
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select dp-dw-cat">
                <asp:ListItem Value="0">All Categories</asp:ListItem>
                <asp:ListItem Value="1">Capsule Dolce Gusto</asp:ListItem>
                <asp:ListItem Value="2">Capsule Nespresso</asp:ListItem>
                <asp:ListItem Value="3">Capsule Lavazza</asp:ListItem>
                <asp:ListItem Value="4">Cialde ESE</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="contentHtml" runat="server" class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 row-cols-xl-5 g-3">
        </div>
    </div>
</asp:Content>
