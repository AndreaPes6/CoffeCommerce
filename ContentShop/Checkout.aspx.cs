using System;
using System.Web.UI.WebControls;
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

                // Imposta il controllo card-element come elemento di input Stripe
                //cardElement.Attributes["id"] = cardElement.ClientID;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Ottieni l'id del metodo di pagamento dal postback
            var paymentMethodId = Request.Form["__EVENTARGUMENT"];

            // Crea una nuova opzione di pagamento con Stripe
            var options = new PaymentIntentCreateOptions
            {
                PaymentMethod = paymentMethodId,
                Amount = 1000, // Sostituisci con l'importo totale dell'ordine in centesimi
                Currency = "eur",
                ConfirmationMethod = "manual",
                Confirm = true,
            };

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent = service.Create(options);

            // Gestisci la risposta di Stripe e reindirizza l'utente
            if (paymentIntent.Status == "requires_action" && paymentIntent.NextAction.Type == "use_stripe_sdk")
            {
                // Richiede l'azione del cliente per autenticare la carta
                Response.Redirect(paymentIntent.NextAction.RedirectToUrl.Url);
            }
            else if (paymentIntent.Status == "succeeded")
            {
                // Pagamento completato con successo
                Response.Redirect("PaymentSuccess.aspx");
            }
            else
            {
                // Gestione degli altri stati di pagamento
                // Puoi reindirizzare l'utente a una pagina di errore
                Response.Redirect("PaymentError.aspx");
            }
        }
    }
}
