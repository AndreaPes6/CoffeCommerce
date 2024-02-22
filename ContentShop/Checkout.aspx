<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CoffeCommerce.ContentShop.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <script src="https://js.stripe.com/v3/"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="form-group">
            <label for="card-element">Card Details</label>
            <div id="Div1" runat="server"></div>
        </div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CssClass="btn btn-primary" OnClick="SubmitButton_Click" />
    </form>

    <script>
        var stripe = Stripe('pk_live_...');
        var elements = stripe.elements();
        var card = elements.create('card');
        card.mount('#<%= cardElement.ClientID %>');

        var form = document.getElementById('payment-form');
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            stripe.createPaymentMethod({
                type: 'card',
                card: card,
            }).then(function (result) {
                if (result.error) {
                    console.log(result.error.message);
                } else {
                    /
                    __doPostBack('<%= SubmitButton.UniqueID %>', JSON.stringify({ paymentMethodId: result.paymentMethod.id }));
                }
            });
        });
    </script>
</body>
</html>
