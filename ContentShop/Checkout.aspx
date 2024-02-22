<%--<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CoffeCommerce.ContentShop.Checkout" %>

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

            <!-- Prodotti -->
            <div class="mb-4">
                <h2>Products</h2>
                <asp:Repeater ID="ProductRepeater" runat="server">
                    <ItemTemplate>
                        <div id="ProductsPlaceholder" class="w-75 p-0 mb-4 row bg-light border border-solid rounded justify-content-between">
                            <div class="row col-9">
                                <div class="col-3 p-0 me-2">
                                    <img src='<%# Eval("UrlImage") %>' class='img-fluid rounded-start border querySize' alt='<%# Eval("Nome") %>'>
                                </div>
                                <div class="col-8 p-0">
                                    <h3 class="card-title"><%# Eval("Nome") %></h3>
                                    <p class="card-text">Prezzo: <%# Eval("Prezzo") %> €</p>
                                    <p class="card-text m-0">Quantità: <%# Eval("Quantità") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- Indirizzo di consegna -->
            <div class="mb-4">
                <h2>Delivery Address</h2>
                <div class="form-group">
                    <label for="address">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter your address"></asp:TextBox>
                </div>
                <!-- Altre informazioni sull'indirizzo di consegna, se necessario -->
            </div>

            <!-- Metodo di pagamento -->
            <div class="mb-4">
                <h2>Payment Method</h2>
                <div class="form-group">
                    <label for="card-element">Card Details</label>
                    <div id="card-element" class="form-control"></div>
                </div>
                <!-- Altre informazioni sul metodo di pagamento, se necessario -->
            </div>

            <!-- Coupon -->
            <div class="mb-4">
                <h2>Coupon</h2>
                <!-- Form per inserire il coupon -->
                <!-- Altri dettagli sul coupon, se necessario -->
            </div>

            <!-- Pulsante per inviare il pagamento -->
            <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CssClass="btn btn-primary" OnClick="SubmitButton_Click" />

        </div>
    </form>
</body>
</html>--%>
