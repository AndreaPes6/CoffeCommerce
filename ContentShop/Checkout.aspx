<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CoffeCommerce.ContentShop.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <div class="d-flex justify-content-between">
            <h1>Checkout</h1>
            <a href="Cart.aspx" class="btn btn-secondary align-self-center">return to Cart</a>
        </div>

        <div class="mb-4">
            <h4 class="fs-5">Delivery Address</h4>
            <div class="form-group">
                <label for="firstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter your first name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="lastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter your last name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="email">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="address">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter your address"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="zip">ZIP Code</label>
                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter your ZIP code"></asp:TextBox>
            </div>
        </div>

        <div class="mb-4">
            <h4>Payment Method</h4>
            <div class="form-row">
                <div class="col">
                    <div class="form-group">
                        <label for="cardNumber">Card Number</label>
                        <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" placeholder="Enter card number" MaxLength="16"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="expiryDate">Expiry Date (MM/YYYY)</label>
                        <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" placeholder="MM/YYYY"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="cvv">CVV</label>
                        <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" placeholder="CVV" MaxLength="3"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CssClass="btn btn-success" OnClick="SubmitButton_Click" />

    </div>
</asp:Content>
