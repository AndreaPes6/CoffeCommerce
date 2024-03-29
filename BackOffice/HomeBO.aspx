﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="HomeBO.aspx.cs" Inherits="CoffeCommerce.BackOffice.HomeBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
            <div id="contentHtml" runat="server" >

            </div>
        </div>

    </div>
</asp:Content>
