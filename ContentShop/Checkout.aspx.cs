using System;
using System.Collections.Generic;
using System.Web.UI;
using Stripe;

namespace CoffeCommerce.ContentShop
{
    public partial class Checkout : System.Web.UI.Page
    {
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

            var form = document.getElementById('Form1');
            form.addEventListener('submit', function (event) {
                var firstName = document.getElementById('" + txtFirstName.ClientID + @"').value;
                var lastName = document.getElementById('" + txtLastName.ClientID + @"').value;
                var email = document.getElementById('" + txtEmail.ClientID + @"').value;
                var address = document.getElementById('" + txtAddress.ClientID + @"').value;
                var zip = document.getElementById('" + txtZip.ClientID + @"').value;
                
                if (!firstName || !lastName || !email || !address || !zip) {
                    event.preventDefault();
                    alert('Please fill in all required fields.');
                    return;
                }

                event.preventDefault();
                stripe.createPaymentMethod({
                    type: 'card',
                    card: card,
                }).then(function (result) {
                    if (result.error) {
                        console.log(result.error.message);
                        // Mostra un alert di errore
                        alert('An error occurred during payment. Please try again.');
                    } else {
                        // Invia il token al server
                        // Esegui il postback per elaborare il pagamento lato server
                        __doPostBack('" + SubmitButton.UniqueID + @"', JSON.stringify({ 
                            paymentMethodId: result.paymentMethod.id,
                            firstName: firstName,
                            lastName: lastName,
                            email: email,
                            address: address,
                            zip: zip
                        }));
                    }
                });
            });";

                // Aggiungi lo script alla pagina
                ScriptManager.RegisterStartupScript(this, GetType(), "StripeScript", script, true);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            bool paymentSuccessful = true;

            if (paymentSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PaymentSuccess", "alert('Payment successful.'); window.location.href = 'Home.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PaymentFailure", "alert('Payment failed. Please try again.');", true);
            }
        }
    }
}
