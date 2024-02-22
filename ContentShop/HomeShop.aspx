<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="HomeShop.aspx.cs" Inherits="CoffeCommerce.ContentShop.HomeShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="productCarousel" class="carousel slide" data-ride="carousel">
    <div class="carousel-inner">
  <asp:Repeater ID="RepeaterCarousel" runat="server">
                <ItemTemplate>
                    <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %> text-black">
                        <div class="d-flex justify-content-around align-items-center">
                            <img src='<%# Eval("FotoProduct") %>' class="d-block mx-2 my-4" alt='<%# Eval("Name") %>' style="max-width: 75px; height: auto;" />

                        </div>
                        <div class="text-center mt-3">
                            <h6 class="text-black"><%# Eval("Name") %></h6>
                            <p class="text-secondary text-black" style="font-size: 0.8em;"><%# Eval("Description") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>

</div>

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
        <div id="contentHtml" runat="server" class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4  g-3">
            <asp:Repeater ID="ProductRepeater" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="c-card card h-100 d-flex flex-column justify-content-between">
                            <div class="p-2 d-flex justify-content-center">
                                <img src='<%# Eval("FotoProduct") %>' class="card-img-top rounded" alt='<%# Eval("Name") %>' style="width: 150px; height: auto;" />
                            </div>
                            <div>
                                <div class="card-body text-center">
                                    <h6 class="card-title"><%# Eval("Name") %></h6>
                                    <p class="card-text text-secondary" style="font-size: 0.8em;"><%# Eval("Description") %></p>
                                    <p class="card-text me-2 fs-5">€ <%# Eval("Price") %></p>
                                </div>
                                <div class="d-flex justify-content-between align-items-baseline p-3">
                                    <div>

                                        <asp:DropDownList ID="ddlQuantity" runat="server">
                                            <asp:ListItem Text="1" Value="1" />
                                            <asp:ListItem Text="2" Value="2" />
                                            <asp:ListItem Text="3" Value="3" />
                                            <asp:ListItem Text="4" Value="4" />
                                            <asp:ListItem Text="5" Value="5" />
                                            <asp:ListItem Text="6" Value="6" />
                                            <asp:ListItem Text="7" Value="7" />
                                            <asp:ListItem Text="8" Value="8" />
                                            <asp:ListItem Text="9" Value="9" />
                                            <asp:ListItem Text="10" Value="10" />
                                        </asp:DropDownList>
                                    </div>

                                    <div class="d-flex justify-content-end align-items-center p-3 ">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="btnAddToCart_Command" CommandArgument='<%# Eval("ID") %>' CommandName="AddToCart" CssClass="me-1">
                                           <div class="d-flex justify-content-center text-white rounded-circle p-2 h-btn-cart">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-cart-plus" viewBox="0 0 16 16" >
                                            <path d="M9 5.5a.5.5 0 0 0-1 0V7H6.5a.5.5 0 0 0 0 1H8v1.5a.5.5 0 0 0 1 0V8h1.5a.5.5 0 0 0 0-1H9z" />
                                            <path d="M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1zm3.915 10L3.102 4h10.796l-1.313 7zM6 14a1 1 0 1 1-2 0 1 1 0 0 1 2 0m7 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
                                        </svg>
                                            </div>
                                        </asp:LinkButton>

                                        <a href='<%# "DetailsShop.aspx?product=" + Eval("ID") %>' class="ms-1">
                                            <div class="d-flex justify-content-center align-items-center btn-card rounded-circle p-1">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="27" height="27" fill="currentColor" class="bi bi-info-lg " viewBox="0 0 16 16">
                                                    <path d="m9.708 6.075-3.024.379-.108.502.595.108c.387.093.464.232.38.619l-.975 4.577c-.255 1.183.14 1.74 1.067 1.74.72 0 1.554-.332 1.933-.789l.116-.549c-.263.232-.65.325-.905.325-.363 0-.494-.255-.402-.704zm.091-2.755a1.32 1.32 0 1 1-2.64 0 1.32 1.32 0 0 1 2.64 0" />
                                                </svg>

                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
