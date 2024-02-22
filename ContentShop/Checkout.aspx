<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CoffeCommerce.ContentShop.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://js.stripe.com/v3/"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="container">
            <div class="d-flex justify-content-between">
                <h1>Checkout</h1>
                <a href="Cart.aspx" class="btn btn-secondary align-self-center">Torna al Carrello</a>
            </div>

            <!-- Dati di consegna -->
            <div class="mb-4">
                <h2>Delivery Address</h2>
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

            <!-- Metodo di pagamento -->
            <div class="mb-4">
                <h2>Payment Method</h2>
                <div class="form-group">
                    <label for="card-element">Card Details</label>
                    <div id="card-element" class="form-control"></div>
                </div>

            </div>

            <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CssClass="btn btn-primary" OnClick="SubmitButton_Click" />

        </div>
    </form>
</body>
</html>
