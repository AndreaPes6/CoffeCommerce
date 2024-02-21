<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="DetailsShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.DetailsShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3 mx-0 ">

        <div id="productDetails" runat="server">
            <h1 class="fw-bold fw-light txt-lbladd mt-2">Product Details</h1>
            <div class='container mt-5'>
                
                <div class='row ms-3'>
                    <div class='col-md-4 p-0 me-1'>
                        <img id="imgProd" runat="server" class='img-fluid rounded product-image w-100 border border-solid-black'  onclick='zoomImage(this)' style='cursor: pointer;' />
                    </div>
                    <div class='col-md-7'>
                        <h2 class='fw-bold fw-light txt-lbladd text-uppercase mb-4' id="tltName" runat="server"></h2>
                        <p class='fs-4 mb-5' id="txtDescription" runat="server"></p>
                        <p class='fs-4 mb-3' id="txtPrice" runat="server"></p>
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
