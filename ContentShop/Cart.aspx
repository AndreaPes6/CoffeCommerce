<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CoffeCommerce.ContentShop.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cart-page">
        <h2 class="mb-4">Il tuo Carrello</h2>
        <div class="row">
            <asp:Repeater ID="CartRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-12">
                        <div class='col-md-6'>
                            <img src='<%# Eval("UrlImage") %>' class='img-fluid rounded product-image w-25 h-auto border border-solid-black' alt='<%# Eval("Nome") %>'>
                        </div>
                        <div class="card mb-4 shadow-sm">
                            <div class="card-body">
                                <h4 class="card-title"><%# Eval("Nome") %></h4>
                                <p class="card-text">Prezzo: <%# Eval("Prezzo") %> €</p>
                                <p class="card-text">Quantità: <%# Eval("Quantità") %></p>
<asp:LinkButton runat="server" ID="RemoveFromCartButton" CssClass="btn btn-danger bi bi-trash" CommandName="RemoveFromCart" CommandArgument='<%# Container.ItemIndex %>' OnCommand="RemoveFromCartButton_Command">
    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
        <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
    </svg>
</asp:LinkButton>


                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="text-right cart-page">
        <h4 class="text-danger">Totale: <span runat="server" id="totalAmountLabel"></span>€</h4>
        <asp:Label runat="server" ID="emptyCartMessage" Visible="false" Text="Il carrello è vuoto." CssClass="text-danger"></asp:Label>
        <asp:Button runat="server" ID="EmptyCartButton" Text="Svuota Carrello" CssClass="btn btn-danger" OnClick="EmptyCartButton_Click" />
    </div>
</asp:Content>
