using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.Templates
{
    public partial class TemplateShop : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCartIconQuantity();
        }

        protected void UpdateCartIconQuantity()
        {
            int totQuantity = 0;
            List<CartItem> products = new List<CartItem>();

            // Check if Session["Carrello"] is not null and is of the correct type
            if (Session["Carrello"] != null && Session["Carrello"] is List<CartItem>)
            {
                products = (List<CartItem>)Session["Carrello"];

                foreach (CartItem item in products)
                {
                    // Use int.TryParse to handle cases where Quantity is not a valid integer
                    // Add a null check for item to ensure safety
                    if (item != null)
                    {
                        totQuantity += item.Quantity;
                    }
                }
            }

            Label1.Text = totQuantity.ToString();
        }

    }
}