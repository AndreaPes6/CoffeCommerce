using System;
using System.Collections.Generic;
using System.Web.UI;
using Stripe;

namespace CoffeCommerce.ContentShop
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void ReturnToCartButton_Click(object sender, EventArgs e)
        {
            // Reindirizza l'utente alla pagina del carrello
            Response.Redirect("Cart.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configura la chiave API segreta di Stripe
                StripeConfiguration.ApiKey = "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"; // Inserisci la tua chiave API segreta

                // Genera il codice JavaScript e aggiungilo alla pagina
                string script = @"
            var stripe = Stripe('pk_live_...');
            var elements = stripe.elements();
            var card = elements.create('card');
            card.mount('#card-element');

            var form = document.getElementById('payment-form');
            form.addEventListener('submit', function (event) {
                event.preventDefault();
                stripe.createPaymentMethod({
                    type: 'card',
                    card: card,
                }).then(function (result) {
                    if (result.error) {
                        console.log(result.error.message);
                        // Mostra un alert di errore
                        alert('Si è verificato un errore durante il pagamento.');
                    } else {
                        // Invia il token al server
                        // Esegui il postback per elaborare il pagamento lato server
                        __doPostBack('" + SubmitButton.UniqueID + @"', JSON.stringify({ paymentMethodId: result.paymentMethod.id }));
                    }
                });
            });";

                // Aggiungi lo script alla pagina
                ScriptManager.RegisterStartupScript(this, GetType(), "StripeScript", script, true);
            }
        }

        // Funzione per popolare la sezione "Products" con i prodotti nel carrello


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text;


            try
            {

                Response.Redirect("PaymentConfirmation.aspx");
            }
            catch (Exception ex)
            {

                ErrorMessageLabel.Text = "Si è verificato un errore durante il pagamento. Si prega di riprovare più tardi.";
                ErrorMessageLabel.Visible = true;
            }
        }
    }
}
