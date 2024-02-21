<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="DetailsShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.DetailsShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3 mx-0 ">
        <h1>Product Details</h1>
        <div id="productDetails" runat="server">
            <div class='container mt-5'>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <div class='row'>
                    <div class='col-md-5'>
                        <img id="imgProd" runat="server" class='img-fluid rounded product-image w-100 border- border-solid-black'  onclick='zoomImage(this)' style='cursor: pointer;' />
                    </div>
                    <div class='col-md-6'>
                        <h2 class='fw-bold text-uppercase mb-4' id="tltName" runat="server"></h2>
                        <p class='fs-5 mb-4' id="txtDescription" runat="server"></p>
                        <p class='fw-bold fs-4 mb-4' id="txtPrice" runat="server"></p>
                        <div class='form-group mb-4'>
                            <label for='quantity' class='fw-bold'>Quantity:</label>
                            <asp:DropDownList ID="dwdQuantity" runat="server" class='form-select form-select-lg'>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-success btn-md mt-4" OnClick="btnAddToCart_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
