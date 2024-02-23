<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="DetailsShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.DetailsShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3 mx-0 ">

        <div id="productDetails" runat="server">
            
            <div class='container mt-4'>
                <h1 class="fw-bold fw-light txt-lbladd mb-5" id="tltName" runat="server" >Product Details</h1>
                <div class='row ms-3'>
                    <div class='col-md-4 p-0 me-1 me-3'>
                        <img id="imgProd" runat="server" class='img-fluid rounded product-image w-100 border border-solid-black shadow'  onclick='zoomImage(this)' style='cursor: pointer;' />
                    </div>
                    <div class='col-md-7'>
                        <h5 class='fw-bold fw-light txt-lbladd text-uppercase mb-4'>Description</h5>
                        <p class='fs-6 mb-2' id="txtDescription" runat="server"></p>
                        <p class='fs- mb-3' id="txtPrice" runat="server"></p>
                        <div class='form-group mb-4 d-flex align-items-baseline'>
                            <label for='quantity' class='fw-bold me-2'>Quantity:</label>
                            <asp:DropDownList ID="dwdQuantity" runat="server" class='form-select form-select-sm w-25 '>
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
                        </div>
                          <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-md mt-2 rounded-pill btn-card" OnClick="btnAddToCart_Click" />

                    </div>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
