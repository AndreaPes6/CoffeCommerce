using System;
using System.Web.UI;

namespace CoffeCommerce.ContentShop
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            bool isValidPayment = IsValidPaymentDetails();
            bool paymentSuccessful = isValidPayment && SimulatePayment();

            string script = paymentSuccessful ?
                "alert('Payment successful.'); window.location.href = 'HomeShop.aspx';" :
                "alert('Payment failed. Please try again.');";

            ScriptManager.RegisterStartupScript(this, GetType(), "PaymentResult", script, true);
        }

        private bool IsValidPaymentDetails()
        {
            string cardNumber = txtCardNumber.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            return !string.IsNullOrEmpty(cardNumber) &&
                   !string.IsNullOrEmpty(expiryDate) &&
                   !string.IsNullOrEmpty(cvv) &&
                   cardNumber.Length == 16 &&
                   IsValidExpiryDate(expiryDate) &&
                   cvv.Length == 3 &&
                   IsNumeric(cvv);
        }

        private bool IsValidExpiryDate(string expiryDate)
        {
            string[] parts = expiryDate.Split('/');
            if (parts.Length != 2)
                return false;

            if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
                return false;

            int currentYear = DateTime.Now.Year % 100;
            return month >= 1 && month <= 12 && year >= currentYear;
        }

        private bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private bool SimulatePayment()
        {
            return true;
        }
    }
}
