<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CoffeCommerce.ContentShop.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Il tuo Carrello</h2>
    <div class="row">
        <asp:Repeater ID="CartRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-12">
                    <div class="card mb-4 shadow-sm">
                        <div class="card-body">
                            <h4 class="card-title"><%# Eval("Name") %></h4>
                            <p class="card-text">Prezzo: <%# Eval("Price") %> €</p>
                            <%--<asp:Button runat="server" ID="RemoveFromCartButton" Text="Rimuovi dal Carrello" CssClass="btn btn-danger" CommandName="RemoveFromCart" CommandArgument='<%# Container.ItemIndex %>' OnCommand="RemoveFromCartButton_Command" />--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="text-right">
        <h4 class="text-danger">Totale: <span runat="server" id="totalAmountLabel"></span>€</h4>
        <asp:Label runat="server" ID="emptyCartMessage" Visible="false" Text="Il carrello è vuoto." CssClass="text-danger"></asp:Label>
        <%--<asp:Button runat="server" ID="EmptyCartButton" Text="Svuota Carrello" CssClass="btn btn-danger" OnClick="EmptyCartButton_Click" />--%>
    </div>
</asp:Content>
