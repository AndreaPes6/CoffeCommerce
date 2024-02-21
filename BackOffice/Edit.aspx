<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CoffeCommerce.BackOffice.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Edit Product</h2>

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="Label1" runat="server" Text="Select Categories"></asp:Label>
                <asp:DropDownList ID="txtIDCategory" runat="server" AutoPostBack="true" CssClass="form-select ">
                    <asp:ListItem Value="1">Capsule Dolce Gusto</asp:ListItem>
                    <asp:ListItem Value="2">Capsule Nespresso</asp:ListItem>
                    <asp:ListItem Value="3">Capsule Lavazza</asp:ListItem>
                    <asp:ListItem Value="4">Cialde ESE</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price"></asp:Label>
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div>
            <asp:Label ID="lblProductDescription" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control" Rows="4" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div class="row mt-3">
            <div class="col-md-12">
                <asp:Label ID="lblProductImage" runat="server" Text="Product Image URL"></asp:Label>
                <asp:TextBox ID="txtProductImage" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-4">

            <div class="row mt-3">
                <div class="col-md-12">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Product" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
